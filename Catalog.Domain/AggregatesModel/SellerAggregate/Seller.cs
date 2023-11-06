namespace Catalog.Domain.AggregatesModel.SellerAggregate;

public class Seller : Entity<SellerId>
{
    public string Name { get; private set; }
    public Email Email { get; private set; }
    public ISet<Product> Products { get; private set; }

    private Seller() { }

    private Seller(SellerId id, string name, Email email, ISet<Product> products) : base(id) =>
        (Name, Email, Products) = (name, email, products);

    public static Seller Create(SellerId id, string name, Email email, ISet<Product> products) =>
        new Seller(id, name, email, products);

}