using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Events;

public class PatchSaleEvent
{
    public SaleStatus Status { get; set; }
    public Guid Id { get; set; }
}
