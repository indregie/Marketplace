using Application.Services;
using Domain.Dtos.Request;
using Domain.Dtos.Response;
using Infrastructure.Errors;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

/// <summary>
/// Represents the API functionality for managing items in the marketplace.
/// </summary>
[ApiController]
public class ItemController : ControllerBase
{
    private ItemService _itemService;
    /// <summary>
    /// Controller for managing items.
    /// </summary>
    public ItemController(ItemService itemService)
    {
        _itemService = itemService;
    }

    /// <summary>
    ///  Add a new item.
    /// </summary>
    /// <returns> New item created. </returns>
    /// 
    [HttpPost("items")]
    [ProducesResponseType(typeof(IEnumerable<InsertItemResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Insert(InsertItemRequest request)
    {
        return Created("/v1/items", await _itemService.Insert(request));
    }

    /// <summary>
    /// Retrieve a list of all items from the database.
    /// </summary>
    /// <returns>List of items.</returns>
    /// 
    [HttpGet("items")]
    [ProducesResponseType(typeof(GetItemsResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get()
    {
        return Ok(await _itemService.Get());
    }
}
