using Doccure.DoctorService.Dtos.DoctorDtos;

namespace Doccure.DoctorService.Services.DoctorServices
{
    public interface IDoctorService
    {
        Task<List<ResultDoctorDto>> GetAllAsync();
        Task<GetByIdDoctorDto> GetByIdAsync(string id);
        Task CreateAsync(CreateDoctorDto dto);
        Task UpdateAsync(UpdateDoctorDto dto);
        Task DeleteAsync(string id);
    }
}
