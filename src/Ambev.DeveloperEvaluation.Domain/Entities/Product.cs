using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Product : BaseEntity
{
    /// <summary>
    /// Gets the product name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets the product description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets the product price.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets the product quantity.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets the product status.
    /// </summary>
    public ProductStatus Status { get; set; }

    /// <summary>
    /// Gets the products in the sale.
    /// </summary>
    public ICollection<ProductSale> ProductSales { get; set; } = [];
}