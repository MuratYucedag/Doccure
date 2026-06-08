using Doccure.WebUI.Dtos.PatientDtos;
using Newtonsoft.Json;

namespace Doccure.WebUI.Services.PatientServices
{
    public class PatientService : IPatientService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PatientService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<ResultPatientDto>> GetAllPatientsAsync()
        {
            var responseMessage = await _httpClient.GetAsync("https://localhost:7109/api/Patients");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultPatientDto>>(jsonData);
            return values;
        }
    }
}
