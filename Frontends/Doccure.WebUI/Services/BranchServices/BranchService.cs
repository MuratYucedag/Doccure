using Doccure.WebUI.Dtos.BranchDtos;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace Doccure.WebUI.Services.BranchServices
{
    public class BranchService : IBranchService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BranchService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateBranchAsync(CreateBranchDto createBranchDto)
        {
            PrepareAuthorizationHeader();
            var jsonData = JsonConvert.SerializeObject(createBranchDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync("https://localhost:5000/api/branches", stringContent);
            await HandleResponseErrors(responseMessage);
        }

        public async Task DeleteBranchAsync(string id)
        {
            PrepareAuthorizationHeader();
            var responseMessage = await _httpClient.DeleteAsync($"https://localhost:5000/api/branches?id={id}");
            await HandleResponseErrors(responseMessage);
        }

        public async Task<List<ResultBranchDto>> GetAllBranchesAsync()
        {
            PrepareAuthorizationHeader();

            var responseMessage = await _httpClient.GetAsync("https://localhost:5000/api/branches");

            await HandleResponseErrors(responseMessage);

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBranchDto>>(jsonData);
            return values;
        }

        public async Task<GetByIdBranchDto> GetBranchByIdAsync(string id)
        {
            PrepareAuthorizationHeader();
            var responseMessage = await _httpClient.GetAsync($"https://localhost:5000/api/branches/GetBranch?id={id}");
            await HandleResponseErrors(responseMessage);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<GetByIdBranchDto>(jsonData);
            return values;
        }

        public async Task UpdateBranchAsync(UpdateBranchDto dto)
        {
            PrepareAuthorizationHeader();
            var jsonData = JsonConvert.SerializeObject(dto); StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PutAsync("https://localhost:5000/api/branches", stringContent);
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
