using Doccure.WebUI.Dtos.BranchDtos;

namespace Doccure.WebUI.Services.BranchServices
{
    public interface IBranchService
    {
        Task<List<ResultBranchDto>> GetAllBranchesAsync();
        Task CreateBranchAsync(CreateBranchDto dto);
        Task UpdateBranchAsync(UpdateBranchDto dto);
        Task DeleteBranchAsync(string id);
        Task<GetByIdBranchDto> GetBranchByIdAsync(string id);
    }
}