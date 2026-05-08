using Doccure.IdentityService.Dtos;

namespace Doccure.IdentityService.Services.RoleServices
{
    public interface IRoleService
    {
        Task<bool> CreateRoleAsync(CreateRoleDto dto);
    }
}
