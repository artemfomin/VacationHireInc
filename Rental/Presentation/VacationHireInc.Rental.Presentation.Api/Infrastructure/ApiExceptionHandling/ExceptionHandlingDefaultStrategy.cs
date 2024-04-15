using System.Net;
using Microsoft.AspNetCore.Mvc.Filters;
using VacationHireInc.Rental.Presentation.Api.Infrastructure.ApiExceptionHandling.Core;

namespace VacationHireInc.Rental.Presentation.Api.Infrastructure.ApiExceptionHandling;

public class ExceptionHandlingDefaultStrategy<TException> : IExceptionHandlingStrategy<TException>
    where TException : Exception
{
    public HttpStatusCode Status => HttpStatusCode.BadRequest;

    public async Task ExecuteAsync(ExceptionContext context)
    {
        await Task.Run(() =>
        {
            context.ExceptionHandled = true;
            context.HttpContext.Response.StatusCode = (int)Status;
            Console.WriteLine(context.Exception.Message);
        });            
    }
}
