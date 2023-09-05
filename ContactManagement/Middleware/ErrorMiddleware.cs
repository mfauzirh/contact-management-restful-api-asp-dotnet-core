using System.Net;
using System.Text.Json;
using ContactManagement.Exceptions;
using ContactManagement.Models;

namespace ContactManagement.Middleware;

public class ErrorMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ResponseException ex)
        {
            await SendErrorResponse(context, "application/json", ex.StatusCode, ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message); // change this to logger
            await SendErrorResponse(context, "application/json", HttpStatusCode.InternalServerError, "Server error occurred");
        }
    }

    private static async Task SendErrorResponse(HttpContext context, string contentType, HttpStatusCode statusCode, string errorMessage)
    {
        context.Response.ContentType = contentType;
        context.Response.StatusCode = (int)statusCode;

        var errorResponse = new Response<object>
        {
            Data = null,
            Success = false,
            Errors = errorMessage
        };

        var jsonErrorResponse = JsonSerializer.Serialize(errorResponse);

        await context.Response.WriteAsync(jsonErrorResponse);
    }
}