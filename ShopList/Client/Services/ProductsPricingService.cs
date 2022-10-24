using ShopList.Client.Interfaces;
using ShopList.Shared.DataModels.DTOs;
using ShopList.Shared.DataModels.ShopList;

namespace ShopList.Client.Services
{
    public class ProductsPricingService : IProductsPricingService
	{
		private readonly IAPIHelper _apiHelper;

		public ProductsPricingService(IAPIHelper apiHelper)
		{
			_apiHelper = apiHelper;
		}

		public async Task<IEnumerable<ProductPricingDTO>> GetProductsPricingAsync()
		{
			var content = await _apiHelper.GetAsync<IEnumerable<ProductPricingDTO>>(ShopList.Shared.APIAdressess.GetProductsPricing);
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
	}
}
