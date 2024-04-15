namespace VacationHireInc.Rental.Core.Domain.Models;

public class RentSummary : IEntity
{
    public Guid Id { get; set; }
    public DateTime RentEndDate { get; set; }
    public double Total { get; set; }
    public List<RentSummaryRow> Rows { get; set; } = new();
}