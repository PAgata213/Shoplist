using ShopList.Shared.DataModels.DTOs;

namespace ShopList.Client.Interfaces
{
	public interface IProductsPricingService
	{
		Task<IEnumerable<ProductPricingDTO>> GetProductsPricingAsync();
		Task<ProductPricingDTO> GetProductPricingAsync(int id);
		Task<ProductPricingDTO> GetProductPricingForShopAndProductAsync(int shopId, int productId);
		Task<ProductPricingDTO> CreateProductPricingAsync(ProductPricingDTO productPricingDTO);
		Task<ProductPricingDTO> UpdateProductPricingAsync(ProductPricingDTO productPricingDTO);
		Task<bool> RemoveProductPricingAsync(ProductPricingDTO productPricingDTO);
	}
}