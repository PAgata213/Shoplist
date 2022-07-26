using Microsoft.EntityFrameworkCore;
using ShopList.DataAccess.DataContexts;

namespace ShopList.Server.ServerHelpers
{
  public static class DBHelper
  {
    public static WebApplication MigrateDatabase(this WebApplication app)
    {
      using (var scope = app.Services.CreateScope())
      {
        using (var appContext = scope.ServiceProvider.GetRequiredService<AppDbContext>())
        {
          try
          {
            if (appContext.Database.GetPendingMigrations().Any())
            {
              appContext.Database.Migrate();
            }
          }
          catch (Exception ex)
          {
            throw;
          }
        }
      }
      return app;
    }
  }
}
