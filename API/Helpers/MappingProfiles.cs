using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;

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
             CreateMap<Address,AddressDto>().ReverseMap();
             CreateMap<CustomerBasketDto,CustomerBasket>();
             CreateMap<BasketItemDto,BasketItem>();


            // this is done to get foreign key data from brand and type table and show there names . here 
            //d is destination and s is source
        }
    }
}