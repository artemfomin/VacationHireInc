using VacationHireInc.Rental.Core.Domain.Enums;

namespace VacationHireInc.Rental.Core.Domain.Models;

public class RentOrder : IEntity
{
    public Guid Id { get; set; }
    public Guid RentItemId { get; set; }
    public DateTime RentStart { get; set; }
    public OrderStatus Status { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerPhone { get; set; }
}