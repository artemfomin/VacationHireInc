using VacationHireInc.Rental.Core.Application.Core.MediatR.Types;
using VacationHireInc.Rental.Core.Application.Core.Result;
using VacationHireInc.Rental.Core.Domain.Models;

namespace VacationHireInc.Rental.Core.Application.UseCases.Generic.Commands.CloseRentOrder;

public class CloseRentOrderRequest : ICommand<Result>
{
    public Guid RentOrderId { get; set; }
    public RentSummary? Summary { get; set; }
}