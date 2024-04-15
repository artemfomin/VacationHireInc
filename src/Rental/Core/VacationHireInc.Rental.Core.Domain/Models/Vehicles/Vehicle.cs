using VacationHireInc.Rental.Core.Domain.Enums;

namespace VacationHireInc.Rental.Core.Domain.Models;

public abstract class Vehicle : IEntity
{
    public Guid Id { get; set; }
    public string Model { get; set; } = null!;
    public string Mark { get; set; } = null!;
    public uint Mileage { get; set; }
    public GearType Gear { get; set; }
    public ushort Year { get; set; }
    public string Vin { get; set; } = null!;
    public double CurrentPrice { get; set; }
    public string? Description { get; set; } = null!;
    public bool IsAvailable { get; set; }
    public VehiclePassport? Passport { get; set; }
    public TechnicalCheck? TechnicalCheckCertificate { get; set; }
}