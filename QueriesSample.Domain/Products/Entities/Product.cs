using QueriesSample.Domain.Core.Entities;
using QueriesSample.Domain.Products.ValueObjects;
using QueriesSample.Domain.ValueObjects;

namespace QueriesSample.Domain.Products.Entities;

public sealed class Product : Entity<Product>
{
    private Product()
    { }

    public Product(
        Guid id,
        Guid productTypeId,
        Description description,
        Stock stock
        ) : base(id)
    {
        ProductTypeId = productTypeId;
        Description = description;
        Stock = stock;

        AddNotifications(Description, Stock);
    }

    public Guid ProductTypeId { get; private set; }
    public Description Description { get; private set; } = null!;
    public Stock Stock { get; private set; } = null!;
    public ProductType ProductType { get; private set; } = null!;

    public static Product Create(
        Guid productTypeId,
        string description,
        int stock)
        => new(
            Guid.NewGuid(),
            productTypeId,
            new Description(description),
            new Stock(stock)
            );
}