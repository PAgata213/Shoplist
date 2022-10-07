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

    public async Task<IEnumerable<ListOfProductsToBuy>> GetProductsToBuyAsync()
    {
      var content = await _apiHelper.GetAsync<IEnumerable<ListOfProductsToBuy>>(ShopList.Shared.APIAdressess.GetProductsLists);
      return content.DataModel ?? Enumerable.Empty<ListOfProductsToBuy>();
    }

    public async Task<ListOfProductsToBuy?> GetProductsToBuyAsync(int id)
    {
      var content = await _apiHelper.GetAsync<ListOfProductsToBuy>(string.Format(ShopList.Shared.APIAdressess.GetProductsList, id));
      return content.DataModel;
    }

    public async Task<ListOfProductsToBuy> CreateProductsToBuyAsync(ListOfProductsToBuyDTO listOfProductsToBuyDTO)
    {
      var result = await _apiHelper.PostAsync<ListOfProductsToBuy, ListOfProductsToBuyDTO>(ShopList.Shared.APIAdressess.CreateProductsList, listOfProductsToBuyDTO);
      if (!result.IsSuccessStatusCode)
      {
        throw new Exception(result?.ErrorMessage ?? result!.StatusCode.ToString());
      }

      return result!.DataModel!;
    }

    public async Task<Product> UpdateProductsToBuyAsync(ListOfProductsToBuyDTO listOfProductsToBuyDTO)
    {
      var result = await _apiHelper.PutAsync<Product, ListOfProductsToBuyDTO>(ShopList.Shared.APIAdressess.UpdateProductsList, listOfProductsToBuyDTO);
      if (!result.IsSuccessStatusCode)
      {
        throw new Exception(result?.ErrorMessage ?? result!.StatusCode.ToString());
      }

      return result!.DataModel!;
    }

    public async Task<bool> RemoveProductsToBuyAsync(ListOfProductsToBuyDTO listOfProductsToBuyDTO)
    {
      var result = await _apiHelper.PostAsync<ListOfProductsToBuyDTO, ListOfProductsToBuyDTO>(ShopList.Shared.APIAdressess.RemoveProductsList, listOfProductsToBuyDTO);
      return result.IsSuccessStatusCode;
    }

    public async Task<bool> AddProductToProductsListAsync(int listId, int productId)
    {
      var result = await _apiHelper.PostAsync<ListOfProductsToBuyDTO>(ShopList.Shared.APIAdressess.AddProductToList, listId, productId);
      return result.IsSuccessStatusCode;
    }

    public async Task<bool> RemoveProductToProductsListAsync(int listId, int productId)
    {
      var result = await _apiHelper.PostAsync<ListOfProductsToBuyDTO>(ShopList.Shared.APIAdressess.RemoveProductFromList, listId, productId);
      return result.IsSuccessStatusCode;
    }
  }
}
