using Application.Services;
using Domain.Dtos.Request;
using Domain.Dtos.Response;
using Domain.Entities;
using Infrastructure.Errors;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

/// <summary>
/// Represents the API functionality for managing orders.
/// </summary>
[ApiController]
public class OrderController : ControllerBase
{
    private OrderService _orderService;
    /// <summary>
    /// Controller for managing marketplace users.
    /// </summary>
    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }

    /// <summary>
    /// Retrieve a list of all orders with all statuses from database.
    /// </summary>
    /// <returns>List of users.</returns>
    /// 
    //[HttpGet("orders")]
    //[ProducesResponseType(typeof(IEnumerable<UserEntity>), StatusCodes.Status200OK)]
    //[ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    //public async Task<IActionResult> Get()
    //{
    //    return Ok(await _userService.Get());
    //}

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
        return Ok(/*await _orderService.SetAsCompleted(id)*/);
    }

}

