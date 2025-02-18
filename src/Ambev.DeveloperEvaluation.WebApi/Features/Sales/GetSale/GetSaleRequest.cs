namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

/// <summary>
/// data to get a sale
/// </summary>
public class GetSaleRequest
{
    /// <summary>
    /// sale id
    /// </summary>
    public Guid Id { get; internal set; }
}
