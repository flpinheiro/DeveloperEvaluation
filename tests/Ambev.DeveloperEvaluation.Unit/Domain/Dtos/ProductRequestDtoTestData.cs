using Ambev.DeveloperEvaluation.Domain.Dtos;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Dtos;

public static class ProductRequestDtoTestData
{
    private readonly static Faker<ProductRequestDto> _faker = new Faker<ProductRequestDto>()
            .RuleFor(x => x.ProductId, f => Guid.NewGuid())
            .RuleFor(x => x.Quantity, f => f.Random.Number());
    public static ProductRequestDto GenerateValidProductRequestDto()
    {
        return _faker.Generate();
    }

    public static IEnumerable<ProductRequestDto> GenerateValidProductRequestDto(int count)
    {
        return _faker.Generate(count);
    }
}
