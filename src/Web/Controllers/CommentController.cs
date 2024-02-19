using Application.Services;
using Domain.Entities;
using Infrastructure.Errors;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

/// <summary>
/// Represents the API for managing comments.
/// </summary>
[ApiController]
public class CommentController : ControllerBase
{
    private CommentService _commentService;
    /// <summary>
    /// Controller for managing movies.
    /// </summary>
    public CommentController(CommentService commentService)
    {
        _commentService = commentService;
    }

    /// <summary>
    /// Retrieve a list of comments.
    /// </summary>
    /// <returns>List of movies.</returns>
    /// 
    [HttpGet("comments")]
    [ProducesResponseType(typeof(IEnumerable<CommentEntity>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetComments()
    {
        return Ok(await _commentService.GetComments());
    }
}
