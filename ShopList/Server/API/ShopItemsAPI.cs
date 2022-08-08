using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopList.DataAccess.DataAccess;
using ShopList.Shared.DataModels.DTOs;
using ShopList.Shared.DataModels.ShopList;
using ShopList.Shared.Interfaces;

namespace ShopList.Server.API;

public static class ShopItemsAPI
{
  public static void RegisterItemsAPI(this WebApplication app)
  {
    app.MapGet("/shop/items", GetShopItems);
    app.MapGet("/shop/items/{id}", GetShopItem);
    app.MapPut("/shop/items/create", CreateShopItem);
    app.MapPost("/shop/items/remove/{id}", RemoveShopItem);
  }

  private static async Task<IEnumerable<ProductDTO>> GetShopItems(IDataAccessHelper dataAccessHelper, IMapper mapper)
  {
    var products = await dataAccessHelper.GetAsync<Product>();
    return products.Select(p => mapper.Map<ProductDTO>(p));
  }

  private static async Task<ProductDTO?> GetShopItem(IDataAccessHelper dataAccessHelper, IMapper mapper, int id)
  {
    var product = await dataAccessHelper.GetAsync<Product>(id);
    return mapper.Map<ProductDTO>(product);
  }

  private static async Task<IResult> CreateShopItem(IDataAccessHelper dataAccessHelper, IMapper mapper, ProductDTO productDTO)
  {
    var product = mapper.Map<Product>(productDTO);
    var productId = await dataAccessHelper.CreateAsync(product);
    if (productId == null || productId <= 0)
    {
      TypedResults.Problem();
    }
    return TypedResults.Ok(new { ProductId = productId });
  }

  private static async Task<IResult> RemoveShopItem(IDataAccessHelper dataAccessHelper, int id)
  {
    await dataAccessHelper.DeleteAsync<Product>(id);
    return TypedResults.Ok();
  }
}
