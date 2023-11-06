namespace Catalog.Persistence.Configurations;

internal class SellerConfiguration : IEntityTypeConfiguration<Seller>
{
    private const int NameMaxLength = 100;

    public void Configure(EntityTypeBuilder<Seller> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id).HasConversion(
            sellerId => sellerId.Value,
            value => new SellerId(value)).IsRequired();

        builder.Property(s => s.Name)
               .HasMaxLength(NameMaxLength)
               .IsRequired();

        builder.Property(s => s.Email).HasConversion(
                email => email.Value,
                email => Email.Create(email)).IsRequired();

        builder.HasMany(s => s.Products)
               .WithOne(p => p.Seller)
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired();
    }
}