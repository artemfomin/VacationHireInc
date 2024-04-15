namespace VacationHireInc.Rental.Core.Domain.Models;

public abstract class NonPassengerVehicle : Vehicle
{
    public int CarryCapacity { get; set; }
}