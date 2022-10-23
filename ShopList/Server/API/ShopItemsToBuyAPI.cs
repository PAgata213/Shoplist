using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopList.Shared.DataModels.DTOs;
using ShopList.Shared.DataModels.ShopList;
using ShopList.Shared.HTTP;
using ShopList.Shared.Interfaces;

namespace ShopList.Server.API;

public static class ShopItemsToBuyAPI
{
  public static void RegisterShopListAPI(this WebApplication app)
  {
    app.MapGet(ShopList.Shared.APIAdressess.GetProductsLists, GetProductsLists);
    app.MapGet(ShopList.Shared.APIAdressess.GetProductsList, GetProductsList);
    app.MapPost(ShopList.Shared.APIAdressess.CreateProductsList, CreateProductsList);
    app.MapPut(ShopList.Shared.APIAdressess.UpdateProductsList, UpdateProductsList);
    app.MapPost(ShopList.Shared.APIAdressess.RemoveProductsList, RemoveProductsList);
    app.MapPost(ShopList.Shared.APIAdressess.AddProductToList, AddProductToList);
    app.MapPost(ShopList.Shared.APIAdressess.RemoveProductFromList, RemoveProductFromList);
  }

  private static async Task<Response<IEnumerable<ListOfProductsToBuyDTO>>> GetProductsLists(IMapper mapper, IDataAccessHelper dataAccessHelper)
  {
    var response = new Response<IEnumerable<ListOfProductsToBuyDTO>>();
    var data = await dataAccessHelper.GetAsync<ListOfProductsToBuy>();
    response.DataModel = data.Select(s => MapListOfProductsToBuyToDTO(mapper, s));
    return response;
  }

  private static async Task<IResult> GetProductsList(IDataAccessHelper dataAccessHelper, IMapper mapper, int id, bool withProducts = false)
  {
    if (id <= 0)
    {
      return TypedResults.BadRequest(new Response<ListOfProductsToBuyDTO>
      {
        ErrorMessage = "Selected ListOfProductsToBuy does not exists",
        StatusCode = System.Net.HttpStatusCode.BadRequest
      });
    }
    var response = new Response<ListOfProductsToBuyDTO>();
    var data = withProducts ? await dataAccessHelper.GetAsQuerable<ListOfProductsToBuy>()
                                .Include(s => s.ProductsToBuy)
                                .ThenInclude(s => s.Product)
                                .AsNoTracking()
                                .FirstOrDefaultAsync(s => s.Id == id)
                             : await dataAccessHelper.GetAsync<ListOfProductsToBuy>(id);
    if (data != null)
    {
      response.DataModel = MapListOfProductsToBuyToDTO(mapper, data);
    }
    return TypedResults.Ok(response);
  }

  private static async Task<IResult> CreateProductsList(IDataAccessHelper dataAccessHelper, IMapper mapper, ListOfProductsToBuyDTO listOfProductsToBuyDTO)
  {
    if (listOfProductsToBuyDTO == null)
    {
      return TypedResults.BadRequest(new Response<ListOfProductsToBuyDTO>
      {
        ErrorMessage = "Bad entry data",
        StatusCode = System.Net.HttpStatusCode.BadRequest
      });
    }
    var listOfProductsToBuy = mapper.Map<ListOfProductsToBuy>(listOfProductsToBuyDTO);
    var listOfProductsToBuyId = await dataAccessHelper.CreateAsync(listOfProductsToBuy);
    if (listOfProductsToBuyId == null || listOfProductsToBuyId <= 0)
    {
      return TypedResults.Problem("Error while creating ListOfProductsToBuy");
    }
    return TypedResults.Ok(new Response<ListOfProductsToBuyDTO> { DataModel = MapListOfProductsToBuyToDTO(mapper, listOfProductsToBuy) });
  }

  private static async Task<IResult> UpdateProductsList(IDataAccessHelper dataAccessHelper, IMapper mapper, ListOfProductsToBuyDTO listOfProductsToBuyDTO)
  {
    if (listOfProductsToBuyDTO == null)
    {
      return TypedResults.BadRequest(new Response<ListOfProductsToBuyDTO>
      {
        ErrorMessage = "Bad entry data",
        StatusCode = System.Net.HttpStatusCode.BadRequest
      });
    }
    var listOfProductsToBuy = mapper.Map<ListOfProductsToBuy>(listOfProductsToBuyDTO);
    var result = await dataAccessHelper.UpdateAsync(listOfProductsToBuy);
    if (result)
    {
      return TypedResults.Problem("Error while updating ListOfProductsToBuy");
    }
    return TypedResults.Ok(new Response<ListOfProductsToBuyDTO> { DataModel = MapListOfProductsToBuyToDTO(mapper, listOfProductsToBuy) });
  }

  private static async Task<IResult> RemoveProductsList(IDataAccessHelper dataAccessHelper, ListOfProductsToBuyDTO listOfProductsToBuyDTO)
  {
    if (listOfProductsToBuyDTO == null)
    {
      return TypedResults.BadRequest(new Response<ListOfProductsToBuyDTO>
      {
        ErrorMessage = "Bad entry data",
        StatusCode = System.Net.HttpStatusCode.BadRequest
      });
    }
    try
    {
      await dataAccessHelper.DeleteAsync<ListOfProductsToBuy>(listOfProductsToBuyDTO.Id);
    }
    catch (Exception ex)
    {
      return TypedResults.BadRequest(new Response<ListOfProductsToBuyDTO>
      {
        ErrorMessage = $"Cannot delete selected ListOfProductsToBuy\n{ex.Message}",
        StatusCode = System.Net.HttpStatusCode.UnprocessableEntity
      });
    }
    return TypedResults.Ok(new Response<ListOfProductsToBuyDTO>());
  }

  private static async Task<IResult> AddProductToList(IDataAccessHelper dataAccessHelper, IMapper mapper, int listId, int productId, double amount)
  {
    if (listId <= 0 || productId <= 0)
    {
      return TypedResults.BadRequest("Selected List or Product does not exists");
    }

    var listOfProducts = await dataAccessHelper.GetAsQuerable<ListOfProductsToBuy>()
      .Include(p => p.ProductsToBuy)
      .FirstOrDefaultAsync(p => p.Id == listId);
    if (listOfProducts == null)
    {
      return TypedResults.BadRequest("Selected ListOfProductsToBuy does not exists");
    }

    var product = await dataAccessHelper.GetAsQuerable<Product>()
      .FirstOrDefaultAsync(p => p.Id == productId);
    if (product == null)
    {
      return TypedResults.BadRequest("Selected Product does not exists");
    }

    listOfProducts.ProductsToBuy.Add(new() { Product = product, Amount = amount });
    await dataAccessHelper.SaveChangedAsync();
    return TypedResults.Ok(new Response<ListOfProductsToBuyDTO> { DataModel = MapListOfProductsToBuyToDTO(mapper, listOfProducts) });
  }

  private static async Task<IResult> RemoveProductFromList(IDataAccessHelper dataAccessHelper, IMapper mapper, int ListId, int productId)
  {
    if (ListId <= 0 || productId <= 0)
    {
      return TypedResults.BadRequest("Selected List or Product does not exists");
    }

    var listOfProducts = await dataAccessHelper.GetAsQuerable<ListOfProductsToBuy>()
      .Include(p => p.ProductsToBuy)
      .FirstOrDefaultAsync(p => p.Id == ListId);
    if (listOfProducts == null)
    {
      return TypedResults.BadRequest("Selected ListOfProductsToBuy does not exists");
    }

    var productExists = await dataAccessHelper.GetAsQuerable<Product>()
      .AnyAsync(p => p.Id == productId);
    if (!productExists)
    {
      return TypedResults.BadRequest("Selected Product does not exists");
    }

    var productToRemove = listOfProducts.ProductsToBuy.FirstOrDefault(s => s.ProductId == productId);
    if (productToRemove == null)
    {
      return TypedResults.BadRequest("Selected Product does not exists in that list");
    }

    listOfProducts.ProductsToBuy.Remove(productToRemove);
    await dataAccessHelper.SaveChangedAsync();
    return TypedResults.Ok(new Response<ListOfProductsToBuyDTO> { DataModel = MapListOfProductsToBuyToDTO(mapper, listOfProducts) });
  }

  private static ListOfProductsToBuyDTO MapListOfProductsToBuyToDTO(IMapper mapper, ListOfProductsToBuy listOfProductsToBuy)
    => mapper.Map<ListOfProductsToBuyDTO>(listOfProductsToBuy);
}
