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
    private UserService _userService;
    /// <summary>
    /// Controller for managing marketplace users.
    /// </summary>
    public OrderController(UserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Retrieve a list of all orders with all statuses from database.
    /// </summary>
    /// <returns>List of users.</returns>
    /// 
    [HttpGet("orders")]
    [ProducesResponseType(typeof(IEnumerable<UserEntity>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get()
    {
        return Ok(await _userService.Get());
    }

    /// <summary>
    ///  Add a new order.
    /// </summary>
    /// <returns> New order created. </returns>
    /// 
    [HttpPost("orders")]
    [ProducesResponseType(typeof(IEnumerable<InsertItemResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Insert(InsertItemRequest request)
    {
        return Created("/v1/items", await _itemService.Insert(request));
    }

}
