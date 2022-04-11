namespace LiteCRM.Application.AspNet.ExceptionHandling.Models;

public class ErrorResponse
{
    public int StatusCode { get; set; }

    public string Type { get; set; }

    public string Message { get; set; }
}