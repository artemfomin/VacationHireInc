using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using VacationHireInc.Rental.Core.Application.Core.Exceptions;
using VacationHireInc.Rental.Presentation.Api.Infrastructure.ApiExceptionHandling.Core;

namespace VacationHireInc.Rental.Presentation.Api.Infrastructure.ApiExceptionHandling;

public class NotFoundExceptionHandlingStrategy : IExceptionHandlingStrategy<NotFoundException>
{
    public HttpStatusCode Status => HttpStatusCode.NotFound;

    public Task ExecuteAsync(ExceptionContext context)
    {
        context.ExceptionHandled = true;

        context.Result = new ObjectResult(context.Exception);

        return Task.CompletedTask;
    }
}
