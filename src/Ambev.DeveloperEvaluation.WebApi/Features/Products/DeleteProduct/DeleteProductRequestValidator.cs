using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProduct;

/// <summary>
/// validate a product to be deleted
/// </summary>
public class DeleteProductRequestValidator : AbstractValidator<DeleteProductRequest>
{
    /// <summary>
    /// Initialize a new instance of DeleteProductRequestValidator
    /// </summary>
    public DeleteProductRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Should have a nom empty id");
    }
}
