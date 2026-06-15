using Doccure.OrderService.Dtos.OrderDtos;

namespace Doccure.OrderService.Services.OrderServices
{
    public interface IOrderService
    {
        Task CreateOrderAsync(CreateOrderDto createOrderDto);
        Task<List<ResultOrderDto>> GetAllOrderAsync();
        Task<GetByIdOrderDto> GetByIdOrderAsync(int id);
    }
}
