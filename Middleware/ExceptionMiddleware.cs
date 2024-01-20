using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Diagnostics;
using System.Net.Http;



public class ErrorResponse
{
    public int Status { get; set; }

    public string Title { get; set; }
}


internal sealed class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(
            exception, "Exception occurred: {Message}", exception.Message);

        var problemDetails = new ErrorResponse
        {
            Status = 666,
            Title = "Server error"
        };

        httpContext.Response.StatusCode = problemDetails.Status;

        await httpContext.Response
            .WriteAsJsonAsync(exception.Message, cancellationToken);

        return true;
    }
}
