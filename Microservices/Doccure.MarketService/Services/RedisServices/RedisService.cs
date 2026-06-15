using StackExchange.Redis;

namespace Doccure.MarketService.Services.RedisServices
{
    public class RedisService : IRedisService
    {
        private readonly IDatabase _database;
        public RedisService(IConfiguration configuration)
        {
            var redis = ConnectionMultiplexer.Connect(configuration["RedisSettings:ConnectionString"]);
            _database = redis.GetDatabase();
        }

        public async Task DeleteKeyAsync(string key)
        {
            await _database.KeyDeleteAsync(key);
        }

        public async Task<string> GetValueAsync(string key)
        {
            return await _database.StringGetAsync(key);
        }

        public async Task SetValueAsync(string key, string value)
        {
            await _database.StringSetAsync(key, value);
        }
    }
}
