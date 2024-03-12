
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Middlewares;

public class GlobalExceptionsHandlingMiddleware : IMiddleware
{
    private readonly ILogger<GlobalExceptionsHandlingMiddleware> _logger;

    public GlobalExceptionsHandlingMiddleware(ILogger<GlobalExceptionsHandlingMiddleware> logger)=> _logger = logger;
    

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            ProblemDetails problem =new(){
                Status = (int)HttpStatusCode.InternalServerError,
                Type = "Server error",
                Title = "ServerError",
                Detail = "AN internal server has ocurred."
            };
            string json = JsonSerializer.Serialize(problem);
            context.Response.ContentType= "application/json";
            await context.Response.WriteAsync(json);
        }
    }
}