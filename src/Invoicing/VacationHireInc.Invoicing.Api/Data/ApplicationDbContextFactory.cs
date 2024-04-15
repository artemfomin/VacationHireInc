using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace VacationHireInc.Invoicing.Api.Data;

internal class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__VHI_Invoicing");
        
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Unable to obtain connection string");
        }

        optionsBuilder.UseSqlite(connectionString);
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}