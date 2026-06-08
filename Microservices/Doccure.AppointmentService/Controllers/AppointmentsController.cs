using Doccure.AppointmentService.Dtos.AppointmentDtos;
using Doccure.AppointmentService.Services.AppointmentServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.AppointmentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _service;
        public AppointmentsController(IAppointmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointment()
        {
            var values = await _service.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("GetAppointment")]
        public async Task<IActionResult> GetAppointment(int id)
        {
            var value = await _service.GetByIdAsync(id);
            if (value == null)
                return NotFound("Randevu bulunamadı");
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment(CreateAppointmentDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok("Randevu başarıyla oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAppointment(UpdateAppointmentDto dto)
        {
            await _service.UpdateAsync(dto);
            return Ok("Randevu başarıyla güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            await _service.DeleteAsync(id);
            return Ok("Randevu başarıyla silindi");
        }

        [HttpGet("patient/{patientId}/last")]
        public async Task<IActionResult> GetLastAppointmentByPatientId(string patientId)
        {
            var value = await _service.GetLastAppointmentByPatientIdAsync(patientId);

            if (value == null)
                return NotFound();

            return Ok(value);
        }
    }
}
