using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Dtos;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DefaultContext _context;
    public ProductRepository(DefaultContext context)
    {
        _context = context;
    }
    public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync(cancellationToken);
        return product;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await GetByIdAsync(id, cancellationToken);
        if (product is null) return false;

        _context.Products.Remove(product);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Product>> GetManyById(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
    {
        return await _context.Products.Where(p => ids.Contains(p.Id)).ToListAsync(cancellationToken);
    }

    public Task<PaginatedList<Product>> GetPaginatedProducts(GetPaginatedProductDto dto, CancellationToken cancellationToken = default)
    {
        return _context.Products.ToPaginatedListAsync(dto.PageNumber, dto.PageSize);
    }

    public Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
