using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopList.Shared.DataModels.DTOs;
using ShopList.Shared.DataModels.ShopList;
using ShopList.Shared.HTTP;
using ShopList.Shared.Interfaces;

namespace ShopList.Server.API
{
  public static class ShopsAPI
  {
    public static void RegisterShopsAPI(this WebApplication app)
    {
      app.MapGet(ShopList.Shared.APIAdressess.GetShops, GetShops);
      app.MapGet(ShopList.Shared.APIAdressess.GetShop, GetShop);
      app.MapPost(ShopList.Shared.APIAdressess.CreateShop, CreateShop);
      app.MapPut(ShopList.Shared.APIAdressess.UpdateShop, UpdateShop);
      app.MapPost(ShopList.Shared.APIAdressess.RemoveShop, RemoveShop);
    }

    private static async Task<Response<IEnumerable<Shop>>> GetShops(IDataAccessHelper dataAccessHelper)
    {
      var response = new Response<IEnumerable<Shop>>();
      var querable = dataAccessHelper.GetAsQuerable<Shop>();
      response.DataModel = await querable.Include(s => s.ShopBrand).AsNoTracking().ToListAsync();
      return response;
    }

    private static async Task<Response<Shop>> GetShop(IDataAccessHelper dataAccessHelper, int id)
    {
      var response = new Response<Shop>();
      response.DataModel = await dataAccessHelper.GetAsync<Shop>(id);
      return response;
    }

    private static async Task<IResult> CreateShop(IDataAccessHelper dataAccessHelper, IMapper mapper, ShopDTO shopDTO)
    {
      if (shopDTO == null || shopDTO.ShopBrandId <= 0)
      {
        return TypedResults.BadRequest(new Response<Shop> { ErrorMessage = "Invalid data" });
      }
      var shopBrand = await dataAccessHelper.GetAsync<ShopBrand>(shopDTO.ShopBrandId);
      if (shopBrand == null)
      {
        return TypedResults.BadRequest(new Response<Shop> { ErrorMessage = "Selected shop brand does not exists" });
      }
      var shop = mapper.Map<Shop>(shopDTO);
      shop.ShopBrand = shopBrand;
      var shopId = await dataAccessHelper.CreateAsync(shop);
      if (shopId == null || shopId <= 0)
      {
        TypedResults.Problem("Error during creating shop");
      }
      shop.Id = (int)shopId!;
      return TypedResults.Ok(new Response<Shop> { DataModel = shop });
    }

    private static async Task<IResult> UpdateShop(IDataAccessHelper dataAccessHelper, IMapper mapper, ShopDTO shopDTO)
    {
      if (shopDTO == null || shopDTO.Id <= 0 || shopDTO.ShopBrandId <= 0)
      {
        return TypedResults.BadRequest(new Response<Shop> { ErrorMessage = "Invalid data" });
      }
      var shopBrand = await dataAccessHelper.GetAsync<ShopBrand>(shopDTO.ShopBrandId);
      if (shopBrand == null)
      {
        return TypedResults.BadRequest(new Response<Shop> { ErrorMessage = "Selected shop brand does not exists" });
      }
      var shop = mapper.Map<Shop>(shopDTO);
      shop.ShopBrand = shopBrand;
      var result = await dataAccessHelper.UpdateAsync(shop);
      if (!result)
      {
        TypedResults.Problem("Error during updating shop");
      }
      return TypedResults.Ok(new Response<Shop> { DataModel = shop });
    }

    private static async Task<IResult> RemoveShop(IDataAccessHelper dataAccessHelper, Shop shop)
    {
      await dataAccessHelper.DeleteAsync(shop);
      return TypedResults.Ok(new Response<Shop>());
    }
  }
}
