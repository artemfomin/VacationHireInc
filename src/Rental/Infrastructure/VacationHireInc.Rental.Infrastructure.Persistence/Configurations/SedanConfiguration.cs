using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VacationHireInc.Rental.Core.Domain.Models;

namespace VacationHireInc.Rental.Infrastructure.Persistence.Configurations;

public class SedanConfiguration : IEntityTypeConfiguration<Sedan>
{
    public void Configure(EntityTypeBuilder<Sedan> builder)
    {
        builder.ToTable("Sedans", "rental");

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