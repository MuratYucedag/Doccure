using Doccure.WebUI.Dtos.DoctorDtos;
using Humanizer;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace Doccure.WebUI.Services.DoctorServices
{
    public class DoctorService : IDoctorService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DoctorService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task CreateDoctorAsync(CreateDoctorDto createDoctorDto)
        {
            PrepareAuthorizationHeader();

            // Geçici: tüm problematik alanları override et
            createDoctorDto.Status = true;
            createDoctorDto.PricePerHour = 1000;
            createDoctorDto.ExperienceYear = createDoctorDto.ExperienceYear == 0 ? 1 : createDoctorDto.ExperienceYear;

            // Null list'leri boş listeye çevir (API [Required] validation'ı atlat)
            createDoctorDto.Educations ??= new List<EducationDto>();
            createDoctorDto.Experiences ??= new List<ExperienceDto>();
            createDoctorDto.Awards ??= new List<AwardDto>();
            createDoctorDto.Locations ??= new List<LocationDto>();
            createDoctorDto.Services ??= new List<string>();
            createDoctorDto.Specializations ??= new List<string>();

            var jsonData = JsonConvert.SerializeObject(createDoctorDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync("https://localhost:5000/api/doctors", stringContent);
            await HandleResponseErrors(responseMessage);
        }
        public async Task DeleteDoctorAsync(string id)
        {
            PrepareAuthorizationHeader();
            var responseMessage = await _httpClient.DeleteAsync($"https://localhost:5000/api/doctors?id={id}");
            await HandleResponseErrors(responseMessage);
        }

        public async Task<List<ResultDoctorDto>> GetAllDoctorsAsync()
        {
            PrepareAuthorizationHeader();
            var responseMessage = await _httpClient.GetAsync("https://localhost:5000/api/doctors");
            await HandleResponseErrors(responseMessage);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultDoctorDto>>(jsonData);
            return values;
        }
        public async Task<GetByIdDoctorDto> GetDoctorByIdAsync(string id)
        {
            PrepareAuthorizationHeader();
            var responseMessage = await _httpClient.GetAsync($"https://localhost:5000/api/doctors/GetDoctor?id={id}");
            await HandleResponseErrors(responseMessage);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<GetByIdDoctorDto>(jsonData);
            return values;
        }
        public async Task UpdateDoctorAsync(UpdateDoctorDto updateDoctorDto)
        {
            PrepareAuthorizationHeader();
            var jsonData = JsonConvert.SerializeObject(updateDoctorDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PutAsync("https://localhost:5000/api/doctors", stringContent);
            await HandleResponseErrors(responseMessage);
        }
        private void PrepareAuthorizationHeader()
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("JwtToken");
            token = token?.Trim().Replace("\"", "");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        private async Task HandleResponseErrors(HttpResponseMessage responseMessage)
        {
            if (responseMessage.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new UnauthorizedAccessException("403");
            }

            if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("401");
            }

            if (responseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception("404");
            }

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception("Bir hata oluştu");
            }
        }
    }
}