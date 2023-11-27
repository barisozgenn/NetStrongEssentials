using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using RedisCacheBaris.Models;
namespace RedisCacheBaris.Controllers;

public class ProductController:Controller
{
    private IDistributedCache _disributedCache;
    public ProductController(IDistributedCache disributedCache)
    {
        _disributedCache = disributedCache;
    }

    public async Task<IActionResult> Index()
    {
        DistributedCacheEntryOptions options = new DistributedCacheEntryOptions(); 
        options.AbsoluteExpiration = DateTime.Now.AddMinutes(1);

        _disributedCache.SetString("name","baris",options);
        //wait for this process to complete
        await _disributedCache.SetStringAsync("surname","ozgen",options);
        //_disributedCache.Remove("name");
        Product product = new Product { Id = 14, Name = "Pencil", Price = 100 };
        //Json saving as a string
        string jsonProduct = JsonConvert.SerializeObject(product);
        await _disributedCache.SetStringAsync("pencil:14",jsonProduct,options);
        //binary saving
        Byte[] bytesProduct = Encoding.UTF8.GetBytes(jsonProduct);
        await _disributedCache.SetAsync("pencil:15",bytesProduct);
        return View();
    }
    public async Task<IActionResult> ShowMySimpleDateCache()
    {
        ViewBag.name = _disributedCache.GetString("name");
        ViewBag.surname = await _disributedCache.GetStringAsync("surname");
        string jsonProduct = await _disributedCache.GetStringAsync("pencil:14");
        ViewBag.myProduct = JsonConvert.DeserializeObject<Product>(jsonProduct);
        Byte[] bytesProduct = _disributedCache.Get("pencil:15");
        string jsonBytesProduct = Encoding.UTF8.GetString(bytesProduct);
        ViewBag.myProductBinary = JsonConvert.DeserializeObject<Product>(jsonBytesProduct);

        return View();
    }

    public async Task<IActionResult> ImageCache()
    {
        //SET
        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/myImage.jpg");
        byte[] imageByte = System. IO. File.ReadAllBytes(path);
        _disributedCache.SetAsync("myImage", imageByte);
        //GET
        byte[] imageByteFrom = await _disributedCache.GetAsync("myImage");
        var myImage = File(imageByteFrom, "image/jpg");//if you return the file you call call it like src='product/ImageCache'
        return View();
    }

}

