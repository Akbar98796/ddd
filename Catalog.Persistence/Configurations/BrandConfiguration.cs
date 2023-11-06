namespace Catalog.Persistence.Configurations;

internal class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    private const int NameMaxLength = 100;
    private const int DescriptionMaxLength = 500;

    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id).HasConversion(
            brandId => brandId.Value,
            value => new BrandId(value)).IsRequired();

        builder.Property(b => b.Name)
               .HasMaxLength(NameMaxLength)
               .IsRequired();

        builder.Property(b => b.Description)
               .HasMaxLength(DescriptionMaxLength);

        builder.HasMany(b => b.Products)
               .WithOne(p => p.Brand)
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired();
    }
}