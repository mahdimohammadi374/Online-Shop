using Domain.Entities;
using Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistance.SeedData;

public class GenerateSeedData
{
    public static async Task SeedData(DataBaseContext dbContext, ILoggerFactory loggerFactory)
    {
		try
		{
    
            if (!await dbContext.ProductBrands.AnyAsync())
            {
                List<ProductBrand> productBrands = GetProductBrands();
                await dbContext.ProductBrands.AddRangeAsync(productBrands);
                await dbContext.SaveChangesAsync();
            }

            if (!await dbContext.ProductTypes.AnyAsync())
            {
                List<ProductType> productTypes = GetProductTypes();
                await dbContext.ProductTypes.AddRangeAsync(productTypes);
                await dbContext.SaveChangesAsync();
            }

            if (!await dbContext.Products.AnyAsync())
            {
                List<Product> products = GetProducts();
                await dbContext.Products.AddRangeAsync(products);
                await dbContext.SaveChangesAsync();
            }

        }
		catch (Exception ex)
		{
			var logger = loggerFactory.CreateLogger<GenerateSeedData>();
			logger.LogError(ex, "An Error ocuured in Seed data");
			throw;
		}
    }


    public static List<ProductBrand> GetProductBrands()
    {
        return new List<ProductBrand>
        {
            new ProductBrand { Title = "Apple", Description = "Premium electronics brand", IsActive = true, IsDeleted = false, Summary = "Apple products are known for their quality." },
            new ProductBrand { Title = "Samsung", Description = "Leading technology company", IsActive = true, IsDeleted = false, Summary = "Samsung offers a wide range of electronics." },
            new ProductBrand { Title = "Dell", Description = "Computer technology company", IsActive = true, IsDeleted = false, Summary = "Dell is known for its laptops and desktops." },
            new ProductBrand { Title = "HP", Description = "Hewlett-Packard Company", IsActive = true, IsDeleted = false, Summary = "HP provides a variety of computing solutions." },
            new ProductBrand { Title = "OnePlus", Description = "Smartphone manufacturer", IsActive = true, IsDeleted = false, Summary = "OnePlus is known for its high-performance smartphones." }
        };
    }

    public static List<ProductType> GetProductTypes()
    {
        return new List<ProductType>
        {
            new ProductType {  Title = "Mobile", Description = "Smartphones and mobile devices", IsActive = true, IsDeleted = false, Summary = "Mobile devices for communication and entertainment." },
            new ProductType {  Title = "Laptop", Description = "Portable computers", IsActive = true, IsDeleted = false, Summary = "Laptops for work and personal use." }
        };
    }

    public static List<Product> GetProducts()
    {
        var brands = GetProductBrands();
        var types = GetProductTypes();

        List<Product> products = new List<Product>
        {
            new Product
            {
                Title = "iPhone 14 Pro",
                Price = 999.99m,
                PictureUrl = "https://example.com/images/iphone14pro.jpg",
                Description = "The latest iPhone with advanced features.",
                IsActive = true,
                IsDeleted = false,
                Summary = "iPhone 14 Pro with A16 chip and ProMotion display.",
                ProductBrandId = 1,
                ProductTypeId = 1,
            },
            new Product
            {
                Title = "Samsung Galaxy S22",
                Price = 799.99m,
                PictureUrl = "https://example.com/images/galaxys22.jpg",
                Description = "High-performance smartphone with a stunning display.",
                IsActive = true,
                IsDeleted = false,
                Summary = "Samsung Galaxy S22 with Exynos 2200.",
                ProductBrandId = 2,
                ProductTypeId = 1,
            },
            new Product
            {
                Title = "Dell XPS 13",
                Price = 1199.99m,
                PictureUrl = "https://example.com/images/dellxps13.jpg",
                Description = "Compact and powerful laptop for professionals.",
                IsActive = true,
                IsDeleted = false,
                Summary = "Dell XPS 13 with Intel i7 processor.",
                ProductBrandId = 3,
                ProductTypeId = 2,
            },
            new Product
            {
                Title = "HP Spectre x360",
                Price = 1399.99m,
                PictureUrl = "https://example.com/images/hpspectrex360.jpg",
                Description = "Versatile 2-in-1 laptop with a sleek design.",
                IsActive = true,
                IsDeleted = false,
                Summary = "HP Spectre x360 with 4K display.",
                ProductBrandId = 4,
                ProductTypeId = 2,
            },
            new Product
            {
                Title = "OnePlus 10 Pro",
                Price = 899.99m,
                PictureUrl = "https://example.com/images/oneplus10pro.jpg",
                Description = "Flagship smartphone with fast charging.",
                IsActive = true,
                IsDeleted = false,
                Summary = "OnePlus 10 Pro with Snapdragon 8 Gen 1.",
                ProductBrandId = 5,
                ProductTypeId = 1,
            },
            new Product
            {
                Title = "MacBook Air M2",
                Price = 1199.99m,
                PictureUrl = "https://example.com/images/macbookairm2.jpg",
                Description = "Lightweight laptop with M2 chip.",
                IsActive = true,
                IsDeleted = false,
                Summary = "MacBook Air M2 with Retina display.",
                ProductBrandId = 1,
                ProductTypeId = 2,
            },
            new Product
            {
                Title = "Samsung Galaxy Z Flip 4",
                Price = 999.99m,
                PictureUrl = "https://example.com/images/galaxyzflip4.jpg",
                Description = "Foldable smartphone with unique design.",
                IsActive = true,
                IsDeleted = false,
                Summary = "Samsung Galaxy Z Flip 4 with Flex Mode.",
                ProductBrandId = 2,
                ProductTypeId = 1,
            },
            new Product
            {
                Title = "Lenovo ThinkPad X1 Carbon",
                Price = 1399.99m,
                PictureUrl = "https://example.com/images/thinkpadx1carbon.jpg",
                Description = "Business laptop with robust performance.",
                IsActive = true,
                IsDeleted = false,
                Summary = "Lenovo ThinkPad X1 Carbon with Intel i7.",
                ProductBrandId = 3,
                ProductTypeId = 2,
            },
            new Product
            {
                Title = "Asus ROG Zephyrus G14",
                Price = 1499.99m,
                PictureUrl = "https://example.com/images/rogzephyrusg14.jpg",
                Description = "Gaming laptop with powerful graphics.",
                IsActive = true,
                IsDeleted = false,
                Summary = "Asus ROG Zephyrus G14 with AMD Ryzen 9.",
                ProductBrandId = 3,
                ProductTypeId = 2,
            },
            new Product
            {
                Title = "Google Pixel 6",
                Price = 599.99m,
                PictureUrl = "https://example.com/images/pixel6.jpg",
                Description = "Smartphone with Google Tensor chip.",
                IsActive = true,
                IsDeleted = false,
                Summary = "Google Pixel 6 with excellent camera features.",
                ProductBrandId = 1,
                ProductTypeId = 1,
            }
        };

        return products;
    }
}
