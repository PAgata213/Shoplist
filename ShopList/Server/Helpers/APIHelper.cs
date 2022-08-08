using ShopList.Server.API;
using ShopList.Server.API.Authentication;

namespace ShopList.Server.Helpers;

public static class APIHelper
{
  public static void RegisterAllAPI(this WebApplication app)
  {
    app.RegisterAccountsAPI();
    app.RegisterItemsAPI();
  }
}
