using Doccure.BranchService.Dtos.BranchDtos;

namespace Doccure.BranchService.Services
{
    public interface IBranchService
    {
        Task<List<ResultBranchDto>> GetAllAsync();
        Task<GetBranchByIdDto> GetByIdAsync(string id);
        Task CreateAsync(CreateBranchDto dto);
        Task UpdateAsync(UpdateBranchDto dto);
        Task DeleteAsync(string id);
    }
}
