using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.PatchProductSale;

public class PatchProductSaleCommandhandler : IRequestHandler<PatchProductSaleCommand, bool>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IProductRepository _productRepository;

    public PatchProductSaleCommandhandler(ISaleRepository saleRepository, IProductRepository productRepository)
    {
        _saleRepository = saleRepository;
        _productRepository = productRepository;
    }

    public async Task<bool> Handle(PatchProductSaleCommand request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetManyById(request.Products.Select(p => p.ProductId), cancellationToken);

        var sale = await _saleRepository.GetByIdAsync(request.Id, cancellationToken);

        if (sale == null || sale.Status != Domain.Enums.SaleStatus.Active) return false;

        foreach (var product in products)
        {
            var productSale = sale.ProductSales.FirstOrDefault(ps => ps.ProductId == product.Id);
            var quantity = request.Products.First(p => p.ProductId == product.Id).Quantity;

            if (productSale == null)
            {
                var newProductSale = new ProductSale
                {
                    ProductId = product.Id,
                    Product = product,
                    Quantity = quantity,
                    SaleId = sale.Id,
                    Sale = sale
                };
                sale.ProductSales.Add(newProductSale);
            }
            else
            {
                var oldProductSale = sale.ProductSales.FirstOrDefault(ps => ps.ProductId == product.Id);
                if (oldProductSale != null)
                {
                    oldProductSale.Quantity = quantity;
                    oldProductSale.Status = Domain.Enums.SaleStatus.Active;
                }
            }
        }

        sale.CalculateTotalValue();
        await _saleRepository.UpdateAsync(sale, cancellationToken);

        return true;
    }
}
