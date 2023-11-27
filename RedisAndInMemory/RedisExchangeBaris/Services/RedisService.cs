using StackExchange.Redis;

namespace RedisExchangeBaris.Services;

public class RedisService
    {
        private readonly string _redisHost;

        private readonly string _redisPort;
        private ConnectionMultiplexer _redis;
        //it is redis db
        public IDatabase db { get; set; }

        public RedisService(IConfiguration configuration)
        {
            // it is coming from appsettings.json {Redis:{Host:"our_host"}}
            _redisHost = configuration["Redis:Host"];

            _redisPort = configuration["Redis:Port"];
        }

        public void Connect()
        {
            var configString = $"{_redisHost}:{_redisPort}";

            _redis = ConnectionMultiplexer.Connect(configString);
        }
        //get redis db
        public IDatabase GetDb(int db)
        {
            return _redis.GetDatabase(db);
        }
    }
