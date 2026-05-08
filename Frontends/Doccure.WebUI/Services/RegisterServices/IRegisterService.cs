using Doccure.WebUI.Models.Auth;

namespace Doccure.WebUI.Services.RegisterServices
{
    public interface IRegisterService
    {
        Task<bool> RegisterAsync(RegisterViewModel model);
    }
}
