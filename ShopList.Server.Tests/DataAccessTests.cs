using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ShopList.DataAccess.DataAccess;
using ShopList.DataAccess.DataContexts;
using ShopList.Shared.DataModels.ShopList;
using ShopList.Shared.Interfaces;

namespace ShopList.Server.Tests
{
  public class DataAccessTests
  {
    private readonly DataAccessHelper _dataAccessHelper;

    public DataAccessTests()
    {
      AppDbContext _context;

      var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
        .UseInMemoryDatabase("DataAccessTests").Options;

      _dataAccessHelper = new DataAccessHelper(new AppDbContext(dbContextOptions));
    }


    [Fact]
    public async Task InsertData_ReturnInsertedObjectId()
    {
      //Arrange
      var shopBrand = new ShopBrand
      {
        ShopBrandName = "ShopBranName"
      };

      //Act
      var id = await _dataAccessHelper.CreateAsync<ShopBrand>(shopBrand);

      //Assert
      id.Should().BeInRange(1, int.MaxValue);
    }

    [Fact]
    public async Task InsertDataWithForeghinKey_ReturnInsertedObjectId()
    {
      //Arrange
      var shopBrand = new ShopBrand
      {
        ShopBrandName = "ShopBranName1"
      };
      var shopBrandId = await _dataAccessHelper.CreateAsync(shopBrand);

      var shop = new Shop
      {
        Address = "Address",
        City = "City",
        ZipCode = "ZipCode",
        ShopBrandId = (int)shopBrandId
      };

      //Act
      var Shopid = await _dataAccessHelper.CreateAsync(shop);

      //Assert
      Shopid.Should().BeInRange(1, int.MaxValue);
    }

    [Fact]
    public async Task UpdateData_ReturnTrue()
    {
      //Arrange
      var shopBrand = new ShopBrand
      {
        ShopBrandName = "ShopBrandName"
      };

      var shopBrandId = await _dataAccessHelper.CreateAsync<ShopBrand>(shopBrand);
      shopBrandId.Should().NotBeNull();
      shopBrandId.Should().BeInRange(1, int.MaxValue);

      //Act
      shopBrand.ShopBrandName = "ShopBrandName2";
      var updateResult = await _dataAccessHelper.UpdateAsync<ShopBrand>(shopBrand);

      var dataToTest = await _dataAccessHelper.GetAsync<ShopBrand>((int)shopBrandId);

      //Assert
      updateResult.Should().BeTrue();
      dataToTest.Should().NotBeNull();
      dataToTest!.ShopBrandName.Should().Be("ShopBrandName2");
    }
  }
}
