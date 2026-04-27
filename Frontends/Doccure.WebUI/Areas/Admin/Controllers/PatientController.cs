using Microsoft.AspNetCore.Mvc;

namespace Doccure.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PatientController : Controller
    {
        public IActionResult PatientList()
        {
            return View();
        }
    }
}
