using FluentValidation;

namespace VacationHireInc.Rental.Core.Application.UseCases.Generic.Commands.CloseRentOrder;

public class CloseRentOrderValidator : AbstractValidator<CloseRentOrderRequest>
{
    public CloseRentOrderValidator()
    {
        RuleFor(x => x.RentOrderId)
            .NotEmpty();

        RuleFor(x => x.Summary)
            .NotEmpty();

        RuleFor(x => x.Summary!.RentEndDate)
            .NotEmpty();
    }
}