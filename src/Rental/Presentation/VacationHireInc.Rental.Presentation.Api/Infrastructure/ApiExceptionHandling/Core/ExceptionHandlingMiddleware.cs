using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace VacationHireInc.Rental.Presentation.Api.Infrastructure.ApiExceptionHandling.Core;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ApiExceptionFilter _apiExceptionFilter;

    public ExceptionHandlingMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
    {
        _next = next;
        _apiExceptionFilter = new ApiExceptionFilter(serviceProvider);
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var exceptionContext = new ExceptionContext(CreateActionContext(context), new List<IFilterMetadata>())
        {
            HttpContext = context,
            Exception = exception
        };

        return _apiExceptionFilter.OnExceptionAsync(exceptionContext);
    }
    
    public static ActionContext CreateActionContext(HttpContext httpContext)
    {
        var routeData = httpContext.GetRouteData() ?? new RouteData();
        var actionDescriptor = new ActionDescriptor();

        var actionContext = new ActionContext(httpContext, routeData, actionDescriptor);
        return actionContext;
    }
}
