using Doccure.WebUI.Dtos.ProductDtos;

namespace Doccure.WebUI.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductsAsync();
    }
}
