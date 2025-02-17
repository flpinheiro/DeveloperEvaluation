using Ambev.DeveloperEvaluation.Unit.Domain.ValueObjects.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.ValueObjects;

public class ProductSaleTest
{
    [Fact(DisplayName = "Should calculate total amount and discount when CalculateTotalAmount is Called")]
    public void Given_ValidProductSaleData_CalculateTotalAmount()
    {
        // Arrange
        var productSale = ProductSaleTestData.GenerateValidProductSale();
        // Act
        productSale.CalculateTotalAmount();
        var expectedTotalAmount = productSale.Quantity * productSale.Product?.Price * (1M - productSale.Discount / 100M) ?? 0;
        // Assert
        Assert.Equal(expectedTotalAmount, productSale.TotalAmout);
    }
}
