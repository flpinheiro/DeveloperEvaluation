using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

/// <summary>
/// validate a request to get a product
/// </summary>
public class GetProductRequestValidator : AbstractValidator<GetProductRequest>
{
    /// <summary>
    /// Initializes a new instance of GetProductRequestValidator
    /// </summary>
    public GetProductRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Should have a nom empty id");
    }
}
