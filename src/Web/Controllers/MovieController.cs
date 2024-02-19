using Application.Services;
using Domain.Dtos.Request;
using Domain.Dtos.Response;
using Domain.Entities;
using Infrastructure.Errors;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

/// <summary>
/// Represents the API for managing movies.
/// </summary>
[ApiController]
public class MovieController : ControllerBase
{
    private MovieService _movieService;
    /// <summary>
    /// Controller for managing movies.
    /// </summary>
    public MovieController(MovieService movieService)
    {
        _movieService = movieService;
    }

    /// <summary>
    /// Retrieve a list of movies.
    /// </summary>
    /// <returns>List of movies.</returns>
    /// 
    [HttpGet("movies")]
    [ProducesResponseType(typeof(GetAllMoviesResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get()
    {
        return Ok(await _movieService.GetMovies());
    }

    /// <summary>
    /// Adds a movie to Movie database.
    /// </summary>
    /// <returns>A movie that was created.</returns>
    /// 
    [HttpPost("movies")]
    [ProducesResponseType(typeof(IEnumerable<InsertRateResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Insert(InsertMovieRequest request)
    {
        return Created("/v1/movies", await _movieService.Insert(request));
    }

    /// <summary>
    /// Retrieve a single movie by its id with average rating and comments.
    /// </summary>
    /// <returns>Movie by id.</returns>
    /// 
    [HttpGet("movies/{id}")]
    [ProducesResponseType(typeof(GetMovieByIdResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _movieService.Get(id));
    }


}
