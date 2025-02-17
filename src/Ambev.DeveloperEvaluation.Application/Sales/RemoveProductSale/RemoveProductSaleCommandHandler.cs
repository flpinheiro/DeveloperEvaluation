using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.RemoveProductSale;

public class RemoveProductSaleCommandHandler : IRequestHandler<RemoveProductSaleCommand, bool>
{
    private readonly ISaleRepository _saleRepository;
    public RemoveProductSaleCommandHandler(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }
    public async Task<bool> Handle(RemoveProductSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = await _saleRepository.GetByIdAsync(request.Id, cancellationToken);
        if (sale is null || sale.Status != Domain.Enums.SaleStatus.Active) return false;

        sale.ProductSales
            .Where(p => request.Products.Contains(p.ProductId))
            .ToList()
            .ForEach(p =>
            {
                p.Status = Domain.Enums.SaleStatus.Canceled;
                p.Quantity = 0;
            });

        sale.CalculateTotalValue();

        await _saleRepository.UpdateAsync(sale, cancellationToken);

        return true;
    }
}
