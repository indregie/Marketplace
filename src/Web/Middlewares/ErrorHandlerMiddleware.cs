using Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace Web.Middlewares;
/// <summary>
/// </summary>
public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;
    /// <summary>
    /// </summary>
    public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    /// <summary>
    /// </summary>
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            switch (error)
            {
                case ItemNotFoundException e:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case UserNotFoundException e:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case OrderNotFoundException e:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case InvalidNameException e:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case InvalidRateException e:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                default:
                    // unhandled error
                    _logger.LogError(error, error.Message);
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var result = JsonSerializer.Serialize(new { message = error?.Message });
            await response.WriteAsync(result);
        }
    }
}
