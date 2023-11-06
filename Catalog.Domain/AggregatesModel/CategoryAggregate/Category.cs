namespace Catalog.Domain.AggregatesModel.CategoryAggregate;

public class Category : Entity<CategoryId>
{
    public string Name { get; private set; }
    public ISet<Product> Products { get; private set; }

    private Category() { }

    private Category(CategoryId id, string name, ISet<Product> products) : base(id) =>
        (Name, Products) = (name, products);


    public static Category Create(CategoryId id, string name, ISet<Product> products) =>
        new Category(id, name, products);

}
