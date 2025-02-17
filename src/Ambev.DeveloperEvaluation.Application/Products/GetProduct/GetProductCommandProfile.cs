using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

public class GetProductCommandProfile : Profile
{
    public GetProductCommandProfile()
    {
        CreateMap<Product, GetProductResult>();
    }
}
