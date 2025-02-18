namespace Ambev.DeveloperEvaluation.WebApi.Common;

public abstract class PaginatedRequest
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
