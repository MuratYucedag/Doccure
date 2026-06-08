using Doccure.PatientService.Dtos.PatientDtos;

namespace Doccure.PatientService.Services.PatientServices
{
    public interface IPatientService
    {
        Task<List<ResultPatientDto>> GetAllPatientsAsync();
    }
}
