using AutoMapper;
using Newtonsoft.Json;
using ShopList.Client.Interfaces;
using ShopList.Shared.DataModels.DTOs;
using ShopList.Shared.DataModels.ShopList;
using ShopList.Shared.HTTP;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace ShopList.Client.Services
{
  public class ShopsService : IShopsService
  {
    private readonly IAPIHelper _apiHelper;
    private readonly IMapper _mapper;

    public ShopsService(IAPIHelper apiHelper, IMapper mapper)
    {
      _apiHelper = apiHelper;
      _mapper = mapper;
    }

    public async Task<IEnumerable<Shop>> GetShopsAsync()
    {
      var content = await _apiHelper.GetAsync<IEnumerable<Shop>>(ShopList.Shared.APIAdressess.GetShops);
      return content.DataModel ?? Enumerable.Empty<Shop>();
    }

    public async Task<Shop?> GetShopAsync(int id)
    {
      var content = await _apiHelper.GetAsync<Shop>(String.Format(ShopList.Shared.APIAdressess.GetShop, id));
      return content.DataModel;
    }

    public async Task<Shop> CreateShopAsync(ShopDTO shopDTO)
    {
      var result = await _apiHelper.PostAsync<Shop, ShopDTO>(ShopList.Shared.APIAdressess.CreateShop, shopDTO);
      if (!result.IsSuccessStatusCode)
      {
        throw new Exception(result?.ErrorMessage ?? result!.StatusCode.ToString());
      }

      return result!.DataModel!;
    }

    public async Task<Shop> UpdateShopAsync(ShopDTO shopDTO)
    {
      var result = await _apiHelper.PutAsync<Shop, ShopDTO>(ShopList.Shared.APIAdressess.UpdateShop, shopDTO);
      if (!result.IsSuccessStatusCode)
      {
        throw new Exception(result?.ErrorMessage ?? result!.StatusCode.ToString());
      }

      return result!.DataModel!;
    }

    public async Task<bool> RemoveShopAsync(Shop shop)
    {
      var result = await _apiHelper.PostAsync<Shop, Shop>(ShopList.Shared.APIAdressess.RemoveShop, shop);
      return result.IsSuccessStatusCode;
    }
  }
}
