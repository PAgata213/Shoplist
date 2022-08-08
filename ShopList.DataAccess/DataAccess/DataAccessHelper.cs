using Microsoft.EntityFrameworkCore;
using ShopList.DataAccess.DataContexts;
using ShopList.Shared.DataModels;
using ShopList.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList.DataAccess.DataAccess
{
  public class DataAccessHelper : IDataAccessHelper
  {
    private readonly AppDbContext _dbContext;

    public DataAccessHelper(AppDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<IEnumerable<T>> Get<T>() where T : class
      => await _dbContext.Set<T>().AsNoTracking().ToListAsync();

    public async Task<T?> Get<T>(int id) where T : EntityModel
      => await _dbContext.Set<T>().FindAsync(id);

    public async Task<int?> Create<T>(T model) where T : EntityModel
    {
      _dbContext.Set<T>().Add(model);
      await _dbContext.SaveChangesAsync();
      return model.Id;
    }

    public async Task<bool> Update<T>(T model) where T : EntityModel
    {
      var data = await _dbContext.Set<T>().FindAsync(model.Id);
      if (data == null)
      {
        return false;
      }
      _dbContext.Entry(data).CurrentValues.SetValues(model);
      await _dbContext.SaveChangesAsync();
      return true;
    }

    public async Task Delete<T>(T model) where T : EntityModel
    {
      await Delete<T>(model.Id);
    }

    public async Task Delete<T>(int id) where T : EntityModel
    {
      var data = await _dbContext.Set<T>().FindAsync(id);
      if (data == null)
      {
        return;
      }
      _dbContext.Set<T>().Remove(data);
      await _dbContext.SaveChangesAsync();
    }
  }
}
