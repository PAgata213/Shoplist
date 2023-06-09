﻿using Newtonsoft.Json;
using ShopList.Client.Interfaces;
using ShopList.Shared.DataModels.ShopList;
using ShopList.Shared.HTTP;
using System.Net.Http;
using System.Net.Http.Json;

namespace ShopList.Client.Helpers
{
  public class APIHelper : IAPIHelper
  {
    private readonly HttpClient _httpClient;

    public APIHelper(HttpClient httpClient)
    {
      ArgumentNullException.ThrowIfNull(httpClient);

      _httpClient = httpClient;
    }

    public async Task<Response<TResponse>> GetAsync<TResponse>(string apiEndpoint) where TResponse : class
    {
      var response = await _httpClient.GetAsync(apiEndpoint);
      return await ProcessData<TResponse>(response);
    }

    public async Task<Response<TResponse>> GetAsync<TResponse>(string apiEndpoint, Dictionary<string, object> parameters) where TResponse : class
    {
      var url = FormatAPIAdress(apiEndpoint, parameters);
      var response = await _httpClient.GetAsync(url);
      return await ProcessData<TResponse>(response);
    }

    public async Task<Response<TResponse>> PostAsync<TResponse, TModel>(string apiEndpoint, TModel model) where TResponse : class where TModel : class
    {
      var response = await _httpClient.PostAsJsonAsync(apiEndpoint, model);
      return await ProcessData<TResponse>(response);
    }

    public async Task<Response<TResponse>> PostAsync<TResponse>(string apiEndpoint, Dictionary<string, object> parameters) where TResponse : class
    {
      var url = FormatAPIAdress(apiEndpoint, parameters);
      var response = await _httpClient.PostAsync(url, null);
      return await ProcessData<TResponse>(response);
    }

    public async Task<Response<TResponse>> PutAsync<TResponse, TValue>(string apiEndpoint, TValue model) where TResponse : class where TValue : class
    {
      var response = await _httpClient.PutAsJsonAsync(apiEndpoint, model);
      return await ProcessData<TResponse>(response);
    }

    private async Task<Response<T>> ProcessData<T>(HttpResponseMessage response) where T : class
    {
      if(!response.IsSuccessStatusCode)
      {
        new Response<T> { ErrorMessage = "No data has ben returned" };
      }
      var content = await response.Content.ReadAsStringAsync();
      var contentData = JsonConvert.DeserializeObject<Response<T>>(content);
      if (contentData == null)
      {
        contentData = new Response<T> 
        { 
          ErrorMessage = "No data has ben returned", 
          StatusCode = response.StatusCode 
        };
      }
      contentData!.StatusCode = response.StatusCode;
      return contentData;
    }

    private string FormatAPIAdress(string apiAdress, Dictionary<string, object> parameters)
      => parameters.Aggregate(apiAdress, (s, k) => s.Replace($"{{{k.Key}}}", k.Value.ToString()));
  }
}
