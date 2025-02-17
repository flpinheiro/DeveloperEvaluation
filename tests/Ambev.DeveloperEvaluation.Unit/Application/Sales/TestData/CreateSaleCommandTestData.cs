using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.PatchProductSale;
using Ambev.DeveloperEvaluation.Domain.Dtos;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Dtos;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.TestData;

public class CreateSaleCommandTestData
{
    private Faker<CreateSaleCommand> _faker = new Faker<CreateSaleCommand>()
        .RuleFor(x => x.Products, f =>
                ProductRequestDtoTestData.GenerateValidProductRequestDto(f.Random.Number(1, 100)));

    public CreateSaleCommand GenerateValidCreateSaleCommand()
    {
        return _faker.Generate();
    }

    public CreateSaleCommandTestData WithProducts(IEnumerable<Product> products)
    {
        var faker = new Faker();
        var dtos = products.ToList().Select(a => new ProductRequestDto
        {
            ProductId = a.Id,
            Quantity = faker.Random.Number(1, 20)
        });
        _faker.RuleFor(x => x.Products, dtos);
        return this;
    }
}

public class PatchProductSaleCommandTestData
{
    private readonly Faker<PatchProductSaleCommand> _faker = new Faker<PatchProductSaleCommand>()
        .RuleFor(x => x.Products, f =>
                ProductRequestDtoTestData.GenerateValidProductRequestDto(f.Random.Number(1, 100)))
        .RuleFor(x => x.Id, f => Guid.NewGuid());

    public PatchProductSaleCommandTestData WithProducts(IEnumerable<Product> products)
    {
        var faker = new Faker();
        var dtos = products.ToList().Select(a => new ProductRequestDto
        {
            ProductId = a.Id,
            Quantity = faker.Random.Number(1, 20)
        });
        _faker.RuleFor(x => x.Products, dtos);
        return this;
    }

    public PatchProductSaleCommand GenerateValidPatchProductSaleCommand()
    {
        return _faker.Generate();
    }
}
