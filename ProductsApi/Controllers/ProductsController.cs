
using Microsoft.AspNetCore.Mvc;
using ProductsApi.DTOs;
using ProductsApi.Models;
using ProductsApi.Services;

namespace ProductsApi.Controllers;

[ApiController]
[Route("products")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        Product? product = null;

        if (dto.Type.ToLower() == "physical")
        {
            product = new PhysicalProduct
            {
                Name = dto.Name,
                Price = dto.Price,
                Weight = dto.Weight ?? 0,
                Stock = dto.Stock ?? 0
            };
        }
        else if (dto.Type.ToLower() == "digital")
        {
            product = new DigitalProduct
            {
                Name = dto.Name,
                Price = dto.Price,
                FileSize = dto.FileSize ?? 0,
                DownloadUrl = dto.DownloadUrl ?? ""
            };
        }
        else
        {
            return BadRequest("Invalid product type");
        }

        var created = await _service.CreateAsync(product);

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpGet]
    public async Task<IActionResult> Get(string? type, decimal? minPrice, string? sortByPrice)
        => Ok(await _service.GetProductsAsync(type, minPrice, sortByPrice));

    [HttpGet("stock-value")]
    public async Task<IActionResult> GetStockValue()
        => Ok(await _service.GetTotalStockValueAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var product = await _service.GetByIdAsync(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
