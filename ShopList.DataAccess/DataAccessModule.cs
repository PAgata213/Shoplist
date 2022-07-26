using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopList.DataAccess.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList.DataAccess
{
  public static class DataAccessModule
  {
    public static void AddShopListDbContexts(this IServiceCollection services, string cnnString)
    {
      services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(cnnString));
    }
  }
}
