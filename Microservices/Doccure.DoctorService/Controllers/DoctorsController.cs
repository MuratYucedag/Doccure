using Doccure.DoctorService.Dtos.DoctorDtos;
using Doccure.DoctorService.Services.DoctorServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.DoctorService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            var values = await _doctorService.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorById(string id)
        {
            var value = await _doctorService.GetByIdAsync(id);
            if (value == null)
                return NotFound("Doctor not found");
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor(CreateDoctorDto dto)
        {
            await _doctorService.CreateAsync(dto);
            return Ok("Doctor created successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDoctor(UpdateDoctorDto dto)
        {
            await _doctorService.UpdateAsync(dto);
            return Ok("Doctor updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(string id)
        {
            await _doctorService.DeleteAsync(id);
            return Ok("Doctor deleted successfully");
        }
    }
}
