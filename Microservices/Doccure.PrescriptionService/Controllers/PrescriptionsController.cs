using Doccure.PrescriptionService.Dtos.PrescriptionDtos;
using Doccure.PrescriptionService.Services.PrescriptionService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.PrescriptionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;
        public PrescriptionsController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePrescription(CreatePrescriptionDto createPrescriptionDto)
        {
            await _prescriptionService.CreateAsync(createPrescriptionDto);
            return Ok("Ekleme başarılı");
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _prescriptionService.GetByIdAsync(id);
            if (value == null)
                return NotFound("Reçete bulunamadı");

            return Ok(value);
        }

        [HttpGet("GetByAppointmentId")]
        public async Task<IActionResult> GetByAppointmentId(int id)
        {
            var value = await _prescriptionService.GetByAppointmentIdAsync(id);
            if (value == null)
                return NotFound("Reçete bulunamadı");

            return Ok(value);
        }

        [HttpGet("GetByPatientId")]
        public async Task<IActionResult> GetByPatientId(string id)
        {
            var values = await _prescriptionService.GetByPatientIdAsync(id);
            return Ok(values);
        }
    }
}
