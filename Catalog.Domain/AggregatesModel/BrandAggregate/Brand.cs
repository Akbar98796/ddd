namespace Catalog.Domain.AggregatesModel.BrandAggregate;

public class Brand : Entity<BrandId>
{
    public string Name { get; private set; }
    public ISet<Product> Products { get; private set; }
    public string? Description { get; private set; }

    public Brand() { }

    private Brand(BrandId id,
                  string name,
                  ISet<Product> products,
                  string? description = null) : base(id) =>
        (Name, Products, Description) = (name, products, description);


    public static Brand Create(BrandId id, string name, ISet<Product> products, string? descprition = null) =>
        new Brand(id, name, products, descprition);

}