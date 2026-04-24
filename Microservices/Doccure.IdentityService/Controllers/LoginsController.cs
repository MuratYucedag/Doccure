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
            var result = await _authService.LoginAsync(dto);

            if (!result)
                return BadRequest("Email veya şifre hatalı");

            return Ok("Giriş başarılı");
        }
    }
}
