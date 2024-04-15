using VacationHireInc.Rental.Core.Domain.Enums;

namespace VacationHireInc.Rental.Core.Domain.Models;

public class Truck : NonPassengerVehicle, IRentable
{
    public string? SomeTruckSpecificProperty { get; set; }
}