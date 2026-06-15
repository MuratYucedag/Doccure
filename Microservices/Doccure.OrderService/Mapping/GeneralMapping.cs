using AutoMapper;
using Doccure.OrderService.Dtos.OrderDetailDtos;
using Doccure.OrderService.Dtos.OrderDtos;
using Doccure.OrderService.Entities;

namespace Doccure.OrderService.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, GetByIdOrderDto>().ReverseMap();
            CreateMap<Order, ResultOrderDto>().ReverseMap();

            CreateMap<OrderDetail, ResultOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, CreateOrderDetailDto>().ReverseMap();
        }
    }
}
