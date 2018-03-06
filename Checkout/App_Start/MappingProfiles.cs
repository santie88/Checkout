using AutoMapper;
using Checkout.Models;
using Checkout.DTOs;

namespace Checkout.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            CreateMap<Order, OrderDto>()
                .ForMember(x => x.CustomerName, x => x.MapFrom(y => y.Customer.Name));

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(x => x.ItemName, x => x.MapFrom(y => y.Item.Name));


            // Dto to Domain
            CreateMap<OrderDto, Order>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            CreateMap<OrderItemDto, OrderItem>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}