using QueriesSample.Domain.Core.Entities;
using QueriesSample.Domain.ValueObjects;

namespace QueriesSample.Domain.Products.Entities;

public sealed class ProductType : Entity<ProductType>
{
    private ProductType()
    { }

    public ProductType(Guid id, Description description)
        : base(id)
    {
        Description = description;

        AddNotifications(Description);
    }

    public Description Description { get; private set; } = null!;

    public IList<Product> Products { get; private set; } = null!;

    public static ProductType Create(string description)
        => new(Guid.NewGuid(), new Description(description));
}