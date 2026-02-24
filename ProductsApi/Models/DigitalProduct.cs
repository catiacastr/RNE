
namespace ProductsApi.Models;

public class DigitalProduct : Product
{
    public double FileSize { get; set; }
    public string DownloadUrl { get; set; } = string.Empty;
}
