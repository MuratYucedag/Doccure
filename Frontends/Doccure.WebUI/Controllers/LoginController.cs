using Doccure.WebUI.Dtos.LoginDtos;
using Doccure.WebUI.Services.LoginServices;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(LoginDto loginDto)
        {
            var token = await _loginService.LoginAsync(loginDto);
            ViewBag.v = token;
            HttpContext.Session.SetString("JwtToken", token);
            return RedirectToAction("BranchList", "Branch", new { area = "Admin" });
        }
    }
}
