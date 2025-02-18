
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Validate a request to create a new Product
/// </summary>
public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    /// <summary>
    /// Initialize a new Instance of CreateProductRequestValidator
    /// </summary>
    public CreateProductRequestValidator()
    {
        RuleFor(product => product.Name)
            .NotEmpty()
            .MinimumLength(3).WithMessage("Product Name must be at least 3 characters long")
            .MaximumLength(50).WithMessage(" Product Name cannot be longer than 50 characters long");

        RuleFor(product => product.Description)
            .NotEmpty()
            .MinimumLength(3).WithMessage("Product Description must be at least 3 characters long")
            .MaximumLength(100).WithMessage(" Product description cannot be longer than 100 characters long");

        RuleFor(product => product.Price)
            .NotEmpty()
            .GreaterThan(0).WithMessage("Product Price must be greater than 0");

        RuleFor(product => product.Quantity)
            .NotEmpty()
            .GreaterThan(0).WithMessage("Product Qauntity must be greater than 0");
    }
}
