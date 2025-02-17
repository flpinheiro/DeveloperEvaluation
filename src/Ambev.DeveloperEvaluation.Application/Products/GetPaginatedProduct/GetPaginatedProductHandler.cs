using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Dtos;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetPaginatedProduct;

public class GetPaginatedProductHandler : IRequestHandler<GetPaginatedProductCommand, PaginatedList<GetPaginatedProductResult>>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    public GetPaginatedProductHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<PaginatedList<GetPaginatedProductResult>> Handle(GetPaginatedProductCommand request, CancellationToken cancellationToken)
    {
        var dto = _mapper.Map<GetPaginatedProductDto>(request);

        var products = await _productRepository.GetPaginatedProducts(dto, cancellationToken);

        var result = _mapper.Map<PaginatedList<GetPaginatedProductResult>>(products);

        return result;
    }
}