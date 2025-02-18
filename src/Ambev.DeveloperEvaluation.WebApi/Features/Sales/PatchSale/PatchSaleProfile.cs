
using Ambev.DeveloperEvaluation.Application.Sales.PatchSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.PatchSale;

public class PatchSaleProfile : Profile
{
    public PatchSaleProfile()
    {
        CreateMap<PatchSaleRequest, PatchSaleCommand>();
    }
}
