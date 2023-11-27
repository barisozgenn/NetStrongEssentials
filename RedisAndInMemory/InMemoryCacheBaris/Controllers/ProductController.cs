using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using InMemoryCacheBaris.Models;
namespace InMemoryCacheBaris.Controllers;

public class ProductController:Controller
{
    private IMemoryCache _memoryCache;
    public ProductController(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public IActionResult Index()
    {
        //NOTE: first way to check if we have cache with same name and add
        /* if(String.IsNullOrEmpty(_memoryCache.Get<string>("myDate"))){
        _memoryCache.Set<string>("myDate",DateTime.Now.ToString());
        }*/
        //NOTE: second way to check if we have cache with same name and add
        /*if(!_memoryCache.TryGetValue("myDate", out string myDateCache)){
        _memoryCache.Set<string>("myDate",DateTime.Now.ToString());
        }*/
        //NOTE: third way to trying get our cache if it is note exist
        /*_memoryCache.GetOrCreate<string>("myDate", entry => {
            return DateTime.Now.ToString();;
        });*/
        MemoryCacheEntryOptions options = new MemoryCacheEntryOptions();
        //NOTE: give 60 second available for our cache and with sliding we are adding it user use it add 7 second to cache for each request from user.
        options. AbsoluteExpiration = DateTime.Now.AddMinutes(1);
        options.SlidingExpiration = TimeSpan.FromSeconds(7);
        //NOTE: for example if our ram is full we are saying that this cach is not important remove it.
        options.Priority = CacheItemPriority.Low;
        //NOTE: why our cache is deleted because of ram or expired or etc.
        options.RegisterPostEvictionCallback((key,value,reason,state)=>{
            _memoryCache. Set("callbackMyDate",$"{key}:{value} - reason: {reason}");
        });
        _memoryCache. Set<string>("myDate", DateTime.Now. ToString(),options);

        //complex types caching
        Product myProduct = new Product{Id= 14, Name= "my Product", Price = 99};
        _memoryCache. Set<Product>("myProduct:14", myProduct,options);

        return View();
    }
    public IActionResult ShowMySimpleDateCache()
    {
        //Get myDate cache;
        //ViewBag.myDate = _memoryCache.Get<string>("myDate");
        _memoryCache.TryGetValue("myDate", out string myDateCache);
        _memoryCache.TryGetValue("callbackMyDate", out string callbackMyDateCache);

        ViewBag.myDate = myDateCache;
        ViewBag.callbackMyDateCache = callbackMyDateCache;
        ViewBag.myProduct = _memoryCache.Get<Product>("myProduct:14");
        return View();
    }
}

