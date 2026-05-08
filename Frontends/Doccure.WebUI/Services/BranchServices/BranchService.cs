using Doccure.WebUI.Dtos.BranchDtos;
using Newtonsoft.Json;
using System.Text;

namespace Doccure.WebUI.Services.BranchServices
{
    public class BranchService : IBranchService
    {
        private readonly HttpClient _httpClient;
        public BranchService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateBranchAsync(CreateBranchDto createBranchDto)
        {
            var jsonData = JsonConvert.SerializeObject(createBranchDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync("https://localhost:5000/api/branches", stringContent);
            if (result.IsSuccessStatusCode)
            {
                //işlem
            }
        }

        public async Task DeleteBranchAsync(string id)
        {
            await _httpClient.DeleteAsync($"https://localhost:5000/api/branches?id={id}");
        }

        public async Task<List<ResultBranchDto>> GetAllBranchesAsync()
        {
            var responseMessage = await _httpClient.GetAsync("https://localhost:5000/api/branches");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBranchDto>>(jsonData);
            return values;
        }

        public async Task<GetByIdBranchDto> GetBranchByIdAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"https://localhost:5000/api/branches/GetBranch?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<GetByIdBranchDto>(jsonData);

                return values;
            }

            return null;
        }

        public async Task UpdateBranchAsync(UpdateBranchDto dto)
        {
            var jsonData = JsonConvert.SerializeObject(dto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("https://localhost:5000/api/branches", stringContent);
        }
    }
}
