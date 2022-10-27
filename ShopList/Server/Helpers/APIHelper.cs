using ShopList.Server.API;
using ShopList.Server.API.Authentication;
using ShopList.Shared.Interfaces;

namespace ShopList.Server.Helpers;

public static class APIHelper
{
  public static void RegisterAllAPI(this WebApplication app)
  {
    app.RegisterAccountsAPI();
    app.RegisterItemsAPI();
    app.RegisterShopBrandsAPI();
    app.RegisterShopsAPI();
    app.RegisterShopListAPI();
    app.RegisterProductsPricingAPI();
  }
}
