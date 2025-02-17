using Ambev.DeveloperEvaluation.Domain.Dtos;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.PatchProductSale;

public class PatchProductSaleCommand : IRequest<bool>
{
    public Guid Id { get; internal set; }

    public IEnumerable<ProductRequestDto> Products { get; set; } = [];
}
