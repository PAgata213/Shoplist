using ShopList.Shared.DataModels.DTOs;
using ShopList.Shared.DataModels.ShopList;

namespace ShopList.Client.Interfaces
{
  public interface IShopItemsToBuyService
  {
    Task<IEnumerable<ListOfProductsToBuyDTO>> GetListOfProductsToBuyAsync();
    Task<ListOfProductsToBuyDTO?> GetListOfProductsToBuyAsync(int id, bool withProducts = true);
    Task<ListOfProductsToBuyDTO> CreateListOfProductsToBuyAsync(ListOfProductsToBuyDTO listOfProductsToBuyDTO);
    Task<Product> UpdateListOfProductsToBuyAsync(ListOfProductsToBuyDTO listOfProductsToBuyDTO);
    Task<bool> RemoveListOfProductsToBuyAsync(ListOfProductsToBuyDTO listOfProductsToBuyDTO);
    Task<bool> RemoveProductFromProductsListAsync(int listId, int productId);
    Task<bool> AddProductToProductsListAsync(int listId, int productId, double amount);
  }
}
