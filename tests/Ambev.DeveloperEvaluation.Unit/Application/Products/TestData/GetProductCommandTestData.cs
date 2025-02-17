using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.Products.TestData;

public static class GetProductCommandTestData
{
    public static GetProductCommand GetProductCommand() => new Faker<GetProductCommand>()
        .RuleFor(p => p.Id, f => f.Random.Guid());
}
