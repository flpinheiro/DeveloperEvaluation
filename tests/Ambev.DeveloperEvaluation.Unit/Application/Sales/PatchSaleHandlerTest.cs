using Ambev.DeveloperEvaluation.Application.Sales.PatchSale;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using NSubstitute;
using Rebus.Bus;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales;

public class PatchSaleHandlerTest
{
    private readonly PatchSaleCommandHandler _handler;
    private readonly ISaleRepository _saleRepository;
    private readonly IBus _bus;

    public PatchSaleHandlerTest()
    {
        _saleRepository = Substitute.For<ISaleRepository>();
        _bus = Substitute.For<IBus>();

        _handler = new PatchSaleCommandHandler(_saleRepository, _bus);
    }

    [Fact]
    public async Task Should_Patch_Sale()
    {
        var command = new PatchSaleCommand { Id = Guid.NewGuid() };

        var sale = SaleTestData.GenerateValidSale();

        _saleRepository.GetByIdAsync(command.Id, default).Returns(sale);

        var result = await _handler.Handle(command, default);

        await _saleRepository.Received(1).UpdateAsync(sale, default);

        await _bus.Received(1).Publish(Arg.Any<PatchSaleEvent>());

        Assert.True(result);
        Assert.Equal(SaleStatus.Payed, sale.Status);
    }
}
