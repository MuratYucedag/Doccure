using Doccure.IdentityService.Dtos;

namespace Doccure.IdentityService.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(RegisterDto dto);
        Task<string?> LoginAsync(LoginDto dto);
    }
}
