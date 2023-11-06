namespace Catalog.Domain.AggregatesModel.ProductAggregate;

public record Sku
{
    private const int MaxLength = 20;

    public string Value { get; private set; }

    private Sku(string value) => Value = value;

    public static Sku Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (value.Length > MaxLength)
        {
            throw new ArgumentException($"The length of {nameof(value)} must be less than {MaxLength}.");
        }

        return new Sku(value);
    }

    public static implicit operator string(Sku sku) => sku.Value;
}