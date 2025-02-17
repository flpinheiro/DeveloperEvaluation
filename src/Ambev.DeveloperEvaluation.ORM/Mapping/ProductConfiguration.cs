using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Description).HasMaxLength(100);
        builder.Property(p => p.Price).IsRequired().HasPrecision(10, 2);
        builder.Property(p => p.Quantity).IsRequired().HasDefaultValue(100);
        builder.Property(p => p.Status).IsRequired().HasDefaultValue(ProductStatus.Active);

        builder.HasData(new List<Product>()
        {
            new ()
            {
                Id = Guid.Parse("f5b1b3b4-3b3b-4b3b-8b3b-3b3b3b3b3b3b"),
                Name = "Product 1",
                Description = "Product 1 description",
                Price = 10.00m,
                Quantity = 100,
                Status = ProductStatus.Active
            },
            new ()
            {
                Id = Guid.Parse("e3c9c4bd-b12c-45b0-a106-7390a8249a7a"),
                Name = "Product 2",
                Description = "Product 2 description",
                Price = 20.00m,
                Quantity = 100,
                Status = ProductStatus.Active
            },
            new() {
                Id = Guid.Parse("c28ab6d3-2cd3-45b3-98a7-2222c9cd7edb"),
                Name = "Product 3",
                Description = "Product 3 description",
                Price = 30.00m,
                Quantity = 100,
                Status = ProductStatus.Active
            },
            new() {
                Id = Guid.Parse("cec713ad-d16d-4444-a1d8-94dd4aceabb9"),
                Name = "Product 4",
                Description = "Product 4 description",
                Price = 30.00m,
                Quantity = 100,
                Status = ProductStatus.Active
            },
            new() {
                Id = Guid.Parse("8295a692-df5c-4d85-8ac9-e50dd5829f0c"),
                Name = "Product 5",
                Description = "Product 5 description",
                Price = 30.00m,
                Quantity = 100,
                Status = ProductStatus.Active
            },
            new() {
                Id = Guid.Parse("6f5a5196-af78-4446-940e-6c410238399d"),
                Name = "Product 6",
                Description = "Product 6 description",
                Price = 30.00m,
                Quantity = 100,
                Status = ProductStatus.Active
            },
        });
    }
}
