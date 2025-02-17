using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductSaleConfiguration : IEntityTypeConfiguration<ProductSale>
{
    public void Configure(EntityTypeBuilder<ProductSale> builder)
    {
        builder.ToTable("ProductSales");

        builder.HasKey(p => new { p.SaleId, p.ProductId });
        builder.Property(p => p.ProductId).HasColumnType("uuid");
        builder.Property(p => p.SaleId).HasColumnType("uuid");

        builder.HasOne(p => p.Sale)
            .WithMany(p => p.ProductSales)
            .HasForeignKey(p => p.SaleId)
            .HasPrincipalKey(p => p.Id);

        builder.HasOne(p => p.Product)
            .WithMany(p => p.ProductSales)
            .HasForeignKey(p => p.ProductId)
            .HasPrincipalKey(p => p.Id);

        builder.Property(p => p.Quantity).IsRequired();
        builder.Property(p => p.TotalAmout).IsRequired();
        builder.Property(p => p.Discount).IsRequired();
        builder.Property(p => p.Status).IsRequired();

        builder.Property(p => p.Date).IsRequired();
        builder.Property(p => p.UpdatedAt).IsRequired(false);
    }
}