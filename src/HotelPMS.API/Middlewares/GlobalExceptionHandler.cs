using System.Net;
using System.Text.Json;
using FluentValidation;
using HotelPMS.Domain.Exceptions;

namespace HotelPMS.API.Middlewares;

public class GlobalExceptionHandler
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        var response = context.Response;

        int statusCode = (int)HttpStatusCode.InternalServerError;
        string result;

        switch (exception)
        {
            case DomainException domainEx:
                statusCode = (int)HttpStatusCode.BadRequest;
                result = JsonSerializer.Serialize(new { message = domainEx.Message, statusCode });
                break;
            case FluentValidation.ValidationException valEx:
                statusCode = (int)HttpStatusCode.BadRequest;
                var errors = valEx.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
                result = JsonSerializer.Serialize(new { message = "Validation failed", errors, statusCode });
                break;
            case KeyNotFoundException:
                statusCode = (int)HttpStatusCode.NotFound;
                result = JsonSerializer.Serialize(new { message = exception.Message, statusCode });
                break;
            default:
                result = JsonSerializer.Serialize(new { message = exception.Message, statusCode });
                break;
        }

        response.StatusCode = statusCode;
        await response.WriteAsync(result);
    }
}