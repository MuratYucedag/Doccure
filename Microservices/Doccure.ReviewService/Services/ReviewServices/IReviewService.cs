using Doccure.ReviewService.Dtos.ReviewDtos;

namespace Doccure.ReviewService.Services.ReviewServices
{
    public interface IReviewService
    {
        Task<List<ResultReviewDto>> GetAllAsync();
        Task<GetByIdReviewDto> GetByIdAsync(string id);
        Task CreateAsync(CreateReviewDto dto);
        Task DeleteAsync(string id);
    }
}
