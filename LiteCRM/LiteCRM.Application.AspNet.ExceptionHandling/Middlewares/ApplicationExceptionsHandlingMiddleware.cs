using Microsoft.AspNetCore.Http;

namespace LiteCRM.Application.AspNet.ExceptionHandling.Middlewares;

public class ApplicationExceptionsHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ApplicationExceptionsHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception e)
        {
            context = await ExceptionHandlersOrchestrator.Handle(e, context);
        }
    }
}