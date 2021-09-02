using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;
using Core.Entities.OrderAggregate;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product,ProductToReturnDto>()
            .ForMember(d=>d.ProductBrand,o=>o.MapFrom(s=>s.ProductBrand.Name))
            .ForMember(d=>d.ProductType,o=>o.MapFrom(s=>s.ProductType.Name))
            .ForMember(d=>d.PictureUrl,o=>o.MapFrom<ProductUrlResolver>());
            // CreateMap<Address, AddressDto>().ReverseMap();
             CreateMap<Core.Entities.Identity.Address,AddressDto>().ReverseMap();
             CreateMap<CustomerBasketDto,CustomerBasket>();
             CreateMap<BasketItemDto,BasketItem>();
             CreateMap<AddressDto,Core.Entities.OrderAggregate.Address>();
            // CreateMap<OrderItem,OrderItemDto>();
            CreateMap<Order,OrderToReturnDto>()
            .ForMember(d=>d.DeliveryMethod,o=>o.MapFrom(s=>s.DeliveryMethod.ShortName))
            .ForMember(d=>d.ShippingPrice,o=>o.MapFrom(s=>s.DeliveryMethod.Price)); 
             // this is done to get foreign key data from brand and type table and show there names . here 
            //d is destination and s is source
            
            CreateMap<OrderItem,OrderItemDto>()
            .ForMember(d=>d.ProductId,o=>o.MapFrom(s=>s.ItemOrdered.ProductItemId))
            .ForMember(d=>d.ProductName,o=>o.MapFrom(s=>s.ItemOrdered.ProductName))
            .ForMember(d=>d.PictureUrl,o=>o.MapFrom(s=>s.ItemOrdered.PictureUrl))
            .ForMember(d=>d.PictureUrl,o=>o.MapFrom<OrderItemUrlResolver>());

          
        }
    }
}