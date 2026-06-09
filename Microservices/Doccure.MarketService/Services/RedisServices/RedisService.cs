using StackExchange.Redis;

namespace Doccure.MarketService.Services.RedisServices
{
    public class RedisService : IRedisService
    {
        private readonly IDatabase _database;
        public Task<string> GetValueAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task SetValueAsync(string key, string value)
        {
            throw new NotImplementedException();
        }
    }
}
