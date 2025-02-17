using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

public class SaleTest
{
    [Fact(DisplayName = "Should Calculate total value when calculate total value is called")]
    public void Given_ValidSaleData_CalculateTotalValue()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        // Act
        sale.CalculateTotalValue();
        var expectedTotalValue = sale.ProductSales.Sum(ps => ps.TotalAmout);
        // Assert
        Assert.Equal(expectedTotalValue, sale.TotalValue);
    }
}
