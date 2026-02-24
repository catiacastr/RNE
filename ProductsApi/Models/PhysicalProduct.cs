
namespace ProductsApi.Models;

public class PhysicalProduct : Product
{
    public double Weight { get; set; }
    public int Stock { get; set; }
}
