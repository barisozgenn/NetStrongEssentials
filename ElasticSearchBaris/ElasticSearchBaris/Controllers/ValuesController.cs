using Elasticsearch.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ElasticSearchBaris.Context;
using ElasticSearchBaris.ElasticsearchServices;
using Newtonsoft.Json.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ElasticSearchBaris.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class ValuesController : ControllerBase
{
    AppDbContext context = new();

    [HttpGet("[action]")]
    public async Task<IActionResult> CreateData(CancellationToken cancellationToken)
    {
        IList<Book> books = new List<Book>();
        var random = new Random();
        string characters = "abcdefghijklmnoprstuwxyz";

        for (int i = 0; i < 10000; i++)
        {
            var title = new string(Enumerable.Repeat(characters, random.Next(3,7))
                .Select(s=> s[random.Next(s.Length)]).ToArray());

            var words = new List<string>();
            for (int j = 0; j < 500; j++)
            {
                words.Add(new string(Enumerable.Repeat(characters,random.Next(3,7))
                .Select(s => s[random.Next(s.Length)]).ToArray()));
            }

            var description = string.Join(" ", words);
            var book = new Book()
            {
                Title = title,
                Description = description,
            };

            books.Add(book);
        }

        await context.Set<Book>().AddRangeAsync(books, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return Ok();
    }

    [HttpGet("[action]/{value}")]
    public async Task<IActionResult> GetDataListWithEF(string value)
    {
        IList<Book> books = 
            await context.Set<Book>()
            .Where(p => p.Description.Contains(value))
            .AsNoTracking()
            .ToListAsync();

        return Ok(books.Take(10));
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> SyncToElastic()
    {
        var settings = new ConnectionConfiguration(new Uri("http://localhost:9200"));

        var client = new ElasticLowLevelClient(settings);

        List<Book> books = await context.Books.ToListAsync();

        var tasks = new List<Task>();

        foreach (var book in books)
        {
            //tasks.Add(client.IndexAsync<StringResponse>("books", book.Id.ToString(), PostData.Serializable(new
            //{
            //    book.Id,
            //    book.Title,
            //    book.Description
            //})));

            var response = await client.GetAsync<StringResponse>("books", book.Id.ToString());

            if (response.HttpStatusCode != 200)
            {
                tasks.Add(client.IndexAsync<StringResponse>("books", book.Id.ToString(), PostData.Serializable(book)));
            }
        }

        await Task.WhenAll(tasks);

        return Ok();
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> SyncToElasticWithService()
    {
        await ElasticsearchService.SyncToElastic<Book>("books", () => context.Books.ToListAsync());

        return Ok();
    }
    
    [HttpGet("[action]")]
    public async Task<IActionResult> SyncSingleToElasticWithService()
    {
        Book book = new();
        await ElasticsearchService.SyncSingleToElastic<Book>("books", book);

        return Ok();
    }

    [HttpGet("[action]/{value}")]
    public async Task<IActionResult> GetDataListWithElasticSearch(string value)
    {
        var settings = new ConnectionConfiguration(new Uri("http://localhost:9200"));

        var client = new ElasticLowLevelClient(settings);

        var response = await client.SearchAsync<StringResponse>("books", PostData.Serializable(new
        {
            query = new
            {
                wildcard = new
                {
                    Description = new { value = $"*{value}*" }
                }
            }
        }));

        var results = JObject.Parse(response.Body);

        var hits = results["hits"]["hits"].ToObject<List<JObject>>();

        List<Book> books = new();

        foreach (var hit in hits)
        {
            books.Add(hit["_source"].ToObject<Book>());
        }

        return Ok(books.Take(10));
    }

    [HttpGet("[action]/{value}")]
    public async Task<IActionResult> GetDataListWithElasticSearchToService(string value)
    {
        var response = await ElasticsearchService.GetDataListWithElasticSearch<Book>("books", "Description", value);

        return Ok(response.Take(10));
    }
}

