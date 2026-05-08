using Doccure.WebUI.Models.Auth;
using System.Text;
using System.Text.Json;

namespace Doccure.WebUI.Services.RegisterServices
{
    public class RegisterService : IRegisterService
    {
        private readonly HttpClient _client;
        public RegisterService(HttpClient client)
        {
            _client = client;
        }

        public async Task<bool> RegisterAsync(RegisterViewModel model)
        {
            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("https://localhost:7225/api/Registers", content);

            return response.IsSuccessStatusCode;
        }
    }
}
