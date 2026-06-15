namespace Doccure.MarketService.Services.RedisServices
{
    public interface IRedisService
    {
        Task SetValueAsync(string key, string value);
        Task<string> GetValueAsync(string key);
        Task DeleteKeyAsync(string key);
    }
}