using Flunt.Validations;
using QueriesSample.Domain.Core.ValueObjects;


namespace QueriesSample.Domain.Products.ValueObjects;

public sealed class Stock : ValueObject
{
    private Stock()
    { }

    public Stock(int quantity)
    {
        Quantity = quantity;

        AddNotifications(new Contract<Stock>()
            .Requires()
            .IsLowerOrEqualsThan(0, Quantity, "Stock.Quantity", "The stock must have at least 0 products.")
            );
    }

    public int Quantity { get; private set; }
}