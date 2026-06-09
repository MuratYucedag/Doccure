using Doccure.WebUI.Dtos.MedicineDtos;

namespace Doccure.WebUI.Services.MedicineServices
{
    public interface IMedicineService
    {
        Task<List<ResultMedicineDto>> GetAllMedicinesAsync();
        Task<GetByIdMedicineDto> GetMedicineByIdAsync(string id);
        Task CreateMedicineAsync(CreateMedicineDto createMedicineDto);
        Task UpdateMedicineAsync(UpdateMedicineDto updateMedicineDto);
        Task DeleteMedicineAsync(string id);
    }
}