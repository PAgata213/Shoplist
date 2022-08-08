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
    Task<IEnumerable<T>> Get<T>() where T : class;

    Task<T?> Get<T>(int id) where T : EntityModel;

    Task<int?> Create<T>(T model) where T : EntityModel;

    Task<bool> Update<T>(T model) where T : EntityModel;

    Task Delete<T>(int id) where T : EntityModel;

    Task Delete<T>(T model) where T : EntityModel;
  }
}
