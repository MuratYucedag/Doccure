using Doccure.MarketService.Dtos.CartDtos;

namespace Doccure.MarketService.Services.CartServices
{
    public interface ICartService
    {
        Task AddItemToCartAsync(int patientId, CartItemDto item);
        Task<List<CartItemDto>> GetCartAsync(int patientId);
        Task RemoveItemAsync(int patientId, int productId);
        Task ClearCartAsync(int patientId);
    }
}
