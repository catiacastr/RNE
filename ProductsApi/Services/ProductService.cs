
using Microsoft.EntityFrameworkCore;
using ProductsApi.Models;
using ProductsApi.Repositories;

namespace ProductsApi.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync(string? type, decimal? minPrice, string? sortByPrice)
    {
        var query = _repository.Query();

        if (!string.IsNullOrEmpty(type))
        {
            query = type.ToLower() switch
            {
                "physical" => query.OfType<PhysicalProduct>(),
                "digital" => query.OfType<DigitalProduct>(),
                _ => query
            };
        }

        if (minPrice.HasValue)
            query = query.Where(p => p.Price >= minPrice.Value);

        if (!string.IsNullOrEmpty(sortByPrice))
        {
            query = sortByPrice.ToLower() switch
            {
                "asc" => query.OrderBy(p => p.Price),
                "desc" => query.OrderByDescending(p => p.Price),
                _ => query
            };
        }

        return await query.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(Guid id) =>
        await _repository.GetByIdAsync(id);

    public async Task<bool> DeleteAsync(Guid id)
    {
        var product = await _repository.GetByIdAsync(id);
        if (product == null) return false;

        await _repository.DeleteAsync(product);
        await _repository.SaveChangesAsync();
        return true;
    }

    public async Task<Product> CreateAsync(Product product)
    {
        await _repository.AddAsync(product);
        await _repository.SaveChangesAsync();
        return product;
    }

    public async Task<decimal> GetTotalStockValueAsync()
    {
        return await _repository.Query()
            .OfType<PhysicalProduct>()
            .SumAsync(p => p.Price * p.Stock);
    }
}
