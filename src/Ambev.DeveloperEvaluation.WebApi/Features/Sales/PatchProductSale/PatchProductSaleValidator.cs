using Ambev.DeveloperEvaluation.Application.Sales.PatchProductSale;
using AutoMapper;


namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.PatchProductSale;

public class PatchProductSaleValidator : Profile
{
    public PatchProductSaleValidator()
    {
        CreateMap<PatchProductSaleRequest, PatchProductSaleCommand>();
    }
}
