using Ambev.DeveloperEvaluation.Domain.Dtos;
using FluentValidation.Results;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// resquest information to create a new sale
/// </summary>
public class CreateSaleRequest
{
    /// <summary>
    /// product list
    /// </summary>
    public IEnumerable<ProductRequestDto> Products { get; set; } = [];

    internal ValidationResult Validate()
    {
        Products = Products.JoinProductRequestDto();

        var validatidator = new CreateSaleRequestValidator();
        var validationResult = validatidator.Validate(this);

        return validationResult;
    }
}
