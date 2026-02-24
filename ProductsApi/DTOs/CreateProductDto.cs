
using System.ComponentModel.DataAnnotations;

namespace ProductsApi.DTOs;

public class CreateProductDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }

    [Required]
    public string Type { get; set; } = string.Empty;

    public double? Weight { get; set; }
    public int? Stock { get; set; }

    public double? FileSize { get; set; }
    public string? DownloadUrl { get; set; }
}
