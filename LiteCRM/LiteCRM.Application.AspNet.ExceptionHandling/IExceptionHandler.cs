using LiteCRM.Application.AspNet.ExceptionHandling.Models;

namespace LiteCRM.Application.AspNet.ExceptionHandling;

public interface IExceptionHandler<in TException>
{
    public ErrorResponse Handle(TException exception);
}