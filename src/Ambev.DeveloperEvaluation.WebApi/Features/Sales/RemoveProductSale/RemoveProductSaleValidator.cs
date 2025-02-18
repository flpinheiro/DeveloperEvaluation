using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.RemoveProductSale;

public class RemoveProductSaleValidator : AbstractValidator<RemoveProductSaleRequest>
{
    public RemoveProductSaleValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Must have a valid id");
        RuleFor(x => x.Products).NotEmpty().WithMessage("Must have a valid product list");
    }
}
