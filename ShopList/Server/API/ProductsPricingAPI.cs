using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using ShopList.Shared;
using ShopList.Shared.DataModels.DTOs;
using ShopList.Shared.DataModels.ShopList;
using ShopList.Shared.HTTP;
using ShopList.Shared.Interfaces;

namespace ShopList.Server.API
{
	public static class ProductsPricingAPI
	{
		public static void RegisterProductsPricingAPI(this WebApplication app)
		{
			app.MapGet(APIAdressess.GetProductsPricing, GetProductsPricingAsync);
			app.MapPost(APIAdressess.CreateProductPricing, AddProductsPricingAsync);
			app.MapPut(APIAdressess.UpdateProductPricing, UpdateProductsPricingAsync);
			app.MapPost(APIAdressess.RemoveProductPricing, RemoveProductsPricingAsync);
		}

		private static async Task<IResult> GetProductsPricingAsync(IDataAccessHelper dataAccessHelper, IMapper mapper)
		{
			var data = await dataAccessHelper.GetAsync<ProductPricing>();
			return TypedResults.Ok(new Response<IEnumerable<ProductPricingDTO>> { DataModel = data.Select(mapper.Map<ProductPricingDTO>) });
		}

		private static async Task<IResult> AddProductsPricingAsync(IDataAccessHelper dataAccessHelper, IMapper mapper, ProductPricingDTO productPricingDTO)
		{
			if(productPricingDTO == null || productPricingDTO.Price <= 0 || productPricingDTO.ProductId <= 0 || productPricingDTO.ShopId <= 0)
			{
				return TypedResults.BadRequest(new Response<ProductPricingDTO>
				{
					ErrorMessage = "Bad entry data",
					StatusCode = System.Net.HttpStatusCode.BadRequest
				});
			}

			var dataToAdd = mapper.Map<ProductPricing>(productPricingDTO);
			var result = await dataAccessHelper.CreateAsync(dataToAdd);
			if(result == null || result <= 0)
			{
				return TypedResults.Problem("Error while creating new product Pricing");
			}
			return TypedResults.Ok(new Response<ProductPricingDTO> { DataModel = productPricingDTO });
		}

		private static async Task<IResult> UpdateProductsPricingAsync(IDataAccessHelper dataAccessHelper, IMapper mapper, ProductPricingDTO productPricingDTO)
		{
			if(productPricingDTO == null || productPricingDTO.Id <= 0 || productPricingDTO.Price <= 0 || productPricingDTO.ProductId <= 0 || productPricingDTO.ShopId <= 0)
			{
				return TypedResults.BadRequest(new Response<ProductPricingDTO>
				{
					ErrorMessage = "Bad entry data",
					StatusCode = System.Net.HttpStatusCode.BadRequest
				});
			}

			var dataToUpdate = mapper.Map<ProductPricing>(productPricingDTO);
			if(!await dataAccessHelper.UpdateAsync(dataToUpdate))
			{
				return TypedResults.Problem("Error while updating product pricing");
			}
			return TypedResults.Ok(new Response<ProductPricingDTO> { DataModel = productPricingDTO });
		}

		private static async Task<IResult> RemoveProductsPricingAsync(IDataAccessHelper dataAccessHelper, IMapper mapper, ProductPricingDTO productPricingDTO)
		{
			if(productPricingDTO == null || productPricingDTO.Id <= 0)
			{
				return TypedResults.BadRequest(new Response<ProductPricingDTO>
				{
					ErrorMessage = "Bad entry data",
					StatusCode = System.Net.HttpStatusCode.BadRequest
				});
			}

			try
			{
				await dataAccessHelper.DeleteAsync<ProductPricing>(productPricingDTO.Id);
			}
			catch(Exception ex)
			{
				return TypedResults.Problem("Error while deleting data");
			}
			return TypedResults.Ok(new Response<ProductPricingDTO> { DataModel = productPricingDTO });
		}
	}
}
