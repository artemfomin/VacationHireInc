namespace VacationHireInc.Rental.Core.Domain.Models;

public abstract class PassengerVehicle : Vehicle
{
    public int PassengerCount { get; set; }
}