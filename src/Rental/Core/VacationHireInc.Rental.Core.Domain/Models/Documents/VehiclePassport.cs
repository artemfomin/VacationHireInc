namespace VacationHireInc.Rental.Core.Domain.Models;

public class VehiclePassport : VehicleDocument
{
    public override string Name => "Vehicle Passport";
    public Guid FkVehicleId { get; set; }
}