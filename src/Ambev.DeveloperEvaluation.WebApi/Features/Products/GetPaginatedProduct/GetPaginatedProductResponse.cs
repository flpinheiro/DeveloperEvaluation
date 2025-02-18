namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetPaginatedProduct;

/// <summary>
/// response of the products paginated
/// </summary>
public class GetPaginatedProductResponse
{
    /// <summary>
    /// Product id
    /// </summary>
    public Guid Id { get; set; }
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
}