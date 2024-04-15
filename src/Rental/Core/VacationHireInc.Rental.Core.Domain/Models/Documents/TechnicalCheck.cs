namespace VacationHireInc.Rental.Core.Domain.Models;

public class TechnicalCheck : VehicleDocument
{
    public override string Name => "Technical check";
    public Guid FkVehicleId { get; set; }
}