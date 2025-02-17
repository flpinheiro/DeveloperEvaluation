using Ambev.DeveloperEvaluation.Domain.Events;
using Rebus.Handlers;
using Serilog;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleEventHandler : IHandleMessages<CreateSaleEvent>
{
    public Task Handle(CreateSaleEvent message)
    {
        Log.Information("CreateSale event received: {@Message}", message);
        return Task.CompletedTask;
    }
}
