using AutoMapper;
using SaleEntity = Ambev.DeveloperEvaluation.Domain.Entities.Sale;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleCommandProfile : Profile
{
    public GetSaleCommandProfile()
    {
        CreateMap<SaleEntity, GetSaleResult>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.ProductSales));
    }
}
