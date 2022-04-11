using LiteCRM.Application.AspNet.ExceptionHandling.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace LiteCRM.Application.AspNet.ExceptionHandling.Extensions;

public static class AppBuilderExtensions
{
    public static IApplicationBuilder UseApplicationExceptionsHandling(
        this IApplicationBuilder builder)
    {
        builder.UseMiddleware<ApplicationExceptionsHandlingMiddleware>();

        return builder;
    }
}