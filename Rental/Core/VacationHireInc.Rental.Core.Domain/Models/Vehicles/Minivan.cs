using VacationHireInc.Rental.Core.Domain.Enums;

namespace VacationHireInc.Rental.Core.Domain.Models;

public class Minivan : PassengerVehicle, IRentable
{
    public string? SomeMinivanSpecificProperty { get; set; }
}