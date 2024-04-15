using Microsoft.EntityFrameworkCore;
using VacationHireInc.Rental.Core.Domain.Models;

namespace VacationHireInc.Rental.Core.Application.Data;

public interface IApplicationDbContext
{
    public DbSet<VehiclePassport> VehiclePassports { get; set; }
    public DbSet<TechnicalCheck> TechnicalChecks { get; set; }
    public DbSet<ServiceRecord> ServiceRecords { get; set; }
    public DbSet<Sedan> Sedans { get; set; }
    public DbSet<Minivan> Minivan { get; set; }
    public DbSet<Truck> Truck { get; set; }
    public DbSet<RentItem> RentItems { get; set; }
    public DbSet<RentOrder> RentOrders { get; set; }
    

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}