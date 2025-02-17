using Ambev.DeveloperEvaluation.Application.Sales.PatchProductSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.Sales.TestData;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales;

public class PatchProductSaleTest
{
    private readonly PatchProductSaleCommandhandler _handler;
    private readonly ISaleRepository _saleRepository;
    private readonly IProductRepository _productRepository;
    public PatchProductSaleTest()
    {
        _saleRepository = Substitute.For<ISaleRepository>();
        _productRepository = Substitute.For<IProductRepository>();
        _handler = new PatchProductSaleCommandhandler(_saleRepository, _productRepository);
    }

    [Fact]
    public async Task Should_Fatch_Products_on_Sale()
    {
        var sale = SaleTestData.GenerateValidSale();

        var products = ProductTestData.GenerateValidProducts(10).ToList();

#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
        products.AddRange(sale.ProductSales.Select(ps => ps.Product));
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.

        _saleRepository.GetByIdAsync(Arg.Any<Guid>(), default).Returns(sale);

        _productRepository.GetManyById(Arg.Any<IEnumerable<Guid>>(), default).Returns(products);

        var command = new PatchProductSaleCommandTestData().WithProducts(products).GenerateValidPatchProductSaleCommand();

        var result = await _handler.Handle(command, default);

        Assert.True(result);

        await _saleRepository.Received(1).UpdateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
    }
}
