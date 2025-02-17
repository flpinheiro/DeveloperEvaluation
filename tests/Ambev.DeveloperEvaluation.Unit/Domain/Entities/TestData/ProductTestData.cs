using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

public static class ProductTestData
{
    private static readonly Faker<Product> ProductFaker = new Faker<Product>()
        .RuleFor(p => p.Id, faker => faker.Random.Guid())
        .RuleFor(p => p.Name, f => f.Commerce.Product())
        .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
        .RuleFor(p => p.Price, f => f.Random.Decimal(1, 1000))
        .RuleFor(p => p.Quantity, f => f.Random.Number(1, 100));

    public static Product GenerateValidProduct() => ProductFaker.Generate();

    public static IEnumerable<Product> GenerateValidProducts(int count) => ProductFaker.Generate(count);
}
