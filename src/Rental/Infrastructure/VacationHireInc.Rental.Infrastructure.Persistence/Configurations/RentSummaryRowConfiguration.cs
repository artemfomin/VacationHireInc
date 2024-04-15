using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VacationHireInc.Rental.Core.Domain.Models;

namespace VacationHireInc.Rental.Infrastructure.Persistence.Configurations;

public class RentSummaryRowConfiguration : IEntityTypeConfiguration<RentSummaryRow>
{
    public void Configure(EntityTypeBuilder<RentSummaryRow> builder)
    {
        builder.ToTable("RentSummaryRows", "rental");

        builder.HasKey(x => x.Id);
    }
}