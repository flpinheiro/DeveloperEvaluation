using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Dtos;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ISaleRepository
{
    /// <summary>
    /// create a new sale
    /// </summary>
    /// <param name="sale">sale information</param>
    /// <param name="cancellationToken">cancelation token</param>
    /// <returns>the sale created</returns>
    Task<Sale?> CreateAsync(Sale sale, CancellationToken cancellationToken = default);
    /// <summary>
    /// get sale by id
    /// </summary>
    /// <param name="id">id of the sale to be queried</param>
    /// <param name="cancellationToken">cancelation toekn</param>
    /// <returns>a sale</returns>
    Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// get sales paginated
    /// </summary>
    /// <param name="request">information of the pagination</param>
    /// <param name="cancellationToken">cancelation token</param>
    /// <returns>a list of sales</returns>
    Task<PaginatedList<Sale>> GetAsync(GetPaginatedSaleDto request, CancellationToken cancellationToken = default);
    /// <summary>
    /// logic delete a sale (set status to canceled)
    /// </summary>
    /// <param name="id">if of the sale</param>
    /// <param name="cancellationToken">cancelation token</param>
    /// <returns>bool</returns>
    /// <remarks>return true if the sale was deleted</remarks>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// update a sale
    /// </summary>
    /// <param name="sale">sale to be updated</param>
    /// <param name="cancellationToken">cancelation token</param>
    /// <returns>the sale updated</returns>
    Task<Sale?> UpdateAsync(Sale sale, CancellationToken cancellationToken = default);
}