using Doccure.PharmacyService.Dtos.MedicineDtos;

namespace Doccure.PharmacyService.Services.MedicineServices
{
    public interface IMedicineService
    {
        Task<List<ResultMedicineDto>> GetAllMedicineAsync();
        Task<GetByIdMedicineDto> GetByIdMedicineAsync(int id);
        Task CreateMedicineAsync(CreateMedicineDto createMedicineDto);
        Task UpdateMedicineAsync(UpdateMedicineDto updateMedicineDto);
        Task DeleteMedicineAsync(int id);
    }
}