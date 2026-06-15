using Doccure.MarketService.Services.RedisServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.MarketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaTestController : ControllerBase
    {
        private readonly IRedisService _redisService;
        public AreaTestController(IRedisService redisService)
        {
            _redisService = redisService;
        }
    }
}
