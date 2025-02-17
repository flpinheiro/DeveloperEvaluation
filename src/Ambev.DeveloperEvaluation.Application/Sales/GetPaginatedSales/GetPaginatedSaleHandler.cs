using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Dtos;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetPaginatedSales;

public class GetPaginatedSaleHandler : IRequestHandler<GetPaginatedSalesCommand, PaginatedList<GetPaginatedSaleResult>>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public GetPaginatedSaleHandler(ISaleRepository saleRepository, IMapper mappper, IUserService userService)
    {
        _saleRepository = saleRepository;
        _mapper = mappper;
        _userService = userService;
    }

    public async Task<PaginatedList<GetPaginatedSaleResult>> Handle(GetPaginatedSalesCommand request, CancellationToken cancellationToken)
    {
        var dto = _mapper.Map<GetPaginatedSaleDto>(request);
        if (_userService.UserId == Guid.Empty) throw new Exception("User not found");
        dto.UserId = _userService.UserId;

        var sales = await _saleRepository.GetAsync(dto, cancellationToken);

        var result = _mapper.Map<PaginatedList<GetPaginatedSaleResult>>(sales);

        return result;
    }
}
