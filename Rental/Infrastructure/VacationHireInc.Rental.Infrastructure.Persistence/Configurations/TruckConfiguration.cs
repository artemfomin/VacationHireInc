using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VacationHireInc.Rental.Core.Domain.Models;

namespace VacationHireInc.Rental.Infrastructure.Persistence.Configurations;

public class TruckConfiguration : IEntityTypeConfiguration<Truck>
{
    public void Configure(EntityTypeBuilder<Truck> builder)
    {
        builder.ToTable("Trucks", "rental");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Passport)
            .WithOne()
            .HasForeignKey<VehiclePassport>(x => x.FkVehicleId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.TechnicalCheckCertificate)
            .WithOne()
            .HasForeignKey<TechnicalCheck>(x => x.FkVehicleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}