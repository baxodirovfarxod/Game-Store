using System.Net.NetworkInformation;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace GameStore.Api.ExceptionHandlingMiddleWare;


public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
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
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
           
            switch (ex)
            {
                case NotFoundException notFoundEx:
                    statusCode = HttpStatusCode.NotFound; 
                    _logger.LogWarning($"Not Found: {notFoundEx.Message}");
                    break;
                case UnauthorizedAccessException unauthorizedEx:
                    statusCode = HttpStatusCode.Unauthorized; 
                    _logger.LogWarning($"Unathorized Access: {unauthorizedEx.Message}");
                    break;
               
                    break;
                case ConflictException conflictEx:
                    statusCode = HttpStatusCode.Conflict; 
                    _logger.LogWarning($"Conflict: {conflictEx.Message}");
                    break;
             
                default:
                    _logger.LogError(ex, "Error Ocurred");
                    break;
            }

            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";

            var errorResponse = new
            {
                statusCode = (int)statusCode,
                message = GetErrorMessageForStatusCode(statusCode), 
                details = ex.Message 
            };

            await context.Response.WriteAsJsonAsync(errorResponse);
        }
    }

    private string GetErrorMessageForStatusCode(HttpStatusCode statusCode)
    {
        return statusCode switch
        {
            HttpStatusCode.NotFound => "Not Found",
            HttpStatusCode.Unauthorized => "Not have access for this source",
            HttpStatusCode.Conflict => "Conflict ocuured",
            _ => "Error Ocurred"
        };
    }
}


public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) { }
}

public class UnauthorizedAccessException : Exception
{
    public UnauthorizedAccessException(string message) : base(message) { }
}

public class ConflictException : Exception
{
    public ConflictException(string message) : base(message) { }
}


