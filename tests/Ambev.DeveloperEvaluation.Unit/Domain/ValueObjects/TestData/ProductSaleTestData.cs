using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.ValueObjects.TestData;

public static class ProductSaleTestData
{
    private static readonly Faker<ProductSale> ProductSaleFaker = new Faker<ProductSale>()
        .RuleFor(p => p.Quantity, f => f.Random.Number(1, 20))
        .RuleFor(p => p.Product, ProductTestData.GenerateValidProduct())
        .RuleFor(p => p.ProductId, (f, c) => c.Product?.Id ?? f.Random.Guid());


    private static Faker<ProductSale> WithSale(this Faker<ProductSale> faker, Sale sale) => faker
        .RuleFor(p => p.Sale, sale)
        .RuleFor(p => p.SaleId, sale.Id);

    public static ProductSale GenerateValidProductSale() => ProductSaleFaker.Generate();

    public static ProductSale GenerateValidProductSale(Sale sale) => ProductSaleFaker.WithSale(sale).Generate();

    public static IEnumerable<ProductSale> GenerateValidProductSales(int count) => ProductSaleFaker.Generate(count);

    public static IEnumerable<ProductSale> GenerateValidProductSales(int count, Sale sale) => ProductSaleFaker.WithSale(sale).Generate(count);
}
