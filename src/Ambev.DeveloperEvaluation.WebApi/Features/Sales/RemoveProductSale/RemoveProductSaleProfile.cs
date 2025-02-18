using Ambev.DeveloperEvaluation.Application.Sales.RemoveProductSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.RemoveProductSale;

public class RemoveProductSaleProfile : Profile
{
    public RemoveProductSaleProfile()
    {
        CreateMap<RemoveProductSaleRequest, RemoveProductSaleCommand>();
    }
}