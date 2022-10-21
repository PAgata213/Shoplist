using ShopList.Client.Interfaces;
using ShopList.Shared.DataModels.DTOs;
using ShopList.Shared.DataModels.ShopList;

namespace ShopList.Client.Services
{
  public class ShopItemsToBuyService : IShopItemsToBuyService
  {
    private readonly IAPIHelper _apiHelper;

    public ShopItemsToBuyService(IAPIHelper apiHelper)
    {
      _apiHelper = apiHelper;
    }

    public async Task<IEnumerable<ListOfProductsToBuyDTO>> GetListOfProductsToBuyAsync()
    {
      var content = await _apiHelper.GetAsync<IEnumerable<ListOfProductsToBuyDTO>>(ShopList.Shared.APIAdressess.GetProductsLists);
      return content.DataModel ?? Enumerable.Empty<ListOfProductsToBuyDTO>();
    }

    public async Task<ListOfProductsToBuyDTO?> GetListOfProductsToBuyAsync(int id, bool withProducts = true)
    {
      var content = await _apiHelper.GetAsync<ListOfProductsToBuyDTO>(ShopList.Shared.APIAdressess.GetProductsList, 
        new()
        {
          { "id", id },
          { "withProducts", withProducts }
        });
      return content.DataModel;
    }

    public async Task<ListOfProductsToBuyDTO> CreateListOfProductsToBuyAsync(ListOfProductsToBuyDTO listOfProductsToBuyDTO)
    {
      var result = await _apiHelper.PostAsync<ListOfProductsToBuyDTO, ListOfProductsToBuyDTO>(ShopList.Shared.APIAdressess.CreateProductsList, listOfProductsToBuyDTO);
      if (!result.IsSuccessStatusCode)
      {
        throw new Exception(result?.ErrorMessage ?? result!.StatusCode.ToString());
      }

      return result!.DataModel!;
    }

    public async Task<Product> UpdateListOfProductsToBuyAsync(ListOfProductsToBuyDTO listOfProductsToBuyDTO)
    {
      var result = await _apiHelper.PutAsync<Product, ListOfProductsToBuyDTO>(ShopList.Shared.APIAdressess.UpdateProductsList, listOfProductsToBuyDTO);
      if (!result.IsSuccessStatusCode)
      {
        throw new Exception(result?.ErrorMessage ?? result!.StatusCode.ToString());
      }

      return result!.DataModel!;
    }

    public async Task<bool> RemoveListOfProductsToBuyAsync(ListOfProductsToBuyDTO listOfProductsToBuyDTO)
    {
      var result = await _apiHelper.PostAsync<ListOfProductsToBuyDTO, ListOfProductsToBuyDTO>(ShopList.Shared.APIAdressess.RemoveProductsList, listOfProductsToBuyDTO);
      return result.IsSuccessStatusCode;
    }

    public async Task<bool> AddProductToProductsListAsync(int listId, int productId)
    {
      var result = await _apiHelper.PostAsync<ListOfProductsToBuyDTO>(ShopList.Shared.APIAdressess.AddProductToList, 
        new()
        {
          { "listId", listId },
          { "productId", productId }
        });
      return result.IsSuccessStatusCode;
    }

    public async Task<bool> RemoveProductFromProductsListAsync(int listId, int productId)
    {
      var result = await _apiHelper.PostAsync<ListOfProductsToBuyDTO>(ShopList.Shared.APIAdressess.RemoveProductFromList, 
        new()
        {
          { "listId", listId },
          { "productId", productId }
        });
      return result.IsSuccessStatusCode;
    }
  }
}
