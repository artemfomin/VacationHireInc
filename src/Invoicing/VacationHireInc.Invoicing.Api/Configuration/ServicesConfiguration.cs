using Microsoft.EntityFrameworkCore;
using VacationHireInc.Invoicing.Api.Data;
using VacationHireInc.Invoicing.Api.Data.Repositories.Core;
using VacationHireInc.Invoicing.Api.Services;

namespace VacationHireInc.Invoicing.Api.Configuration;

internal static class ServicesConfiguration
{
    internal static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("VHI_Invoicing")
                               ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(connectionString));
        
        builder.Services.AddScoped(typeof(ICrudRepository<>), typeof(CrudRepository<>));
        builder.Services.AddScoped<IInvoiceService, InvoiceService>();
        
        return builder;
    }
}