using FluentValidation.Results;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.RemoveProductSale;

/// <summary>
/// information to remove a product from a sale
/// </summary>
public class RemoveProductSaleRequest
{
    /// <summary>
    /// sale id
    /// </summary>
    public Guid Id { get; internal set; }

    /// <summary>
    /// product id list
    /// </summary>
    public IEnumerable<Guid> Products { get; set; } = [];

    internal ValidationResult Validate()
    {
        var validator = new RemoveProductSaleValidator();
        var result = validator.Validate(this);
        return result;
    }
}