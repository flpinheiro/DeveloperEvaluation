using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.RemoveProductSale;

public class RemoveProductSaleCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public IEnumerable<Guid> Products { get; set; } = [];
}
