using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList.Shared
{
  public static class APIAdressess
  {
    #region Accounts API

    public const string RegisterUser = "/api/accounts/registration/";
    public const string LoginUser = "/api/accounts/login/";

    #endregion

    #region ShopBranch API

    /// <summary>
    /// Get all ShopBrands
    /// Request Method : GET
    /// </summary>
    public const string GetShopBrands = "/api/shopbrands/";
    /// <summary>
    /// Get specified ShopBrand
    /// Request Method : GET
    /// </summary>
    public const string GetShopBrand = "/api/shopbrands/{id}";
    /// <summary>
    /// Create new ShopBrand from given model
    /// Request Method : POST
    /// </summary>
    public const string CreateShopBrand = "/api/shopbrands/create/";
    /// <summary>
    /// Update specified ShopBrand from given model
    /// Request Method : PUT
    /// </summary>
    public const string UpdateShopBrand = "/api/shopbrands/update/";
    /// <summary>
    /// Remove specified ShopBrand
    /// Request Method : POST
    /// </summary>
    public const string RemoveShopBrand = "/api/shopbrands/remove/{id}";

    #endregion

    #region Shop API

    /// <summary>
    /// Get all Shops
    /// Request Method : GET
    /// </summary>
    public const string GetShops = "/api/shops/";
    /// <summary>
    /// Get specified Shop
    /// Request Method : GET
    /// </summary>
    public const string GetShop = "/api/shops/{id}";
    /// <summary>
    /// Create new Shop from given model
    /// Request Method : POST
    /// </summary>
    public const string CreateShop = "/api/shops/create/";
    /// <summary>
    /// Update specified Shop from given model
    /// Request Method : PUT
    /// </summary>
    public const string UpdateShop = "/api/shops/update/";
    /// <summary>
    /// Remove specified Shop
    /// Request Method : POST
    /// </summary>
    public const string RemoveShop = "/api/shops/remove/{id}";

    #endregion

    #region ShopItem API

    /// <summary>
    /// Get all ShopItems
    /// Request Method : GET
    /// </summary>
    public const string GetProducts = "/api/shops/items/";
    /// <summary>
    /// Get specified ShopItem
    /// Request Method : GET
    /// </summary>
    public const string GetProduct = "/api/shops/items/{id}";
    /// <summary>
    /// Get specified ShopItem
    /// Request Method : POST
    /// </summary>
    public const string GetShopItemsWithGivenId = "/api/shops/items/many/";
    /// <summary>
    /// Create new ShopItem from given model
    /// Request Method : POST
    /// </summary>
    public const string CreateProduct = "/api/shops/items/create/";
    /// <summary>
    /// Update specified ShopItem from given model
    /// Request Method : PUT
    /// </summary>
    public const string UpdateProduct = "/api/shops/items/update/";
    /// <summary>
    /// Remove specified ShopItem
    /// Request Method : POST
    /// </summary>
    public const string RemoveProduct = "/api/shops/items/remove/{id}";

    #endregion

    #region Product List API

    /// <summary>
    /// Get all ProductsLists
    /// Request Method : GET
    /// </summary>
    public const string GetProductsLists = "/api/shoplists/";
    /// <summary>
    /// Get specified ProductsList
    /// Request Method : GET
    /// </summary>
    public const string GetProductsList = "/api/shoplists/{id}/{withProducts}";
    /// <summary>
    /// Create new ProductsList from given model
    /// Request Method : POST
    /// </summary>
    public const string CreateProductsList = "/api/shoplists/create/";
    /// <summary>
    /// Update specified ProductsList from given model
    /// Request Method : PUT
    /// </summary>
    public const string UpdateProductsList = "/api/shoplists/update/";
    /// <summary>
    /// Remove specified ProductsList
    /// Request Method : POST
    /// </summary>
    public const string RemoveProductsList = "/api/shoplists/remove/";
    /// <summary>
    /// Add given Product to ProductsList
    /// Request Method : POST
    /// </summary>
    public const string AddProductToList = "/api/shoplists/items/add/{ListId}/{ProductId}/{Amount}";
    /// <summary>
    /// Remove given Product from ProductsList
    /// Request Method : POST
    /// </summary>
    public const string RemoveProductFromList = "/api/shoplists/items/remove/{ListId}/{ProductId}";
    #endregion

    #region ProductsPricing
    
    private const string _productPricingPath = "/api/shops/items/pricing";
    /// <summary>
    /// Get all Products pricing
    /// Request Method : GET
    /// </summary>
    public const string GetProductsPricing = $"{_productPricingPath}/";
    /// <summary>
    /// Get specified Product pricing
    /// Request Method : POST
    /// </summary>
    public const string GetProductPricingForSelectedProducts = $"{_productPricingPath}/many/";
    /// <summary>
    /// Get specified Product pricing
    /// Request Method : GET
    /// </summary>
    public const string GetProductPricing = $"{_productPricingPath}/{{id}}";
    /// <summary>
    /// Get specified Product pricing
    /// Request Method : GET
    /// </summary>
    public const string GetProductPricingForShopAndProduct = $"{_productPricingPath}/{{shopId}}/{{productId}}";
    /// <summary>
    /// Create new Pricing for given product in given shop
    /// Request Method : POST
    /// </summary>
    public const string CreateProductPricing = $"{_productPricingPath}/create/";
    /// <summary>
    /// Update specified Product pricing
    /// Request Method : PUT
    /// </summary>
    public const string UpdateProductPricing = $"{_productPricingPath}/update/";
    /// <summary>
    /// Remove specified Product pricing
    /// Request Method : POST
    /// </summary>
    public const string RemoveProductPricing = $"{_productPricingPath}/remove/";
    #endregion
  }
}
