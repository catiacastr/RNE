
using ProductsApi.Models;

namespace ProductsApi.Data;

public static class SeedData
{
    public static void Initialize(AppDbContext context)
    {
        if (context.Products.Any()) return;

        context.Products.AddRange(
            new PhysicalProduct { Name="Laptop", Price=1200, Weight=2.5, Stock=10 },
            new PhysicalProduct { Name="Monitor", Price=300, Weight=5, Stock=20 },
            new PhysicalProduct { Name="Mouse", Price=25, Weight=0.2, Stock=100 },
            new PhysicalProduct { Name="Keyboard", Price=75, Weight=0.8, Stock=50 },
            new PhysicalProduct { Name="Chair", Price=150, Weight=12, Stock=5 },

            new DigitalProduct { Name="Ebook", Price=15, FileSize=5, DownloadUrl="url1" },
            new DigitalProduct { Name="Course", Price=99, FileSize=2000, DownloadUrl="url2" },
            new DigitalProduct { Name="License", Price=199, FileSize=500, DownloadUrl="url3" },
            new DigitalProduct { Name="Music Pack", Price=9, FileSize=100, DownloadUrl="url4" },
            new DigitalProduct { Name="Template Pack", Price=29, FileSize=50, DownloadUrl="url5" }
        );

        context.SaveChanges();
    }
}
