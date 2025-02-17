using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.PatchSale;

public class PatchSaleCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}
