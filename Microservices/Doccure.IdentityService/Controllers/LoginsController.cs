using Doccure.IdentityService.Dtos;
using Doccure.IdentityService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.IdentityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly IAuthService _authService;
        public LoginsController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(LoginDto dto)
        {
            var token = await _authService.LoginAsync(dto);

            if (token == null)
                return Unauthorized("Email veya şifre hatalı");

            return Ok(new { token }); // 💥 burada token dönüyor
        }
    }
}
