using System.Reflection;
using VacationHireInc.Rental.Core.Application;
using VacationHireInc.Rental.Core.Application.Core.Exceptions;
using VacationHireInc.Rental.Infrastructure.Persistence;
using VacationHireInc.Rental.Presentation.Api.Infrastructure;
using VacationHireInc.Rental.Presentation.Api.Infrastructure.ApiExceptionHandling;
using VacationHireInc.Rental.Presentation.Api.Infrastructure.ApiExceptionHandling.Core;

namespace VacationHireInc.Rental.Presentation.Api.Configuration;

internal static class ServicesConfiguration
{
    internal static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
        });
        
        builder.Services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(ServicesConfiguration))!);
        });
        
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddApplicationLayer();
        builder.Services.AddPersistenceLayer(builder.Configuration);

        builder.Services
            .AddScoped<IExceptionHandlingStrategy<Exception>, ExceptionHandlingDefaultStrategy<Exception>>()
            .AddScoped<IExceptionHandlingStrategy<NotFoundException>, NotFoundExceptionHandlingStrategy>()
            .AddScoped<IExceptionHandlingStrategy<ValidationException>, ValidationExceptionHandlingStrategy>()
            .AddScoped<IExceptionHandlingStrategy<UnauthorizedException>, UnauthorizedExceptionHandlingStrategy>();
        
        return builder;
    }
}