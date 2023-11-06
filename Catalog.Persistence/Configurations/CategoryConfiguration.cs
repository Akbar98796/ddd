namespace Catalog.Persistence.Configurations;

internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    private const int NameMaxLength = 100;

    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
             categoryId => categoryId.Value,
             value => new CategoryId(value)).IsRequired();

        builder.Property(c => c.Name)
               .HasMaxLength(NameMaxLength)
               .IsRequired();

        builder.HasMany(c => c.Products)
               .WithOne(p => p.Category)
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired();
    }
}