using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ShopList.Shared.DataModels.Authentication;
using ShopList.Shared.DataModels.ShopList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ShopList.DataAccess.DataContexts
{
  public class AppDbContext : IdentityDbContext<IdentityUserModel>
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      var cascadeFKs = builder.Model.GetEntityTypes()
          .SelectMany(t => t.GetForeignKeys())
          .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

      foreach (var fk in cascadeFKs)
      {
        fk.DeleteBehavior = DeleteBehavior.Restrict;
      }

      base.OnModelCreating(builder);
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<ShopBrand> ShopBrands { get; set; }
    public DbSet<Shop> Shops { get; set; }
  }
}
