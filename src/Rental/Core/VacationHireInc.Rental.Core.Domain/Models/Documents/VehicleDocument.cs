namespace VacationHireInc.Rental.Core.Domain.Models;

public abstract class VehicleDocument : IEntity
{
    public Guid Id { get; set; }
    public abstract string Name { get; }
    public string? Issuer { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime ExpirationDate { get; set; }
}