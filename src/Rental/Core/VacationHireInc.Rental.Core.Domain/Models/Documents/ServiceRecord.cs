namespace VacationHireInc.Rental.Core.Domain.Models;

public class ServiceRecord : IEntity
{
    public Guid Id { get; set; }
    public string? ServiceInstitution { get; set; }
    public DateTime NextServiceDate { get; set; }
    public string? ServiceSummary { get; set; }
}