using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QueriesSample.Domain.Products.Entities;
using QueriesSample.Infra.Data.Mappings;

namespace QueriesSample.Infra.Data.Extensions;

public static class ModelBuilderExtensions
{
    public static void ConfigureMappings(this ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductMap());
        modelBuilder.ApplyConfiguration(new ProductTypeMap());
    }

    public static void SeedData(this ModelBuilder modelBuilder)
    {
        var productTypes = new InitialData().GenerateProductTypeData();
        var products = new InitialData().GenerateProductData(productTypes.Select(pt => pt.Id).ToList());
        modelBuilder.Entity<ProductType>().HasData(productTypes);
        modelBuilder.Entity<Product>().HasData(products);
    }
}

internal class InitialData
{
    private readonly Random _random = new();

    internal IEnumerable<ProductType> GenerateProductTypeData()
    {
        var lineStart = _random.Next(0, 1115);
        var lineEnd = _random.Next(lineStart, lineStart + 30);
        for (int line = lineStart; line < lineEnd; line++)
            yield return ProductType.Create(GenerateProductTypeDescription(line));
    }

    internal IEnumerable<Product> GenerateProductData(List<Guid> productTypesIds)
    {
        for (int i = 0; i < 100; i++)
        {
            var productTypeId = productTypesIds[_random.Next(0, 30)];
            yield return Product.Create(productTypeId, GenerateProductDescription(), _random.Next(0, 200));
        }
    }

    private string GenerateProductDescription()
    {
        var products = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Products.txt"));
        return products[_random.Next(0, products.Length)];
    }

    private string GenerateProductTypeDescription(int line)
    {
        var productType = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Products.txt"));
        return productType[line];
    }
}