using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VacationHireInc.Rental.Core.Domain.Models;

namespace VacationHireInc.Rental.Infrastructure.Persistence.Configurations;

public class RentSummaryConfiguration : IEntityTypeConfiguration<RentSummary>
{
    public void Configure(EntityTypeBuilder<RentSummary> builder)
    {
        builder.ToTable("RentSummaries", "rental");

        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Rows)
            .WithOne()
            .HasForeignKey(x => x.FkRentSummary)
            .OnDelete(DeleteBehavior.Cascade);
    }
}