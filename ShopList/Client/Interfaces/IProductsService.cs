using AutoMapper;
using ShopList.Shared.DataModels.DTOs;
using ShopList.Shared.DataModels.ShopList;

namespace ShopList.Client.Interfaces
{
  public interface IProductsService
  {
    Task<Product> CreateProductAsync(ProductDTO productDTO);
    Task<Product> UpdateProductAsync(ProductDTO productDTO);
    Task<Product?> GetProductAsync(int id);
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<IEnumerable<Product>> GetProductsAsync(IEnumerable<int> products);
    Task<bool> RemoveProductAsync(Product shop);
    IEnumerable<ProductDTO> MapToDTOs(IEnumerable<Product> products);
  }
}
