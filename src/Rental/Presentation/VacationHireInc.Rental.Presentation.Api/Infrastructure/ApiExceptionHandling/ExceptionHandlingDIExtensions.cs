using VacationHireInc.Rental.Presentation.Api.Infrastructure.ApiExceptionHandling.Core;

namespace VacationHireInc.Rental.Presentation.Api.Infrastructure.ApiExceptionHandling
{
    internal static class ExceptionHandlingDIExtensions
    {
        internal static IServiceCollection AddExceptionHandling(this IServiceCollection services)
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(t => t.IsClass 
                && !t.IsAbstract
                && t.GetInterfaces().Any(i => i.Name.StartsWith(nameof(IExceptionHandlingStrategy)))
                && t.IsGenericType
                && t.GetGenericArguments().Any())
            .ToList();

            foreach(var type in types)
            {
                var strategyInterface = type.GetInterfaces()
                    .Where(x => x.IsGenericType && x.GetGenericArguments().Count() == 1)
                    .First(x => x.Name.StartsWith(nameof(IExceptionHandlingStrategy)));

                var genericExceptionType = strategyInterface.GetGenericArguments().First();
                var strategyGenericInterfaceType = typeof(IExceptionHandlingStrategy<>).MakeGenericType(genericExceptionType);

                services.AddScoped(strategyGenericInterfaceType, type);
            }

            return services;
        }
    }
}
