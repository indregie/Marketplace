using Application.Services;
using Domain.Dtos.Response;
using Domain.Entities;
using Infrastructure.Errors;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

/// <summary>
/// Represents the API functionality for managing users.
/// </summary>
[ApiController]
public class UserController : ControllerBase
{
    private UserService _userService;
    /// <summary>
    /// Controller for managing marketplace users.
    /// </summary>
    public UserController(UserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Retrieve a list of possible marketplace users from external API.
    /// </summary>
    /// <returns>List of users.</returns>
    /// 
    [HttpGet("users")]
    [ProducesResponseType(typeof(IEnumerable<UserEntity>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get()
    {
        return Ok(await _userService.Get());
    }
}
