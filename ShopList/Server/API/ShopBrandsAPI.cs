using AutoMapper;
using ShopList.DataAccess.DataAccess;
using ShopList.Shared.DataModels.DTOs;
using ShopList.Shared.DataModels.ShopList;
using ShopList.Shared.HTTP;
using ShopList.Shared.Interfaces;

namespace ShopList.Server.API
{
  public static class ShopBrandsAPI
  {
    public static void RegisterShopBrandsAPI(this WebApplication app)
    {
      app.MapGet(ShopList.Shared.APIAdressess.GetShopBrands, GetShopBrands);
      app.MapGet(ShopList.Shared.APIAdressess.GetShopBrand, GetShopBrand);
      app.MapPost(ShopList.Shared.APIAdressess.CreateShopBrand, CreateShopBrand);
      app.MapPut(ShopList.Shared.APIAdressess.UpdateShopBrand, UpdateShopBrand);
      app.MapPost(ShopList.Shared.APIAdressess.RemoveShopBrand, RemoveShopBrand);     
    }

    private static async Task<Response<IEnumerable<ShopBrand>>> GetShopBrands(IDataAccessHelper dataAccessHelper)
    {
      var response = new Response<IEnumerable<ShopBrand>>();
      response.DataModel = await dataAccessHelper.GetAsync<ShopBrand>();
      return response;
    }

    private static async Task<Response<ShopBrand>> GetShopBrand(IDataAccessHelper dataAccessHelper, int id)
    {
      var response = new Response<ShopBrand>();
      response.DataModel = await dataAccessHelper.GetAsync<ShopBrand>(id);
      return response;
    }

    private static async Task<IResult> CreateShopBrand(IDataAccessHelper dataAccessHelper, IMapper mapper, ShopBrandDTO shopBrandDTO)
    {
      var shopBrand = mapper.Map<ShopBrand>(shopBrandDTO);
      var shopBrandId = await dataAccessHelper.CreateAsync(shopBrand);
      if (shopBrandId == null || shopBrandId <= 0)
      {
        TypedResults.Problem("Error while creating ShopBrand");
      }
      return TypedResults.Ok(new Response<ShopBrand> { DataModel = shopBrand });
    }

    private static async Task<IResult> UpdateShopBrand(IDataAccessHelper dataAccessHelper, IMapper mapper, ShopBrandDTO shopBrandDTO)
    {
      var shopBrand = mapper.Map<ShopBrand>(shopBrandDTO);
      var result = await dataAccessHelper.UpdateAsync(shopBrand);
      if (result)
      {
        TypedResults.Problem("Error while updating ShopBrand");
      }
      return TypedResults.Ok(new Response<ShopBrand> { DataModel = shopBrand });
    }

    private static async Task<IResult> RemoveShopBrand(IDataAccessHelper dataAccessHelper, int id)
    {
      await dataAccessHelper.DeleteAsync<ShopBrand>(id);
      return TypedResults.Ok(new Response<string>());
    }
  }
}
