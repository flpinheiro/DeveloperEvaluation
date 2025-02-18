using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

/// <summary>
/// validate a request for a sale
/// </summary>
public class GetSaleRequestValidator : AbstractValidator<GetSaleRequest>
{
    /// <summary>
    /// initialize a instance of GetSaleRequestValidator
    /// </summary>
    public GetSaleRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Must have a valid id");
    }
}
