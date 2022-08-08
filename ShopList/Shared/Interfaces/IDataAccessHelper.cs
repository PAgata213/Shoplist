using Microsoft.EntityFrameworkCore;
using ShopList.Shared.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList.Shared.Interfaces
{
  public interface IDataAccessHelper
  {
    Task<IEnumerable<T>> GetAsync<T>() where T : class;

    Task<T?> GetAsync<T>(int id) where T : EntityModel;

    Task<int?> CreateAsync<T>(T model) where T : EntityModel;

    Task<bool> UpdateAsync<T>(T model) where T : EntityModel;

    Task DeleteAsync<T>(int id) where T : EntityModel;

    Task DeleteAsync<T>(T model) where T : EntityModel;
  }
}
