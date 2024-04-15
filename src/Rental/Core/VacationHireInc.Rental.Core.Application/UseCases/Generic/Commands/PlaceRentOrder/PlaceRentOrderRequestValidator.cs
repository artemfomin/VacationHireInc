using FluentValidation;

namespace VacationHireInc.Rental.Core.Application.UseCases.Cars.PlaceRentOrder;

public class PlaceRentOrderRequestValidator : AbstractValidator<PlaceRentOrderRequest>
{
    public PlaceRentOrderRequestValidator()
    {
        RuleFor(x => x.Order)
            .NotEmpty();

        RuleFor(x => x.Order.RentStart)
            .GreaterThan(DateTime.Now.AddDays(-30))
                .WithMessage("You can't place an order older than 30 days before today");

        RuleFor(x => x.Order.RentItemId)
            .NotEmpty();
    }
}