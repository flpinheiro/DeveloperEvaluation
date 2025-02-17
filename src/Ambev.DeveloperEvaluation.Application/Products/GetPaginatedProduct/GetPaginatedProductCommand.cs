using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Domain.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetPaginatedProduct;

public class GetPaginatedProductCommand : PaginatedCommand, IRequest<PaginatedList<GetPaginatedProductResult>>
{
}
