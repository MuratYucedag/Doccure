using Doccure.WebUI.Services.PatientServices;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        public async Task< IActionResult> PatientList()
        {
            var values = await _patientService.GetAllPatientsAsync();
            return View(values);
        }
        public IActionResult Testt()
        {
            return View();
        }
    }
}
