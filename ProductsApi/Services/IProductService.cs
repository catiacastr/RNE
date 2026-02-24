
using ProductsApi.Models;

namespace ProductsApi.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProductsAsync(string? type, decimal? minPrice, string? sortByPrice);
    Task<Product?> GetByIdAsync(Guid id);
    Task<bool> DeleteAsync(Guid id);
    Task<Product> CreateAsync(Product product);
    Task<decimal> GetTotalStockValueAsync();
}
