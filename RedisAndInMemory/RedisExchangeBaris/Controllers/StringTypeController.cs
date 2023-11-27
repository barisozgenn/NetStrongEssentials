using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedisExchangeBaris.Services;
using StackExchange.Redis;

namespace RedisExchangeBaris.Controllers
{
    public class StringTypeController : Controller
    {
        private readonly RedisService _redisService;

        private readonly IDatabase db;

        public StringTypeController(RedisService redisService)
        {
            _redisService = redisService;
            db = _redisService.GetDb(0);
        }

        public IActionResult Index()
        {
            db.StringSet("name", "Baris Ozgen");
            db.StringSet("visitorsOfBarisMuseum", 100);

            return View();
        }

        public IActionResult Show()
        {
            var value = db.StringLength("name");

            // db.StringIncrement("visitorsOfBarisMuseum", 10);

            // var count = db.StringDecrementAsync("visitorsOfBarisMuseum", 1).Result;

            db.StringDecrementAsync("visitorsOfBarisMuseum", 10).Wait();

            ViewBag.value = value.ToString();

            return View();
        }
    }
}