using ShopList.Client.DataModels;
using ShopList.Client.Interfaces;
using ShopList.Client.Pages;
using ShopList.Shared.DataModels.DTOs;
using ShopList.Shared.DataModels.ShopList;

namespace ShopList.Client.Services
{
  public class ProductsPricingService : IProductsPricingService
  {
    private readonly IAPIHelper _apiHelper;
    private readonly IProductsService _productsService;
    private readonly IShopsService _shopsService;

    public ProductsPricingService(IAPIHelper apiHelper, IProductsService productsService, IShopsService shopsService)
    {
      _apiHelper = apiHelper;
      _productsService = productsService;
      _shopsService = shopsService;
    }

    public async Task<IEnumerable<ProductPricingDTO>> GetProductsPricingAsync()
    {
      var content = await _apiHelper.GetAsync<IEnumerable<ProductPricingDTO>>(ShopList.Shared.APIAdressess.GetProductsPricing);
      return content.DataModel ?? Enumerable.Empty<ProductPricingDTO>();
    }

    public async Task<IEnumerable<ProductPricingDTO>> GetProductsPricingAsync(IEnumerable<int> productsId)
    {
      var content = await _apiHelper.PostAsync<IEnumerable<ProductPricingDTO>, ListTransferDTO<int>>(ShopList.Shared.APIAdressess.GetProductPricingForSelectedProducts, new() { List = productsId });
      return content.DataModel ?? Enumerable.Empty<ProductPricingDTO>();
    }

    public async Task<ProductPricingDTO?> GetProductPricingAsync(int id)
    {
      var content = await _apiHelper.GetAsync<ProductPricingDTO>(ShopList.Shared.APIAdressess.GetProductsPricing, new()
      {
        { "id", id }
      });
      return content.DataModel;
    }

    public async Task<ProductPricingDTO?> GetProductPricingForShopAndProductAsync(int shopId, int productId)
    {
      var content = await _apiHelper.GetAsync<ProductPricingDTO>(ShopList.Shared.APIAdressess.GetProductPricingForShopAndProduct, new()
      {
        { "shopId", shopId },
        { "productId", productId }
      });
      return content.DataModel;
    }

    public async Task<ProductPricingDTO> CreateProductPricingAsync(ProductPricingDTO productPricingDTO)
    {
      var result = await _apiHelper.PostAsync<ProductPricingDTO, ProductPricingDTO>(ShopList.Shared.APIAdressess.CreateProductPricing, productPricingDTO);
      if(!result.IsSuccessStatusCode)
      {
        throw new Exception(result?.ErrorMessage ?? result!.StatusCode.ToString());
      }

      return result!.DataModel!;
    }

    public async Task<ProductPricingDTO> UpdateProductPricingAsync(ProductPricingDTO productPricingDTO)
    {
      var result = await _apiHelper.PutAsync<ProductPricingDTO, ProductPricingDTO>(ShopList.Shared.APIAdressess.UpdateProductPricing, productPricingDTO);
      if(!result.IsSuccessStatusCode)
      {
        throw new Exception(result?.ErrorMessage ?? result!.StatusCode.ToString());
      }

      return result!.DataModel!;
    }

    public async Task<bool> RemoveProductPricingAsync(ProductPricingDTO productPricingDTO)
    {
      var result = await _apiHelper.PostAsync<ProductPricingDTO, ProductPricingDTO>(ShopList.Shared.APIAdressess.RemoveProductPricing, productPricingDTO);
      return result.IsSuccessStatusCode;
    }

    public async Task<IEnumerable<ProductForPricing>> GeneratePricingsForProducts(IEnumerable<int>? productsId = null, IEnumerable<Product>? products = null, IEnumerable<Shop>? shops = null)
    {
      if(products == null || !products.Any())
      {
        products = await _productsService.GetProductsAsync();
      }
      if(shops == null || !shops.Any())
      {
        shops = await _shopsService.GetShopsAsync();
      }
      IEnumerable<ProductPricingDTO>? pricings;
      if(productsId == null)
      {
        pricings = await GetProductsPricingAsync();
      }
      else
      {
        pricings = await GetProductsPricingAsync(productsId);
      }

      products = products.OrderBy(p => p.ProductName);
      shops = shops.OrderBy(s => s.Id);

      IEnumerable<ProductForPricing> data;

      if(!products.Any() || !shops.Any())
      {
        data = Enumerable.Empty<ProductForPricing>();
      }
      else
      {
        data = products.Select(p => new ProductForPricing
        {
          Product = p,
          InShopProductPricings = shops.Select(s => new InShopProductPricing
          {
            ShopId = s.Id,
            Price = pricings.FirstOrDefault(x => x.ProductId == p.Id && x.ShopId == s.Id)?.Price ?? 0
          })
        });
      }

      return data;
    }
  }
}
