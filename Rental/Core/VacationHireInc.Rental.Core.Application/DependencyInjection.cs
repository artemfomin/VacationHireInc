using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using VacationHireInc.Rental.Core.Application.Core.Result;
using VacationHireInc.Rental.Core.Application.UseCases.Cars.AddOption;
using VacationHireInc.Rental.Core.Application.UseCases.Cars.GetAvailableOptions;
using VacationHireInc.Rental.Core.Application.UseCases.Cars.GetOption;
using VacationHireInc.Rental.Core.Domain;
using VacationHireInc.Rental.Core.Domain.Models;

namespace VacationHireInc.Rental.Core.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(DependencyInjection))!);
        });

        services.RegisterAsRentable<Sedan>();
        services.RegisterAsRentable<Minivan>();
        services.RegisterAsRentable<Truck>();

        return services;
    }

    private static void RegisterAsRentable<TModel>(this IServiceCollection services)
        where TModel : class, IEntity, IRentable
    {
        services.AddScoped<IRequestHandler<GetAvailableOptionsRequest<TModel>, Result<IList<RentItem<TModel>>>>, GetAvailableOptionsHandler<TModel>>();
        services.AddScoped<IRequestHandler<GetOptionRequest<TModel>, Result<RentItem<TModel>>>, GetOptionHandler<TModel>>();
        
        services.AddScoped<IRequestHandler<AddOptionRequest<TModel>, Result>, AddOptionHandler<TModel>>();
    }
}