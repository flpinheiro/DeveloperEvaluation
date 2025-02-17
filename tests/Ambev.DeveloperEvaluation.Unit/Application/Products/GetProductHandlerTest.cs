using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.Products.TestData;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Ambev.DeveloperEvaluation.Unit.Fixtures;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Products;

public class GetProductHandlerTest
{
    private readonly GetProductHandler _handler;
    private readonly IProductRepository _productRepository;

    public GetProductHandlerTest()
    {
        _productRepository = Substitute.For<IProductRepository>();
        var mapper = MapperFixture.CreateMapper(new GetProductCommandProfile());
        _handler = new GetProductHandler(mapper, _productRepository);
    }

    [Fact]
    public async Task Should_return_Product()
    {
        var product = ProductTestData.GenerateValidProduct();

        _productRepository.GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>()).Returns(product);

        var command = GetProductCommandTestData.GetProductCommand();

        var result = await _handler.Handle(command, default);

        Assert.NotNull(result);
        Assert.Equal(product.Id, result.Id);
        Assert.Equal(product.Name, result.Name);
        Assert.Equal(product.Description, result.Description);
        Assert.Equal(product.Price, result.Price);
    }
}
