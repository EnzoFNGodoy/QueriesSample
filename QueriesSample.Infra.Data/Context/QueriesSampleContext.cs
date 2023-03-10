using Microsoft.EntityFrameworkCore;
using QueriesSample.Domain.Products.Entities;
using QueriesSample.Infra.Data.Extensions;

namespace QueriesSample.Infra.Data.Context;

public sealed class QueriesSampleContext : DbContext
{
    public QueriesSampleContext(DbContextOptions options) : base(options)
    { }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductType> ProductTypes => Set<ProductType>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureMappings();
        modelBuilder.SeedData();
        base.OnModelCreating(modelBuilder);
    }
}