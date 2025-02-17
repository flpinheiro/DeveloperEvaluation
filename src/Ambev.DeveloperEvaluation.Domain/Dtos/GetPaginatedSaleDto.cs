using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Dtos;

public class GetPaginatedSaleDto : PaginatedDto
{
    public Guid UserId { get; set; }
}
