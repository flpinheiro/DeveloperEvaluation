
namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

/// <summary>
/// information to que a product
/// </summary>
public class GetProductRequest
{
    /// <summary>
    /// Product id
    /// </summary>
    public Guid Id { get; internal set; }
}
