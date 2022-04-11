using System.Net;
using LiteCRM.Application.AspNet.ExceptionHandling.Models;
using LiteCRM.Application.Exceptions;

namespace LiteCRM.Application.AspNet.ExceptionHandling.Handlers;

public class InvalidDataApplicationExceptionHandler : IExceptionHandler<InvalidDataApplicationException>
{
    public ErrorResponse Handle(InvalidDataApplicationException exception)
    {
        return new ErrorResponse
        {
            Type = "Invalid Data",
            Message = exception.Message,
            StatusCode = (int)HttpStatusCode.BadRequest
        };
    }
}