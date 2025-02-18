using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Common;

/// <summary>
/// validate pagination request 
/// </summary>
public class PaginatedRequestValidator : AbstractValidator<PaginatedRequest>
{
    /// <summary>
    /// Initialize a new instance of PaginatedRequestValidator
    /// </summary>
    public PaginatedRequestValidator()
    {
        RuleFor(x => x.PageNumber).GreaterThan(0).WithMessage("Must be greater than 0");
        RuleFor(x => x.PageSize).GreaterThan(0).WithMessage("Must be Greate than 0");
    }
}
