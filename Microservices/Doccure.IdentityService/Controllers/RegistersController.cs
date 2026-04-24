using Doccure.IdentityService.Dtos;
using Doccure.IdentityService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.IdentityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly IAuthService _authService;
        public RegistersController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegister(RegisterDto registerDto)
        {
            var result = await _authService.RegisterAsync(registerDto);
           
            if (!result)
                return BadRequest("Kullanıcı oluşturulamadı");

            return Ok("Kayıt başarılı");
        }
    }
}
