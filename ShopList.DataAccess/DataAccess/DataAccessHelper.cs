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

    public IQueryable<T> GetAsQuerable<T>() where T : class 
      => _dbContext.Set<T>().AsQueryable<T>();

    public async Task<IEnumerable<T>> GetAsync<T>() where T : class
      => await _dbContext.Set<T>().AsNoTracking().ToListAsync();

    public async Task<T?> GetAsync<T>(int id) where T : EntityModel
      => await _dbContext.Set<T>().FindAsync(id);

    public async Task<int?> CreateAsync<T>(T model) where T : EntityModel
    {
      _dbContext.Set<T>().Add(model);
      await _dbContext.SaveChangesAsync();
      return model.Id;
    }

    public async Task<bool> UpdateAsync<T>(T model) where T : EntityModel
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

    public async Task DeleteAsync<T>(T model) where T : EntityModel
    {
      await DeleteAsync<T>(model.Id);
    }

    public async Task DeleteAsync<T>(int id) where T : EntityModel
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
