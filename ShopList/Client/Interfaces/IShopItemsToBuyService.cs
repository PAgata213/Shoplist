using ShopList.Shared.DataModels.DTOs;
using ShopList.Shared.DataModels.ShopList;

namespace ShopList.Client.Interfaces
{
  public interface IShopItemsToBuyService
  {
    Task<bool> AddProductToProductsListAsync(int listId, int productId);
    Task<ListOfProductsToBuyDTO> CreateListOfProductsToBuyAsync(ListOfProductsToBuyDTO listOfProductsToBuyDTO);
    Task<IEnumerable<ListOfProductsToBuyDTO>> GetListOfProductsToBuyAsync();
    Task<ListOfProductsToBuyDTO?> GetListOfProductsToBuyAsync(int id, bool withProducts = true);
    Task<bool> RemoveListOfProductsToBuyAsync(ListOfProductsToBuyDTO listOfProductsToBuyDTO);
    Task<bool> RemoveProductFromProductsListAsync(int listId, int productId);
    Task<Product> UpdateListOfProductsToBuyAsync(ListOfProductsToBuyDTO listOfProductsToBuyDTO);
  }
}
