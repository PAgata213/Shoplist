using ShopList.Shared.DataModels.ShopList;

namespace ShopList.Client.DataModels
{
	public class ProductForPricing
	{
		public IEnumerable<InShopProductPricing> InShopProductPricings { get; set; }
		public Product Product { get; set; }
	}
}
