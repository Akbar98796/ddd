namespace Catalog.Domain.AggregatesModel.ProductAggregate;

public class Product : Entity<ProductId>
{
    public Sku Sku { get; private set; }
    public string Name { get; private set; }
    public Money Price { get; private set; }
    public Category Category { get; private set; }
    public Seller Seller { get; private set; }
    public Brand Brand { get; private set; }
    public ImageUrl ProductImage { get; private set; }
    public string? Description { get; private set; }

    private Product() {}

    private Product(ProductId id,Sku sku,
                   string name,
                   Money price,
                   Category category,
                   Seller seller,
                   Brand brand,
                   ImageUrl productImage,
                   string? description) : base(id) => 
        (Sku, Name, Price, Category, Seller, Brand, ProductImage, Description) = 
            (sku, name, price, category, seller, brand, productImage, description);


    public static Product Create(ProductId id,
                                 Sku sku,
                                 string name,
                                 Money price,
                                 Category category,
                                 Seller seller,
                                 Brand brand,
                                 ImageUrl productImage,
                                 string? description) =>
        new Product(id, sku, name, price, category, seller, brand, productImage, description);

}