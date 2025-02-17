using Ambev.DeveloperEvaluation.Application.Products.GetPaginatedProduct;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.Products.TestData;

public static class GetPaginatedProductCommandTestData
{
    public static GetPaginatedProductCommand GetPaginatedProductCommand() => new Faker<GetPaginatedProductCommand>()
        .StrictMode(true)
        .RuleFor(p => p.PageNumber, f => f.Random.Int(1, 10))
        .RuleFor(p => p.PageSize, f => f.Random.Int(1, 100));
}
