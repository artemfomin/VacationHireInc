using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.Filters;

namespace VacationHireInc.Rental.Presentation.Api.Infrastructure.ApiExceptionHandling.Core;

public class ApiExceptionFilter : IAsyncExceptionFilter
{
    private readonly IServiceProvider _serviceProvider;

    public ApiExceptionFilter(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    [RequiresDynamicCode("The native code for this instantiation might not be available at runtime.")]
    public async Task OnExceptionAsync(ExceptionContext context)
    {
        using var scope = _serviceProvider.CreateScope();
        
        var strategyType = typeof(IExceptionHandlingStrategy<>).MakeGenericType(context.Exception.GetType());
        var strategy = scope.ServiceProvider.GetService(strategyType) as IExceptionHandlingStrategy;

        if (strategy is not null)
        {
            await strategy.ExecuteAsync(context);
        }
        else
        {
            var defaultStrategy = scope.ServiceProvider.GetRequiredService<IExceptionHandlingStrategy<Exception>>();
            await defaultStrategy.ExecuteAsync(context);
        }
    }
}
