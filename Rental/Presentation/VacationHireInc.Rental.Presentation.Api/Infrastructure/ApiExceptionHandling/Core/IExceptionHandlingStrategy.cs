using System.Net;
using Microsoft.AspNetCore.Mvc.Filters;

namespace VacationHireInc.Rental.Presentation.Api.Infrastructure.ApiExceptionHandling.Core;

internal interface IExceptionHandlingStrategy<in TException> : IExceptionHandlingStrategy
    where TException : Exception
{
}

public interface IExceptionHandlingStrategy
{
    HttpStatusCode Status { get; }

    Task ExecuteAsync(ExceptionContext context);
}
