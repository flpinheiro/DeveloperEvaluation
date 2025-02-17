using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Dtos;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface IProductRepository
{
    /// <summary>
    /// Create a new product
    /// </summary>
    /// <param name="product">product to be created</param>
    /// <param name="cancellationToken">cancelation token</param>
    /// <returns>product created</returns>
    Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default);
    /// <summary>
    /// Get a product by id
    /// </summary>
    /// <param name="id">id of the product</param>
    /// <param name="cancellationToken">cancelation token</param>
    /// <returns>return a product or null</returns>
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Get many products by ids
    /// </summary>
    /// <param name="ids">list of id of products to be searched</param>
    /// <param name="cancellationToken">cancelation token</param>
    /// <returns>return a list of products</returns>
    Task<IEnumerable<Product>> GetManyById(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
    /// <summary>
    /// logicall delete a product (set status to canceled)
    /// </summary>
    /// <param name="id">id of the product</param>
    /// <param name="cancellationToken">cancelation token</param>
    /// <returns>return bool</returns>
    /// <remarks>return false if product not found</remarks>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Update a product
    /// </summary>
    /// <param name="product">product to be updated</param>
    /// <param name="cancellationToken">cancelation token</param>
    /// <returns>product updated</returns>
    Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default);
    /// <summary>
    /// Get a paginated list of products
    /// </summary>
    /// <param name="dto">infromation of the pagination</param>
    /// <param name="cancellationToken">cancelation token</param>
    /// <returns>a list of products</returns>
    Task<PaginatedList<Product>> GetPaginatedProducts(GetPaginatedProductDto dto, CancellationToken cancellationToken = default);
}
