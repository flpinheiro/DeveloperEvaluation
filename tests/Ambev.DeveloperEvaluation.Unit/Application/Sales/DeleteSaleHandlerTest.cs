using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using NSubstitute;
using Rebus.Bus;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales;

public class DeleteSaleHandlerTest
{
    private readonly DeleteSaleCommandHandler _handler;
    private readonly ISaleRepository _saleRepository;
    private readonly IBus _bus;
    public DeleteSaleHandlerTest()
    {
        _saleRepository = Substitute.For<ISaleRepository>();
        _bus = Substitute.For<IBus>();
        _handler = new DeleteSaleCommandHandler(_saleRepository, _bus);
    }

    [Fact]
    public async Task Should_Cancel_A_Valid_Sale()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        _saleRepository.DeleteAsync(sale.Id, default).Returns(true);

        var request = new DeleteSaleCommand { Id = sale.Id };
        // Act
        var result = await _handler.Handle(request, default);
        // Assert
        Assert.True(result);
        await _bus.Received(1).Publish(Arg.Any<DeleteSaleEvent>());
    }
}