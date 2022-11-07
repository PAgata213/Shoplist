using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using ShopList.Client.Helpers;
using ShopList.Client.Interfaces;
using ShopList.Server;
using ShopList.Shared.DataModels.ShopList;
using ShopList.Shared.HTTP;

namespace ShopList.Server.Tests
{
  public class ShopsAPITests
  {
    private readonly HttpClient _client;
    private readonly IAPIHelper _apiHelper;

    public ShopsAPITests()
    {
      var appFactory = new WebApplicationFactory<Program>();
      _client = appFactory.CreateDefaultClient();
      _apiHelper = new APIHelper(_client);
    }

    [Fact]
    public async Task Test1()
    {
      var result = await _apiHelper.GetAsync<IEnumerable<Shop>>(ShopList.Shared.APIAdressess.GetShops);

      result.IsSuccessStatusCode.Should().Be(true);
    }
  }
}