using VacationHireInc.Rental.Core.Domain.Enums;

namespace VacationHireInc.Rental.Core.Domain.Models;

public class Sedan : PassengerVehicle, IRentable
{
    public string? SomeSedanSpecificProperty { get; set; }
}