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

    public const string RegisterUser = "/api/accounts/registration";
    public const string LoginUser = "/api/accounts/login";

    #endregion

    #region ShopBranch API

    /// <summary>
    /// Get all ShopBrands
    /// Request Method : GET
    /// </summary>
    public const string GetShopBrands = "/api/shopbrands";
    /// <summary>
    /// Get specified ShopBrand
    /// Request Method : GET
    /// </summary>
    public const string GetShopBrand = "/api/shopbrands/{id}";
    /// <summary>
    /// Create new ShopBrand from given model
    /// Request Method : POST
    /// </summary>
    public const string CreateShopBrand = "/api/shopbrands/create";
    /// <summary>
    /// Update specified ShopBrand from given model
    /// Request Method : PUT
    /// </summary>
    public const string UpdateShopBrand = "/api/shopbrands/create";
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
    public const string GetShops = "/api/shops";
    /// <summary>
    /// Get specified Shop
    /// Request Method : GET
    /// </summary>
    public const string GetShop = "/api/shops/{id}";
    /// <summary>
    /// Create new Shop from given model
    /// Request Method : POST
    /// </summary>
    public const string CreateShop = "/api/shops/create";
    /// <summary>
    /// Update specified Shop from given model
    /// Request Method : PUT
    /// </summary>
    public const string UpdateShop = "/api/shops/update";
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
    public const string GetProductss = "/api/shops/items";
    /// <summary>
    /// Get specified ShopItem
    /// Request Method : GET
    /// </summary>
    public const string GetProduct = "/api/shops/items/{id}";
    /// <summary>
    /// Create new ShopItem from given model
    /// Request Method : POST
    /// </summary>
    public const string CreateProduct = "/api/shops/items/create";
    /// <summary>
    /// Update specified ShopItem from given model
    /// Request Method : PUT
    /// </summary>
    public const string UpdateProduct = "/api/shops/items/update";
    /// <summary>
    /// Remove specified ShopItem
    /// Request Method : POST
    /// </summary>
    public const string RemoveProduct = "/api/shops/items/remove/{id}";

    #endregion
  }
}
