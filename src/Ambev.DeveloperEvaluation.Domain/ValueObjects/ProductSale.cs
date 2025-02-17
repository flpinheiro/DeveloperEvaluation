using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.ValueObjects;

public class ProductSale
{
    /// <summary>
    /// Gets the sale id and sale information.
    /// </summary>
    public Guid SaleId { get; set; }
    /// <summary>
    /// Gets the sale id and sale information.
    /// </summary>
    public Sale? Sale { get; set; }

    /// <summary>
    /// Gets the product id and product information.
    /// </summary>
    public Guid ProductId { get; set; }
    /// <summary>
    /// Gets the product id and product information.
    /// </summary>
    public Product? Product { get; set; }

    /// <summary>
    /// Gets the product quantity.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets the total amount of the sale by Product.
    /// </summary>
    public decimal TotalAmout { get; set; }

    /// <summary>
    /// Gets the discount amount of the sale by Product.
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// gets the sale.status of the product
    /// </summary>
    public SaleStatus Status { get; set; } = SaleStatus.Active;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Calculate total ammout for the product
    /// </summary>
    public void CalculateTotalAmount()
    {
        CalculateDiscount();
        TotalAmout = Quantity * Product?.Price * (1M - Discount / 100M) ?? 0;
    }

    /// <summary>
    /// calculate discount for the product
    /// </summary>
    private void CalculateDiscount()
    {
        if (Quantity >= 10 && Quantity <= 20)
        {
            Discount = 20;
            return;
        }
        if (Quantity >= 4 && Quantity < 10)
        {
            Discount = 10;
            return;
        }
        Discount = 0;
    }
}
