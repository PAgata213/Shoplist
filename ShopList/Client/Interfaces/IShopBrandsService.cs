using ShopList.Shared.DataModels.DTOs;
using ShopList.Shared.DataModels.ShopList;

namespace ShopList.Client.Interfaces
{
  public interface IShopBrandsService
  {
    Task<IEnumerable<ShopBrand>> GetShopBrandsAsync();
    Task<ShopBrand> GetShopBrandAsync(int id);
    Task CreateShopBrandAsync(ShopDTO shopDTO);
    Task RemoveShopBrandAsync(Shop shop);
  }
}
