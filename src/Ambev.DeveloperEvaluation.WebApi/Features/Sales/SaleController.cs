using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetPaginatedSales;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Application.Sales.PatchProductSale;
using Ambev.DeveloperEvaluation.Application.Sales.PatchSale;
using Ambev.DeveloperEvaluation.Application.Sales.RemoveProductSale;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetPaginatedSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.PatchProductSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.PatchSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.RemoveProductSale;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

/// <summary>
/// Controller for sale operation
/// </summary>
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class SaleController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of SaleController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public SaleController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Get all sales paginated for the user authenticated
    /// </summary>
    /// <param name="request">request information to que the sales</param>
    /// <param name="cancellationToken">canceltion token</param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponseWithData<Domain.Common.PaginatedList<GetPaginatedSaleResponse>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSale([FromQuery] GetPaginatedSaleRequest request, CancellationToken cancellationToken)
    {
        var validator = new PaginatedRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetPaginatedSalesCommand>(request);

        var result = await _mediator.Send(command, cancellationToken);

        var response = _mapper.Map<Domain.Common.PaginatedList<GetPaginatedSaleResponse>>(result);

        return Ok(
            new ApiResponseWithData<Domain.Common.PaginatedList<GetPaginatedSaleResponse>>()
            {
                Success = true,
                Message = "Sale retrieved successfully",
                Data = response
            });
    }

    /// <summary>
    /// Get sale be id
    /// </summary>
    /// <param name="id">sale id to be retrieved</param>
    /// <param name="cancellationToken">cancelation token</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetSaleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSale([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetSaleRequest { Id = id };
        var validadator = new GetSaleRequestValidator();

        var validationResult = await validadator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetSaleCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<GetSaleResponse>
        {
            Success = true,
            Message = "Sale retrieved successfully",
            Data = _mapper.Map<GetSaleResponse>(response)
        });
    }

    /// <summary>
    /// Create a new sale
    /// </summary>
    /// <param name="request">sale data to be created</param>
    /// <param name="cancellationToken">cancelation token</param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateSale([FromBody] CreateSaleRequest request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validate();

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateSaleCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<CreateSaleResponse>
        {
            Success = true,
            Message = "Sale created successfully",
            Data = _mapper.Map<CreateSaleResponse>(response)
        });
    }

    /// <summary>
    /// cancel the sale.
    /// 
    /// The sale only can be cancelled if status is Active, otherelse return false
    /// </summary>
    /// <param name="id">sale id to be cancelled</param>
    /// <param name="cancellationToken">cancelation token</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteSale([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteSaleRequest { Id = id };
        var validadator = new DeleteSaleRequestValidator();

        var validationResult = await validadator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<DeleteSaleCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        if (!response) return BadRequest("Unable to Cancel Sale");

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Sale Calceled successfully",
        });
    }

    /// <summary>
    /// cancel products on the sale
    /// </summary>
    /// <param name="id">sale id of the products</param>
    /// <param name="request">data od the products to be cancelled</param>
    /// <param name="cancellationToken">cancellation token</param>
    /// <returns></returns>
    [HttpDelete("{id}/Product")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RemoveProductSale([FromRoute] Guid id, [FromBody] RemoveProductSaleRequest request, CancellationToken cancellationToken)
    {
        request.Id = id;

        var validationResult = request.Validate();

        if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

        var command = _mapper.Map<RemoveProductSaleCommand>(request);

        var result = await _mediator.Send(command, cancellationToken);

        if (!result) return BadRequest(new ApiResponse() { Success = false, Message = " unable to cancel product item form sale" });

        return Ok(new ApiResponse() { Success = true, Message = "Product Item canceled with success" });
    }

    /// <summary>
    /// Update sale status
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <remarks>
    /// <listheader>The update list:</listheader> 
    /// <list type="bullet">cancel -> active</list>
    /// <list type="bullet">active -> payed</list>
    /// <list type="bullet">payed -> delivery</list>
    /// <list type="bullet">delivery -> finished</list>
    /// </remarks>
    [HttpPatch("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PatchSale([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new PatchSaleRequest { Id = id };
        var validatorResult = request.Validate();
        if (!validatorResult.IsValid)
            return BadRequest(validatorResult.Errors);

        var command = _mapper.Map<PatchSaleCommand>(request);

        var result = await _mediator.Send(command, cancellationToken);

        if (!result) return BadRequest(new ApiResponse { Message = "Unable to update sale", Success = false });

        return Ok(new ApiResponse { Success = true, Message = "Sale updated successfully" });
    }

    /// <summary>
    /// update product quantity
    /// </summary>
    /// <param name="id">sale id</param>
    /// <param name="request">request data to be updated</param>
    /// <param name="cancellationToken">cancellation token</param>
    /// <returns></returns>
    [HttpPatch("{id}/Product")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PatchProductSale([FromRoute] Guid id, [FromBody] PatchProductSaleRequest request, CancellationToken cancellationToken)
    {
        request.Id = id;
        var validationResult = request.Validate();

        if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

        var command = _mapper.Map<PatchProductSaleCommand>(request);

        var result = await _mediator.Send(command, cancellationToken);

        if (!result) return BadRequest(new ApiResponse() { Success = false, Message = "Unable to update sale" });

        return Ok(new ApiResponse() { Success = true, Message = "Sale sucefully updated" });
    }
}