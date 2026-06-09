using Doccure.PharmacyService.Dtos.MedicineDtos;
using Doccure.PharmacyService.Services.MedicineServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.PharmacyService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : ControllerBase
    {
        private readonly IMedicineService _medicineService;
        public MedicinesController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMedicines()
        {
            var values = await _medicineService.GetAllMedicineAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicineById(int id)
        {
            var value = await _medicineService.GetByIdMedicineAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMedicine(CreateMedicineDto createMedicineDto)
        {
            await _medicineService.CreateMedicineAsync(createMedicineDto);
            return Ok("Medicine added successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMedicine(UpdateMedicineDto updateMedicineDto)
        {
            await _medicineService.UpdateMedicineAsync(updateMedicineDto);
            return Ok("Medicine updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicine(int id)
        {
            await _medicineService.DeleteMedicineAsync(id);
            return Ok("Medicine deleted successfully");
        }
    }
}
