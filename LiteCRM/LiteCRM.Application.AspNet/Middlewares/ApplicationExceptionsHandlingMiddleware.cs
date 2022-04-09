using Microsoft.AspNetCore.Http;

namespace LiteCRM.Application.AspNet.Middlewares;

public class ApplicationExceptionsHandlingMiddleware : IMiddleware
{
    public Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        throw new NotImplementedException();
    }
}