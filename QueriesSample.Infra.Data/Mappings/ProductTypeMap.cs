using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueriesSample.Domain.Products.Entities;

namespace QueriesSample.Infra.Data.Mappings;

public sealed class ProductTypeMap : IEntityTypeConfiguration<ProductType>
{
    public void Configure(EntityTypeBuilder<ProductType> builder)
    {
        builder.HasKey(pt => pt.Id);

        builder.Ignore(pt => pt.Notifications);

        builder.OwnsOne(pt => pt.Description, description =>
        {
            description.Property(d => d.Text)
            .HasColumnName("Description")
            .HasColumnType("varchar(150)");

            description.HasIndex(d => d.Text).IsUnique();

            description.Ignore(d => d.Notifications);
        });
    }
}