using Doccure.AppointmentService.Dtos.AppointmentDetail;
using Doccure.AppointmentService.Services.AppointmentDetailServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.AppointmentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentDetailsController : ControllerBase
    {
        private readonly IAppointmentDetailService _appointmentDetailService;
        public AppointmentDetailsController(IAppointmentDetailService appointmentDetailService)
        {
            _appointmentDetailService = appointmentDetailService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointmentDetail(CreateAppointmentDetailDto createAppointmentDetailDto)
        {
            await _appointmentDetailService.CreateAsync(createAppointmentDetailDto);
            return Ok("Ekleme başarılı");
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointmentDetail(int id)
        {
            var value = await _appointmentDetailService.GetByAppointmentIdAsync(id);
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAppointmentDetail(UpdateAppointmentDetailDto updateAppointmentDetailDto)
        {
            await _appointmentDetailService.UpdateAsync(updateAppointmentDetailDto);
            return Ok("Güncelleme başarılı");
        }
    }
}
