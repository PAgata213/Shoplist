using ShopList.Client.DataModels;
using ShopList.Shared.DataModels.DTOs;
using ShopList.Shared.DataModels.ShopList;

namespace ShopList.Client.Interfaces
{
	public interface IProductsPricingService
	{
		Task<IEnumerable<ProductPricingDTO>> GetProductsPricingAsync();
		Task<IEnumerable<ProductPricingDTO>> GetProductsPricingAsync(IEnumerable<int> productsId);
		Task<ProductPricingDTO> GetProductPricingAsync(int id);
		Task<ProductPricingDTO> GetProductPricingForShopAndProductAsync(int shopId, int productId);
		Task<ProductPricingDTO> CreateProductPricingAsync(ProductPricingDTO productPricingDTO);
		Task<ProductPricingDTO> UpdateProductPricingAsync(ProductPricingDTO productPricingDTO);
		Task<bool> RemoveProductPricingAsync(ProductPricingDTO productPricingDTO);
		Task<IEnumerable<ProductForPricing>> GeneratePricingsForProducts(IEnumerable<int>? productsId = null, IEnumerable<Product>? products = null, IEnumerable<Shop>? shops = null);
	}
}