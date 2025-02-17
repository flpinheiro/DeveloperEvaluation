using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using Rebus.Bus;

namespace Ambev.DeveloperEvaluation.Application.Sales.PatchSale;

public class PatchSaleCommandHandler : IRequestHandler<PatchSaleCommand, bool>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IBus _bus;

    public PatchSaleCommandHandler(ISaleRepository saleRepository, IBus bus)
    {
        _saleRepository = saleRepository;
        _bus = bus;
    }

    public async Task<bool> Handle(PatchSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = await _saleRepository.GetByIdAsync(request.Id, cancellationToken);

        if (sale == null || sale.Status == SaleStatus.Finished) return false;

        sale.Status++;

        await _saleRepository.UpdateAsync(sale, cancellationToken);

        await _bus.Publish(new PatchSaleEvent() { Id = sale.Id, Status = sale.Status });

        return true;
    }
}
