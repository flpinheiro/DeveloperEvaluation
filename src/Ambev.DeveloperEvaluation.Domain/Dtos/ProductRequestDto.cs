namespace Ambev.DeveloperEvaluation.Domain.Dtos;

public class ProductRequestDto
{
    /// <summary>
    /// Gets the product id and product information.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets the product quantity.
    /// </summary>
    public int Quantity { get; set; }
}

public static class ProductRequestDtoExtensions
{
    public static IEnumerable<ProductRequestDto> JoinProductRequestDto(this IEnumerable<ProductRequestDto> request)
    {
        var ids = request.Select(p => p.ProductId).Distinct().ToList();
        var products = new List<ProductRequestDto>();

        foreach (var id in ids)
        {
            var dto = new ProductRequestDto
            {
                ProductId = id,
                Quantity = request.Where(p => p.ProductId == id).Sum(p => p.Quantity),
            };
            products.Add(dto);
        }
        return products;
    }
}
