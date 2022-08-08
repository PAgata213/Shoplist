using AutoMapper;
using ShopList.DataAccess.DataAccess;
using ShopList.Shared.DataModels.DTOs;
using ShopList.Shared.DataModels.ShopList;
using ShopList.Shared.Interfaces;

namespace ShopList.Server.API
{
  public static class ShopBrandsAPI
  {
    public static void RegisterShopBrandsAPI(this WebApplication app)
    {
      app.MapGet("/shopbrands", GetShopBrands);
      app.MapGet("/shopbrands/{id}", GetShopBrand);
      app.MapPut("/shopbrands/create", CreateShopBrand);
      app.MapPost("/shopbrands/remove/{id}", RemoveShopBrand);     
    }

    private static async Task<IEnumerable<ShopBrand>> GetShopBrands(IDataAccessHelper dataAccessHelper)
    {
      return await dataAccessHelper.GetAsync<ShopBrand>();
    }

    private static async Task<ShopBrand?> GetShopBrand(IDataAccessHelper dataAccessHelper, int id)
    {
      return await dataAccessHelper.GetAsync<ShopBrand>(id);
    }

    private static async Task<IResult> CreateShopBrand(IDataAccessHelper dataAccessHelper, IMapper mapper, ShopBrandDTO shopBrandDTO)
    {
      var shopBrand = mapper.Map<ShopBrand>(shopBrandDTO);
      var shopBrandId = await dataAccessHelper.CreateAsync(shopBrand);
      if (shopBrandId == null || shopBrandId <= 0)
      {
        TypedResults.Problem();
      }
      return TypedResults.Ok(new { ShopBrandId = shopBrandId });
    }

    private static async Task<IResult> RemoveShopBrand(IDataAccessHelper dataAccessHelper, int id)
    {
      await dataAccessHelper.DeleteAsync<ShopBrand>(id);
      return TypedResults.Ok();
    }
  }
}
