using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using Ambev.DeveloperEvaluation.Unit.Application.Sales.TestData;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Ambev.DeveloperEvaluation.Unit.Fixtures;
using AutoMapper;
using NSubstitute;
using Rebus.Bus;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales;

public class CreateSaleCommandHandlerTest
{
    private readonly CreateSaleCommandHandler _handler;
    private readonly ISaleRepository _saleRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IBus _bus;
    private readonly IUserService _userService;

    public CreateSaleCommandHandlerTest()
    {
        _mapper = MapperFixture.CreateMapper(new CreateSaleCommandProfile());
        _productRepository = Substitute.For<IProductRepository>();
        _saleRepository = Substitute.For<ISaleRepository>();
        _bus = Substitute.For<IBus>();
        _userService = Substitute.For<IUserService>();
        _handler = new CreateSaleCommandHandler(_productRepository, _saleRepository, _mapper, _bus, _userService);
    }

    [Fact]
    public async Task Should_Create_New_Sale()
    {
        // Arrange
        var products = ProductTestData.GenerateValidProducts(10);
        var request = new CreateSaleCommandTestData()
            .WithProducts(products)
            .GenerateValidCreateSaleCommand();

        _productRepository.GetManyById(Arg.Any<IEnumerable<Guid>>(), default).Returns(products);

        _userService.UserId.Returns(Guid.NewGuid());

        // Act
        var result = await _handler.Handle(request, default);
        // Assert
        Assert.NotNull(result);

        await _saleRepository.Received(1).CreateAsync(Arg.Any<Sale>(), default);
        await _bus.Received(1).Publish(Arg.Any<CreateSaleEvent>());
    }
}
