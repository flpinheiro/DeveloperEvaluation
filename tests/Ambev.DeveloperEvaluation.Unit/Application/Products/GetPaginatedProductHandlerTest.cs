using Ambev.DeveloperEvaluation.Application.Products.GetPaginatedProduct;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.Products.TestData;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Ambev.DeveloperEvaluation.Unit.Fixtures;
using AutoMapper;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Products;

public class GetPaginatedProductHandlerTest
{
    private readonly GetPaginatedProductHandler _handler;
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public GetPaginatedProductHandlerTest()
    {
        _mapper = MapperFixture.CreateMapper(new GetPaginatedProductCommandProfile());
        _productRepository = NSubstitute.Substitute.For<IProductRepository>();
        _handler = new GetPaginatedProductHandler(_mapper, _productRepository);
    }

    [Fact]
    public async Task Should_Return_PaginatedProducts()
    {
        // Arrange
        var command = GetPaginatedProductCommandTestData.GetPaginatedProductCommand();

        var products = ProductTestData.GenerateValidProducts(command.PageSize).ToList();

        var paginatedProducts = new PaginatedList<Product>(products, products.Count, command.PageNumber, command.PageSize);

        _productRepository.GetPaginatedProducts(Arg.Any<Ambev.DeveloperEvaluation.Domain.Dtos.GetPaginatedProductDto>(), default).Returns(paginatedProducts);
        // Act
        var result = await _handler.Handle(command, default);


        // Assert
        Assert.NotNull(result);
        Assert.Equal(products.Count, result.Count);
    }

}
