using AutoMapper;
using ShopList.Shared.DataModels.DTOs;
using ShopList.Shared.DataModels.ShopList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList.Shared.Helpers
{
  public class MapperProfile : Profile
  {
    public MapperProfile()
    {
      CreateMap<ProductDTO, Product>();
      CreateMap<Product, ProductDTO>();

      CreateMap<ProductDTO, Product>();
      CreateMap<Product, ProductDTO>();

      CreateMap<ProductToBuyDTO, ProductDTO>()
        .ForMember(dest => dest.Id, src => src.MapFrom(s => s.ProductId))
        .ForMember(dest => dest.ProductName, src => src.MapFrom(s => s.Product.ProductName))
        .ForMember(dest => dest.Description, src => src.MapFrom(s => s.Product.Description));
      CreateMap<ProductDTO, ProductToBuyDTO>()
        .ForMember(dest => dest.ProductId, src => src.MapFrom(s => s.Id))
        .ForMember(dest => dest.Product, src => src.MapFrom(s => s));

      CreateMap<Product, ProductToBuyDTO>()
        .ForMember(dest => dest.ProductId, src => src.MapFrom(s => s.Id))
        .ForMember(dest => dest.Product, src => src.MapFrom(s => s));

      CreateMap<ProductToBuyDTO, ProductToBuy>();
      CreateMap<ProductToBuy, ProductToBuyDTO>();

      CreateMap<ShopBrandDTO, ShopBrand>();
      CreateMap<ShopBrand, ShopBrandDTO>();

      CreateMap<ShopDTO, Shop>();
      CreateMap<Shop, ShopDTO>();

      CreateMap<ListOfProductsToBuyDTO, ListOfProductsToBuy>();
      CreateMap<ListOfProductsToBuy, ListOfProductsToBuyDTO>();
    }
  }
}
