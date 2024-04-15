namespace VacationHireInc.Rental.Core.Domain.Models;

public class RentSummaryRow : IEntity
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double? Cost { get; set; }
    public Guid FkRentSummary { get; set; }
}