using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Domain.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetPaginatedSales;

public class GetPaginatedSalesCommand : PaginatedCommand, IRequest<PaginatedList<GetPaginatedSaleResult>>
{
}
