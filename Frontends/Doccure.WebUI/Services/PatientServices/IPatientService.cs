using Doccure.WebUI.Dtos.PatientDtos;

namespace Doccure.WebUI.Services.PatientServices
{
    public interface IPatientService
    {
        Task<List<ResultPatientDto>> GetAllPatientsAsync();
    }
}
