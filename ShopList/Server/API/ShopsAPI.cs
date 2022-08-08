using AutoMapper;
using ShopList.Shared.DataModels.DTOs;
using ShopList.Shared.DataModels.ShopList;
using ShopList.Shared.Interfaces;

namespace ShopList.Server.API
{
  public static class ShopsAPI
  {
    public static void RegisterShopsAPI(this WebApplication app)
    {
      app.MapGet("/shops", GetShops);
      app.MapGet("/shops/{id}", GetShop);
      app.MapPut("/shops/create", CreateShop);
      app.MapPost("/shops/remove/{id}", RemoveShop);
    }

    private static async Task<IEnumerable<Shop>> GetShops(IDataAccessHelper dataAccessHelper)
      => await dataAccessHelper.GetAsync<Shop>();

    private static async Task<Shop?> GetShop(IDataAccessHelper dataAccessHelper, int id)
      => await dataAccessHelper.GetAsync<Shop>(id);

    private static async Task<IResult> CreateShop(IDataAccessHelper dataAccessHelper, IMapper mapper, ShopDTO shopDTO)
    {
      if (shopDTO == null || shopDTO.ShopBrand == null || shopDTO.ShopBrand.Id <= 0)
      {
        return TypedResults.BadRequest();
      }
      var shopBrand = await dataAccessHelper.GetAsync<ShopBrand>(shopDTO.ShopBrand.Id);
      if (shopBrand == null)
      {
        return TypedResults.BadRequest("Selected shop brand does not exists");
      }
      var shop = mapper.Map<Shop>(shopDTO);
      shop.ShopBrand = shopBrand;
      var shopId = await dataAccessHelper.CreateAsync(shop);
      if (shopId == null || shopId <= 0)
      {
        TypedResults.Problem();
      }
      return TypedResults.Ok(new { ShopId = shopId });
    }

    private static async Task<IResult> RemoveShop(IDataAccessHelper dataAccessHelper, int id)
    {
      await dataAccessHelper.DeleteAsync<Shop>(id);
      return TypedResults.Ok();
    }
  }
}
