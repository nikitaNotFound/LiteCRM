using System.Net;
using LiteCRM.Application.AspNet.ExceptionHandling.Models;
using LiteCRM.Application.Exceptions;

namespace LiteCRM.Application.AspNet.ExceptionHandling.Handlers;

public class ApplicationExceptionHandler : IExceptionHandler<ApplicationErrorException>
{
    public ErrorResponse Handle(ApplicationErrorException exception)
    {
        return new ErrorResponse
        {
            Type = "Application Error",
            Message = exception.Message,
            StatusCode = (int)HttpStatusCode.InternalServerError
        };
    }
}