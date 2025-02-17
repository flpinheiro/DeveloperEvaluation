using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.Products.TestData;
using Ambev.DeveloperEvaluation.Unit.Fixtures;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Products;

public class CreateProductHandlerTest
{
    private readonly CreateProductHandler _handler;
    private readonly IProductRepository _productRepository;
    public CreateProductHandlerTest()
    {
        _productRepository = NSubstitute.Substitute.For<IProductRepository>();
        var mapper = MapperFixture.CreateMapper(new CreateProductCommandProfile());
        _handler = new CreateProductHandler(mapper, _productRepository);
    }
    [Fact]
    public async Task ShouldCreateProduct_when_CreateProductCommand_is_a_valid_product()
    {
        // Arrange
        var command = CreateProductCommandTestData.CreateProductCommand();

        // Act
        var result = await _handler.Handle(command, default);

        // Assert
        Assert.Equal(result.Name, command.Name);
        Assert.Equal(result.Description, command.Description);
        Assert.Equal(result.Price, command.Price);
        Assert.Equal(result.Quantity, command.Quantity);

        NSubstitute.Received.InOrder(() =>
        {
            _productRepository.CreateAsync(Arg.Any<Product>(), Arg.Any<CancellationToken>());
        });
    }
}
