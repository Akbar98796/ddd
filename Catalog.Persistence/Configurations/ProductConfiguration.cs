namespace Catalog.Persistence.Configurations;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    private const int NameMaxLength = 100;
    private const int CurrencyMaxLength = 10;
    private const int DescriptionMaxLength = 500;

    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasConversion(
            productId => productId.Value,
            value => new ProductId(value)).IsRequired();

        builder.Property(p => p.Sku).HasConversion(
            sku => sku.Value,
            value => Sku.Create(value)).IsRequired();

        builder.Property(p => p.ProductImage).HasConversion(
            imageUrl => imageUrl.Value,
            value => ImageUrl.Create(value)).IsRequired();


        builder.OwnsOne(p => p.Price, priceBuilder =>
        {
            priceBuilder.Property(m => m.Currency).HasMaxLength(CurrencyMaxLength);
        });

        builder.Property(p => p.Description)
               .HasMaxLength(DescriptionMaxLength);

        builder.Property(p => p.Name)
               .HasMaxLength(NameMaxLength)
               .IsRequired();

        builder.HasOne(p => p.Category)
               .WithMany(c => c.Products)
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired();

        builder.HasOne(p => p.Seller)
               .WithMany(s => s.Products)
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired();

        builder.HasOne(p => p.Brand)
               .WithMany(b => b.Products)
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired();
    }
}