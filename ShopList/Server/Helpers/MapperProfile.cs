﻿using AutoMapper;
using ShopList.Shared.DataModels.DTOs;
using ShopList.Shared.DataModels.ShopList;

namespace ShopList.Server.Helpers
{
  public class MapperProfile : Profile
  {
    public MapperProfile()
    {
      CreateMap<ProductDTO, Product>();
      CreateMap<Product, ProductDTO>();
    }
  }
}
