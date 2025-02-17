using Ambev.DeveloperEvaluation.Application.Sales.RemoveProductSale;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales;

public class RemoveProductSaleTest
{
    private readonly RemoveProductSaleCommandHandler _handler;
    private readonly ISaleRepository _saleRepository;
    public RemoveProductSaleTest()
    {
        _saleRepository = Substitute.For<ISaleRepository>();
        _handler = new RemoveProductSaleCommandHandler(_saleRepository);
    }

    [Fact]
    public async Task Should_Remove_Product_From_Sale()
    {
        var sale = SaleTestData.GenerateValidSale();

        var productsToRemove = sale.ProductSales.Select(p => p.ProductId).Take(sale.ProductSales.Count()/2);

        var request = new RemoveProductSaleCommand
        {
            Id = sale.Id,
            Products = productsToRemove
        };

        _saleRepository.GetByIdAsync(sale.Id, default).Returns(sale);

        var result = await _handler.Handle(request, default);

        Assert.True(result);

        await _saleRepository.Received(1).UpdateAsync(sale, default);

        sale.ProductSales
            .Where(p => productsToRemove.Contains(p.ProductId))
            .ToList()
            .ForEach(p =>
            {
                Assert.Equal(0, p.Quantity);
                Assert.Equal(SaleStatus.Canceled, p.Status);
            });
    }
}
