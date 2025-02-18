
namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProduct;

/// <summary>
/// request to delete a product
/// </summary>
public class DeleteProductRequest
{
    /// <summary>
    /// product id
    /// </summary>
    public Guid Id { get; internal set; }
}
