using Doccure.WebUI.Models.Auth;
using Doccure.WebUI.Services.RegisterServices;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IRegisterService _registerService;
        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterViewModel model)
        {
            await _registerService.RegisterAsync(model);
            return RedirectToAction("SignIn", "Login");
        }
    }
}
