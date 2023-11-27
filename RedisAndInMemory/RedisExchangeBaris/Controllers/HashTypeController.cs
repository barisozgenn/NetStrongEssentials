using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedisExchangeBaris.Services;
using StackExchange.Redis;

namespace RedisExchangeBaris.Controllers
{
    public class HashTypeController : BaseController
    {
        public string hashKey { get; set; } = "MyBooks";

        //send back our redisService to RedisService.cs
        public HashTypeController(RedisService redisService) : base(redisService)
        {
        }

        public IActionResult Index()
        {
            Dictionary<string, string> list = new Dictionary<string, string>();

            if (db.KeyExists(hashKey))
            {
                db.HashGetAll(hashKey).ToList().ForEach(x =>
                {
                    list.Add(x.Name, x.Value);
                });
            }

            return View(list);
        }

        [HttpPost]
        public IActionResult Add(string name, string val)
        {
            db.HashSet(hashKey, name, val);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteItem(string name)
        {
            db.HashDelete(hashKey, name);
            return RedirectToAction("Index");
        }
    }
}