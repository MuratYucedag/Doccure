using Doccure.WebUI.Dtos.LoginDtos;

namespace Doccure.WebUI.Services.LoginServices
{
    public interface ILoginService
    {
        Task<string> LoginAsync(LoginDto loginDto);
    }
}