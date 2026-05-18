using Doccure.WebUI.Dtos.DoctorDtos;
using Doccure.WebUI.Services.DoctorServices;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _DoctorService;
        public DoctorController(IDoctorService DoctorService)
        {
            _DoctorService = DoctorService;
        }
        public async Task<IActionResult> DoctorList()
        {
            var values = await _DoctorService.GetAllDoctorsAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateDoctor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor(CreateDoctorDto createDoctorDto)
        {
            await _DoctorService.CreateDoctorAsync(createDoctorDto);
            return RedirectToAction("DoctorList");
        }

        public async Task<IActionResult> DeleteDoctor(string id)
        {
            await _DoctorService.DeleteDoctorAsync(id);
            return RedirectToAction("DoctorList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDoctor(string id)
        {
            var value = await _DoctorService.GetDoctorByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDoctor(UpdateDoctorDto updateDoctorDto)
        {
            await _DoctorService.UpdateDoctorAsync(updateDoctorDto);
            return RedirectToAction("DoctorList");
        }
    }
}
