using LiteCRM.Application.AspNet.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace LiteCRM.Application.AspNet.Extensions;

public static class AppBuilderExtensions
{
    public static IApplicationBuilder AddApplicationExceptionsHandling(
        this IApplicationBuilder builder)
    {
        builder.UseMiddleware<ApplicationExceptionsHandlingMiddleware>();

        return builder;
    }
}