using Ambev.DeveloperEvaluation.Domain.Dtos;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetPaginatedSales;

public class GetPaginatedSalesCommandProfile : Profile
{
    public GetPaginatedSalesCommandProfile()
    {
        CreateMap<Sale, GetPaginatedSaleResult>()
            .ForMember(dest => dest.ProductCount, opt => opt.MapFrom(dest => dest.ProductSales.Count()));
        CreateMap<GetPaginatedSalesCommand, GetPaginatedSaleDto>();
    }
}
