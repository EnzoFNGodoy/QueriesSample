using Flunt.Validations;
using QueriesSample.Domain.Common.Helpers;
using QueriesSample.Domain.Core.ValueObjects;

namespace QueriesSample.Domain.ValueObjects;

public sealed class Description : ValueObject
{
    private Description()
    { }

    public Description(string text)
    {
        Text = text;

        AddNotifications(new Contract<Description>()
            .Requires()
            .IsTrue(Text.IsEmpty(), "Description.Text", "The description cannot be empty.")
            .IsLowerOrEqualsThan(3, Text.Length, "Description.Text", "The description must have at least 3 characters.")
            .IsGreaterOrEqualsThan(150, Text.Length, "Description.Text", "The description must have a maximum of 150 characters.")
            );
    }

    public string Text { get; private set; } = string.Empty;
}