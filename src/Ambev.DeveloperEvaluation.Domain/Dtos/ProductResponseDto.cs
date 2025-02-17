using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Dtos;

public class ProductResponseDto
{
    /// <summary>
    /// Gets the product id and product information.
    /// </summary>
    public Guid ProductId { get; set; }

    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets the product quantity.
    /// </summary>
    public int Quantity { get; set; }

    public decimal Price { get; set; }

    /// <summary>
    /// Gets the total amount of the sale by Product.
    /// </summary>
    public decimal TotalAmout { get; set; }

    /// <summary>
    /// Gets the discount amount of the sale by Product.
    /// </summary>
    public decimal Discount { get; set; }
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// gets the sale.status of the product
    /// </summary>
    public SaleStatus Status { get; set; } = SaleStatus.Active;
}
