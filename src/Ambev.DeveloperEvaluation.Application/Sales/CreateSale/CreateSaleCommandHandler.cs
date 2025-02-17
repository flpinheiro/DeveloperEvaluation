using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using AutoMapper;
using MediatR;
using Rebus.Bus;
using SaleEntity = Ambev.DeveloperEvaluation.Domain.Entities.Sale;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    private readonly ISaleRepository _saleRepository;
    private readonly IBus _bus;
    private readonly IUserService _userService;

    public CreateSaleCommandHandler(IProductRepository productRepository, ISaleRepository saleRepository, IMapper mapper, IBus bus, IUserService userService)
    {
        _productRepository = productRepository;
        _saleRepository = saleRepository;
        _mapper = mapper;
        _bus = bus;
        _userService = userService;
    }

    public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetManyById(request.Products.Select(p => p.ProductId), cancellationToken);

        var productSales = new List<ProductSale>();
        foreach (var product in products)
        {
            if (product != null)
            {
                var productSale = new ProductSale
                {
                    ProductId = product.Id,
                    Product = product,
                    Quantity = request.Products.First(p => p.ProductId == product.Id).Quantity
                };
                productSales.Add(productSale);
            }
        }
        var userId = _userService.UserId;
        if(userId == Guid.Empty)
        {
            throw new Exception("User not found");
        }
        var sale = new SaleEntity
        {
            Id = Guid.NewGuid(),
            ProductSales = productSales,
            UserId = userId,
        };
        sale.CalculateTotalValue();
        foreach (var productSale in productSales)
        {
            productSale.SaleId = sale.Id;
            productSale.Sale = sale;
        }

        await _saleRepository.CreateAsync(sale, cancellationToken);

        var result = _mapper.Map<CreateSaleResult>(sale);

        await _bus.Publish(new CreateSaleEvent() { Id = sale.Id });

        return result;
    }
}