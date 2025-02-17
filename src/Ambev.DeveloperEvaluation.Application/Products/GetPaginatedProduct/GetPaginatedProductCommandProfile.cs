using Ambev.DeveloperEvaluation.Domain.Dtos;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.GetPaginatedProduct;

public class GetPaginatedProductCommandProfile : Profile
{
    public GetPaginatedProductCommandProfile()
    {
        CreateMap<GetPaginatedProductCommand, GetPaginatedProductDto>();
        CreateMap<Product, GetPaginatedProductResult>();
    }
}
