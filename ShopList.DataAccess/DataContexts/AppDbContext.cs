using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ShopList.Shared.DataModels.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList.DataAccess.DataContexts
{
  public class AppDbContext : IdentityDbContext<IdentityUserModel>
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
  }
}
