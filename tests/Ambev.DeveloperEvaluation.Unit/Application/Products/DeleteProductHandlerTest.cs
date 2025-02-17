using Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Products;

public class DeleteProductHandlerTest
{
    private readonly DeleteProductHandler _handler;
    private readonly IProductRepository _productRepository;

    public DeleteProductHandlerTest()
    {
        _productRepository = NSubstitute.Substitute.For<IProductRepository>();
        _handler = new DeleteProductHandler(_productRepository);
    }

    [Fact]
    public async Task ShouldDeleteProduct()
    {
        var id = Guid.NewGuid();
        var command = new DeleteProductCommand { Id = id };
        await _handler.Handle(command, default);
        await _productRepository.Received().DeleteAsync(id, default);
    }
}
