using System.Net;
using LiteCRM.Application.AspNet.ExceptionHandling.Models;
using LiteCRM.Application.Exceptions;

namespace LiteCRM.Application.AspNet.ExceptionHandling.Handlers;

public class NotFoundApplicationExceptionHandler : IExceptionHandler<NotFoundApplicationException>
{
    public ErrorResponse Handle(NotFoundApplicationException exception)
    {
        return new ErrorResponse
        {
            Type = "Not Found",
            Message = exception.Message,
            StatusCode = (int)HttpStatusCode.NotFound
        };
    }
}