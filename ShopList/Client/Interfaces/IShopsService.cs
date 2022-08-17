using ShopList.Client.Helpers;
using ShopList.Shared.DataModels.DTOs;
using ShopList.Shared.DataModels.ShopList;

namespace ShopList.Client.Interfaces
{
  public interface IShopsService
  {
    Task<Shop?> GetShopAsync(int id);
    Task<IEnumerable<Shop>> GetShopsAsync();
    Task<Shop> CreateShopAsync(ShopDTO shopDTO);
    Task<Shop> UpdateShopAsync(ShopDTO shopDTO);
    Task<bool> RemoveShopAsync(Shop shop);
  }
}
