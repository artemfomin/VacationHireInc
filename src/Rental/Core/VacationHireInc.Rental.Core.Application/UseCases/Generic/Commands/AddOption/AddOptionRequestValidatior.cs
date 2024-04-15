using FluentValidation;
using VacationHireInc.Rental.Core.Domain;
using VacationHireInc.Rental.Core.Domain.Enums;

namespace VacationHireInc.Rental.Core.Application.UseCases.Cars.AddOption;

public class AddOptionRequestValidatior<TModel> : AbstractValidator<AddOptionRequest<TModel>>
    where TModel : class, IEntity, IRentable
{
    public AddOptionRequestValidatior()
    {
        RuleFor(x => x.RentObject.RentSubject)
            .NotEmpty();
        
        RuleFor(x => x.RentObject)
            .NotEmpty();

        RuleFor(x => x.RentObject.RentCost)
            .NotEmpty();

        RuleFor(x => x.RentObject.BillingPeriod)
            .NotEqual(BillingPeriods.None)
                .WithMessage("You should select valid billing period");
    }
}