using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using VacationHireInc.Rental.Core.Application.Core.Exceptions;
using VacationHireInc.Rental.Presentation.Api.Infrastructure.ApiExceptionHandling.Core;

namespace VacationHireInc.Rental.Presentation.Api.Infrastructure.ApiExceptionHandling;

public class ValidationExceptionHandlingStrategy : IExceptionHandlingStrategy<ValidationException>
{
    public HttpStatusCode Status => HttpStatusCode.BadRequest;

    public Task ExecuteAsync(ExceptionContext context)
    {
        context.ExceptionHandled = true;

        context.HttpContext.Response.StatusCode = (int)Status;

        var typedException = context.Exception as ValidationException;

        context.Result = new ObjectResult(typedException?.Failures
            .GroupBy(x => x.Key)
            .ToDictionary(x => x.Key));

        return Task.CompletedTask;
    }
}
