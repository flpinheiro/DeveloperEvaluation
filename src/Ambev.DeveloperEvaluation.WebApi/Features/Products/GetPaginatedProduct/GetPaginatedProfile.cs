using Ambev.DeveloperEvaluation.Application.Products.GetPaginatedProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetPaginatedProduct;

public class GetPaginatedProfile : Profile
{
    public GetPaginatedProfile()
    {
        CreateMap<GetPaginatedProductRequest, GetPaginatedProductCommand>();
        CreateMap<GetPaginatedProductResult, GetPaginatedProductResponse>();
    }
}
