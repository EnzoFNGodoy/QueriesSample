using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueriesSample.Domain.Products.Entities;

namespace QueriesSample.Infra.Data.Mappings;

public sealed class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Ignore(p => p.Notifications);

        builder.HasOne(p => p.ProductType)
            .WithMany(pt => pt.Products)
            .HasForeignKey(p => p.ProductTypeId);

        builder.OwnsOne(p => p.Description, description =>
        {
            description.Property(d => d.Text)
            .HasColumnName("Description")
            .HasColumnType("varchar(150)");

            description.HasIndex(d => d.Text).IsUnique();

            description.Ignore(d => d.Notifications);
        });

        builder.OwnsOne(p => p.Stock, stock =>
        {
            stock.Property(s => s.Quantity)
            .HasColumnName("Stock")
            .HasColumnType("int");

            stock.Ignore(s => s.Notifications);
        });
    }
}