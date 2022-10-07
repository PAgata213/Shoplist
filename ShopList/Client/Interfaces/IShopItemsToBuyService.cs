using ShopList.Shared.DataModels.DTOs;
using ShopList.Shared.DataModels.ShopList;

namespace ShopList.Client.Interfaces
{
  public interface IShopItemsToBuyService
  {
    Task<bool> AddProductToProductsListAsync(int listId, int productId);
    Task<ListOfProductsToBuy> CreateProductsToBuyAsync(ListOfProductsToBuyDTO listOfProductsToBuyDTO);
    Task<IEnumerable<ListOfProductsToBuy>> GetProductsToBuyAsync();
    Task<ListOfProductsToBuy?> GetProductsToBuyAsync(int id);
    Task<bool> RemoveProductsToBuyAsync(ListOfProductsToBuyDTO listOfProductsToBuyDTO);
    Task<bool> RemoveProductToProductsListAsync(int listId, int productId);
    Task<Product> UpdateProductsToBuyAsync(ListOfProductsToBuyDTO listOfProductsToBuyDTO);
  }
}
