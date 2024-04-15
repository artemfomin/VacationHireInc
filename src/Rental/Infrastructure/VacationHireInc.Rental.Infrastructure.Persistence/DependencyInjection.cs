using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VacationHireInc.Rental.Core.Application.Data;
using VacationHireInc.Rental.Infrastructure.Persistence.Repositories.Core;

namespace VacationHireInc.Rental.Infrastructure.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("VHI")
                               ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(connectionString));
        
        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        services.AddScoped(typeof(ICrudRepository<>), typeof(CrudRepository<>));
        
        services.AddMediatR(mediatrConfig =>
        {
            mediatrConfig.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(DependencyInjection))!);
        });
        
        return services;
    }
}

