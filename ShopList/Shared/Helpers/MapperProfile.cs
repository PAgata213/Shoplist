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

      CreateMap<ShopBrandDTO, ShopBrand>();
      CreateMap<ShopBrand, ShopBrandDTO>();

      CreateMap<ShopDTO, Shop>();
      CreateMap<Shop, ShopDTO>();

      CreateMap<ListOfProductsToBuyDTO, ListOfProductsToBuy>();
      CreateMap<ListOfProductsToBuy, ListOfProductsToBuyDTO>();
    }
  }
}
