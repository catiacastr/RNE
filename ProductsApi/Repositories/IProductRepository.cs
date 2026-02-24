
using ProductsApi.Models;

namespace ProductsApi.Repositories;

public interface IProductRepository
{
    IQueryable<Product> Query();
    Task<Product?> GetByIdAsync(Guid id);
    Task AddAsync(Product product);
    Task DeleteAsync(Product product);
    Task SaveChangesAsync();
}
