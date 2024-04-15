using VacationHireInc.Rental.Core.Application.Core.MediatR.Types;
using VacationHireInc.Rental.Core.Application.Core.Result;
using VacationHireInc.Rental.Core.Domain.Models;

namespace VacationHireInc.Rental.Core.Application.UseCases.Cars.PlaceRentOrder;

public class PlaceRentOrderRequest : ICommand<Result>
{
    public RentOrder Order { get; set; }
}