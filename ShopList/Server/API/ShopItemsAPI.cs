using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopList.DataAccess.DataAccess;
using ShopList.Shared.DataModels.DTOs;
using ShopList.Shared.DataModels.ShopList;
using ShopList.Shared.HTTP;
using ShopList.Shared.Interfaces;

namespace ShopList.Server.API;

public static class ShopItemsAPI
{
  public static void RegisterItemsAPI(this WebApplication app)
  {
    app.MapGet(ShopList.Shared.APIAdressess.GetShopItems, GetShopItems);
    app.MapGet(ShopList.Shared.APIAdressess.GetShopItem, GetShopItem);
    app.MapPost(ShopList.Shared.APIAdressess.CreateShopItem, CreateShopItem);
    app.MapPost(ShopList.Shared.APIAdressess.RemoveShopItem, RemoveShopItem);
  }

  private static async Task<Response<IEnumerable<Product>>> GetShopItems(IDataAccessHelper dataAccessHelper)
  {
    var products = await dataAccessHelper.GetAsync<Product>();
    return new Response<IEnumerable<Product>> { DataModel = products };
  }

  private static async Task<Response<Product>> GetShopItem(IDataAccessHelper dataAccessHelper, int id)
  {
    var product = await dataAccessHelper.GetAsync<Product>(id);
    return new Response<Product> { DataModel = product };
  }

  private static async Task<IResult> CreateShopItem(IDataAccessHelper dataAccessHelper, IMapper mapper, ProductDTO productDTO)
  {
    var product = mapper.Map<Product>(productDTO);
    var productId = await dataAccessHelper.CreateAsync(product);
    if (productId == null || productId <= 0)
    {
      TypedResults.Problem();
    }
    return TypedResults.Ok(new Response<Product> { DataModel = product });
  }

  private static async Task<IResult> RemoveShopItem(IDataAccessHelper dataAccessHelper, int id)
  {
    await dataAccessHelper.DeleteAsync<Product>(id);
    return TypedResults.Ok(new Response<Product>());
  }
}
