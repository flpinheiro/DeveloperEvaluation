using Ambev.DeveloperEvaluation.Domain.Dtos;
using FluentValidation.Results;


namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.PatchProductSale;

/// <summary>
/// information to update products from sale
/// </summary>
public class PatchProductSaleRequest
{
    /// <summary>
    /// sale id
    /// </summary>
    public Guid Id { get; internal set; }

    /// <summary>
    /// product list to be updated
    /// </summary>
    public IEnumerable<ProductRequestDto> Products { get; set; } = [];

    internal ValidationResult Validate()
    {
        Products = Products.JoinProductRequestDto();

        var validatidator = new PatchProductSaleRequestValidator();
        var validationResult = validatidator.Validate(this);

        return validationResult;
    }
}
