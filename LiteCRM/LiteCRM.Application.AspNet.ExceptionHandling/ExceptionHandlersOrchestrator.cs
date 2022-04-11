using System.Net;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Text.Json;
using LiteCRM.Application.AspNet.ExceptionHandling.Models;
using Microsoft.AspNetCore.Http;

namespace LiteCRM.Application.AspNet.ExceptionHandling;

public static class ExceptionHandlersOrchestrator
{
    private static Dictionary<Type, object> _handlers = new();

    static ExceptionHandlersOrchestrator()
    {
        IEnumerable<Type> exceptionHandlers = AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => !type.IsInterface
               && type.GetInterfaces()
                   .Any(i => i.IsGenericType
                        && i.GetGenericTypeDefinition() == typeof(IExceptionHandler<>)));

        foreach (Type exceptionHandler in exceptionHandlers)
        {
            Type exceptionType = exceptionHandler
                .GetInterfaces()
                .FirstOrDefault(i => i.IsGenericType
                    && i.GetGenericTypeDefinition() == typeof(IExceptionHandler<>))!
                .GetGenericArguments()[0];

            _handlers[exceptionType] = Activator.CreateInstance(exceptionHandler)!;
        }
    }

    public static async Task<HttpContext> Handle(Exception e, HttpContext context)
    {
        Type exceptionType = e.GetType();

        ErrorResponse errorResponse = _handlers.TryGetValue(exceptionType, out object? handler)
            ? InvokeHandler(e, handler)
            : HandleException(e);

        string jsonResponse = JsonSerializer.Serialize(errorResponse);
        byte[] responseContent = Encoding.UTF8.GetBytes(jsonResponse);

        context.Response.StatusCode = errorResponse.StatusCode;
        context.Response.ContentType = MediaTypeNames.Application.Json;
        await context.Response.Body.WriteAsync(responseContent);

        return context;
    }

    private static ErrorResponse HandleException(Exception e)
    {
        return new ErrorResponse
        {
            Type = "Internal Server Error",
            Message = e.Message,
            StatusCode = (int)HttpStatusCode.InternalServerError
        };
    }

    private static ErrorResponse InvokeHandler(
        Exception e,
        object handler)
    {
        MethodInfo method = handler.GetType().GetMethod("Handle")!;
        var errorResponse = method.Invoke(handler, new [] { e }) as ErrorResponse;

        return errorResponse!;
    }
}