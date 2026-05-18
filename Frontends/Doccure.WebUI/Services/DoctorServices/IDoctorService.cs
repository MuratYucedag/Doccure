using Doccure.WebUI.Dtos.DoctorDtos;

namespace Doccure.WebUI.Services.DoctorServices
{
    public interface IDoctorService
    {
        Task<List<ResultDoctorDto>> GetAllDoctorsAsync();
        Task<GetByIdDoctorDto> GetDoctorByIdAsync(string id);
        Task CreateDoctorAsync(CreateDoctorDto createDoctorDto);
        Task UpdateDoctorAsync(UpdateDoctorDto updateDoctorDto);
        Task DeleteDoctorAsync(string id);
    }
}
