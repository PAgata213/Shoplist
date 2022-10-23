using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopList.Client.Pages;
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
    app.MapGet(ShopList.Shared.APIAdressess.GetProducts, GetShopItems);
    app.MapGet(ShopList.Shared.APIAdressess.GetProduct, GetShopItem);
    app.MapPost(ShopList.Shared.APIAdressess.CreateProduct, CreateShopItem);
    app.MapPut(ShopList.Shared.APIAdressess.UpdateProduct, UpdateShopItem);
    app.MapPost(ShopList.Shared.APIAdressess.RemoveProduct, RemoveShopItem);
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

  private static async Task<IResult> UpdateShopItem(IDataAccessHelper dataAccessHelper, IMapper mapper, ProductDTO productDTO)
  {
    if (productDTO == null || productDTO.Id <= 0)
    {
      return TypedResults.BadRequest(new Response<Product> 
      { 
        ErrorMessage = "Selected product does not exists", 
        StatusCode = System.Net.HttpStatusCode.BadRequest 
      });
    }
    var product = mapper.Map<Product>(productDTO);
    var result = await dataAccessHelper.UpdateAsync(product);
    if (!result)
    {
      TypedResults.Problem("Error during updating product");
    }
    return TypedResults.Ok(new Response<Product> { DataModel = product });
  }

  private static async Task<IResult> RemoveShopItem(IDataAccessHelper dataAccessHelper, Product product)
  {
    await dataAccessHelper.DeleteAsync(product);
    return TypedResults.Ok(new Response<Product>());
  }
}
