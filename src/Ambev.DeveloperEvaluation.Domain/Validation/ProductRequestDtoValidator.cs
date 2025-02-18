using Ambev.DeveloperEvaluation.Domain.Dtos;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class ProductRequestDtoValidator : AbstractValidator<ProductRequestDto>
{
    public ProductRequestDtoValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty()
            .WithMessage("ProductId is required.");

        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage(p => $"Quantity of {p.ProductId} must be greater than zero.")
            .WithErrorCode("Minimum Quantity necessary")
            .LessThanOrEqualTo(20)
            .WithMessage(p => $"quantity of {p.ProductId} must not be greater thean 20")
            .WithErrorCode("Maximum Quantity exceded");
    }
}