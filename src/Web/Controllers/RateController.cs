using Application.Services;
using Domain.Dtos.Request;
using Domain.Dtos.Response;
using Infrastructure.Errors;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

/// <summary>
/// Represents the API for managing rates.
/// </summary>
[ApiController]
public class RateController : ControllerBase
{
    private RateService _rateService;
    /// <summary>
    /// Controller for managing rates.
    /// </summary>
    public RateController(RateService rateService)
    {
        _rateService = rateService;
    }

    /// <summary>
    ///  Rate a movie
    /// </summary>
    /// <returns> Rating created. </returns>
    /// 
    [HttpPost("rates")]
    [ProducesResponseType(typeof(IEnumerable<InsertRateResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Insert(InsertRateRequest request)
    {
        return Created("/v1/rates", await _rateService.Insert(request));
    }
}
