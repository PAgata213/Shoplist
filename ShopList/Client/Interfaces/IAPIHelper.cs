using Newtonsoft.Json;
using ShopList.Shared.HTTP;
using System.Net.Http;

namespace ShopList.Client.Interfaces
{
  public interface IAPIHelper
  {
    Task<Response<TResponse>> GetAsync<TResponse>(string apiEndpoint) where TResponse : class;
    Task<Response<TResponse>> GetAsync<TResponse>(string apiEndpoint, int id) where TResponse : class;
    Task<Response<TResponse>> PostAsync<TResponse, TModel>(string apiEndpoint, TModel model) where TResponse : class where TModel : class;
    Task<Response<TResponse>> PostAsync<TResponse>(string apiEndpoint, int id) where TResponse : class;
    Task<Response<TResponse>> PutAsync<TResponse, TValue>(string apiEndpoint, TValue model) where TResponse : class where TValue : class;
  }
}
