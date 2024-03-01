using Application.Interfaces;
using Application.Services;
using Domain.Dtos.Request;
using Domain.Dtos.Response;
using Infrastructure.Errors;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

/// <summary>
/// Represents the API functionality for managing orders.
/// </summary>
[ApiController]
public class OrderController : ControllerBase
{
    private IOrderService _orderService;
    /// <summary>
    /// Controller for managing marketplace users.
    /// </summary>
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    /// <summary>
    ///  Add a new order.
    /// </summary>
    /// <returns> New order created. </returns>
    /// 
    [HttpPost("orders")]
    [ProducesResponseType(typeof(IEnumerable<InsertOrderResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Insert(InsertOrderRequest request)
    {
        return Created("/v1/orders", await _orderService.Insert(request));
    }

    /// <summary>
    ///  Set order as paid.
    /// </summary>
    /// <returns> Order marked as paid. </returns>
    /// 
    [HttpPut("orders/{id}/pay")]
    [ProducesResponseType(typeof(OrderPaidResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> SetOrderAsPaid(int id)
    {
        return Ok(await _orderService.SetAsPaid(id));
    }

    /// <summary>
    ///  Set order as completed.
    /// </summary>
    /// <returns> Order marked as completed. </returns>
    /// 
    [HttpPut("orders/{id}/complete")]
    [ProducesResponseType(typeof(OrderCompletedResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> SetOrderAsCompleted(int id)
    {
        return Ok(await _orderService.SetAsCompleted(id));
    }

    /// <summary>
    /// Retrieve a list of orders for a specific user.
    /// </summary>
    /// <returns>List of orders.</returns>
    /// 
    [HttpGet("orders")]
    [ProducesResponseType(typeof(IEnumerable<UserOrdersResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromQuery] int userId)
    {
        return Ok(await _orderService.GetOrders(userId));
    }
}

