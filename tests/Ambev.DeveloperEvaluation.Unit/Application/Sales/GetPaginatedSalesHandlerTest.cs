using Ambev.DeveloperEvaluation.Application.Sales.GetPaginatedSales;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Dtos;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Ambev.DeveloperEvaluation.Unit.Fixtures;
using AutoMapper;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales;

public class GetPaginatedSalesHandlerTest
{
    private readonly GetPaginatedSaleHandler _handler;
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public GetPaginatedSalesHandlerTest()
    {
        _userService = Substitute.For<IUserService>();
        _mapper = MapperFixture.CreateMapper(new GetPaginatedSalesCommandProfile());
        _saleRepository = Substitute.For<ISaleRepository>();
        _handler = new GetPaginatedSaleHandler(_saleRepository, _mapper, _userService);
    }

    [Fact]
    public async Task Should_Get_Paginated_Sales()
    {
        var command = new GetPaginatedSalesCommand
        {
            PageNumber = 1,
            PageSize = 10
        };

        var sales = SaleTestData.GenerateValidSales(10);

        var paginatedSales = new PaginatedList<Sale>(sales.ToList(),   sales.Count(), 1, 10);

        _userService.UserId.Returns(Guid.NewGuid());

        _saleRepository.GetAsync(Arg.Any<GetPaginatedSaleDto>(), default).Returns(paginatedSales);

        var result = await _handler.Handle(command, default);

        Assert.NotNull(result);
    }
}
