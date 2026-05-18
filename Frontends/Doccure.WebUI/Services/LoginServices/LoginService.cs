using Doccure.WebUI.Dtos.LoginDtos;
using Doccure.WebUI.Dtos.TokenDtos;
using Newtonsoft.Json;
using System.Text;

namespace Doccure.WebUI.Services.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient _httpClient;
        public LoginService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            var jsonData = JsonConvert.SerializeObject(loginDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await _httpClient.PostAsync("https://localhost:7225/api/Logins", stringContent);

            if (!responseMessage.IsSuccessStatusCode)
            {
                return null;
            }

            var responseJson = await responseMessage.Content.ReadAsStringAsync();

            var tokenResponse = JsonConvert.DeserializeObject<TokenResponseDto>(responseJson);

            return tokenResponse.Token;

            //var token = await responseMessage.Content.ReadAsStringAsync();

            //return token;
        }
    }
}
