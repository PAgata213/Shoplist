using Newtonsoft.Json;
using ShopList.Client.Helpers;
using ShopList.Client.Interfaces;
using ShopList.Shared.DataModels.DTOs;
using ShopList.Shared.DataModels.ShopList;

namespace ShopList.Client.Services
{
  public class ShopBrandsService : IShopBrandsService
  {
    private readonly IAPIHelper _apiHelper;

    public ShopBrandsService(IAPIHelper apiHelper)
    {
      _apiHelper = apiHelper;
    }

    public async Task<IEnumerable<ShopBrand>> GetShopBrandsAsync()
    {
      var result = await _apiHelper.GetAsync<IEnumerable<ShopBrand>>(ShopList.Shared.APIAdressess.GetShopBrands);
      if (!result.IsSuccessStatusCode)
      {
        return Enumerable.Empty<ShopBrand>();
      }

      return result.DataModel ?? Enumerable.Empty<ShopBrand>();
    }

    public async Task<ShopBrand> GetShopBrandAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task CreateShopBrandAsync(ShopDTO shopDTO)
    {
      throw new NotImplementedException();
    }

    public Task RemoveShopBrandAsync(Shop shop)
    {
      throw new NotImplementedException();
    }
  }
}
