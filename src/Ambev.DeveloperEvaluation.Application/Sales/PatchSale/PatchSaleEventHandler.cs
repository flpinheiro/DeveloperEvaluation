using Ambev.DeveloperEvaluation.Domain.Events;
using Rebus.Handlers;
using Serilog;

namespace Ambev.DeveloperEvaluation.Application.Sales.PatchSale;

public class PatchSaleEventHandler : IHandleMessages<PatchSaleEvent>
{
    public Task Handle(PatchSaleEvent message)
    {
        Log.Information("PatchSale event received: {@Message}", message);
        return Task.CompletedTask;
    }
}
