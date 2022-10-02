using AutoMapper;
using ShopList.Client.Interfaces;
using ShopList.Shared.DataModels.DTOs;
using ShopList.Shared.DataModels.ShopList;

namespace ShopList.Client.Services
{
  public class ProductsService : IProductsService
  {
    private readonly IAPIHelper _apiHelper;
    private readonly IMapper _mapper;

    public ProductsService(IAPIHelper apiHelper, IMapper mapper)
    {
      _apiHelper = apiHelper;
      _mapper = mapper;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
      var content = await _apiHelper.GetAsync<IEnumerable<Product>>(ShopList.Shared.APIAdressess.GetProductss);
      return content.DataModel ?? Enumerable.Empty<Product>();
    }

    public async Task<Product?> GetProductAsync(int id)
    {
      var content = await _apiHelper.GetAsync<Product>(string.Format(ShopList.Shared.APIAdressess.GetProduct, id));
      return content.DataModel;
    }

    public async Task<Product> CreateProductAsync(ProductDTO productDTO)
    {
      var result = await _apiHelper.PostAsync<Product, ProductDTO>(ShopList.Shared.APIAdressess.CreateProduct, productDTO);
      if (!result.IsSuccessStatusCode)
      {
        throw new Exception(result?.ErrorMessage ?? result!.StatusCode.ToString());
      }

      return result!.DataModel!;
    }

    public async Task<Product> UpdateProductAsync(ProductDTO productDTO)
    {
      var result = await _apiHelper.PutAsync<Product, ProductDTO>(ShopList.Shared.APIAdressess.UpdateProduct, productDTO);
      if (!result.IsSuccessStatusCode)
      {
        throw new Exception(result?.ErrorMessage ?? result!.StatusCode.ToString());
      }

      return result!.DataModel!;
    }

    public async Task<bool> RemoveProductAsync(Product shop)
    {
      var result = await _apiHelper.PostAsync<Product, Product>(ShopList.Shared.APIAdressess.RemoveProduct, shop);
      return result.IsSuccessStatusCode;
    }
  }
}
