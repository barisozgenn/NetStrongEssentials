using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedisExchangeBaris.Services;
using StackExchange.Redis;

namespace RedisExchangeBaris.Controllers
{
    public class BaseController : Controller
    {
        private readonly RedisService _redisService;

        protected readonly IDatabase db;

        public BaseController(RedisService redisService)
        {
            _redisService = redisService;
            db = _redisService.GetDb(1);
        }
    }
}