namespace VacationHireInc.Rental.Core.Domain;

public interface IOwnable
{
    public Guid OwnerId { get; set; }
}
