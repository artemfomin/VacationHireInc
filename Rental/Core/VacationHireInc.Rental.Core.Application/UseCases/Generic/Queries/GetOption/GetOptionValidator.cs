using FluentValidation;
using VacationHireInc.Rental.Core.Domain;

namespace VacationHireInc.Rental.Core.Application.UseCases.Cars.GetOption;

public class GetOptionValidator<TModel> : AbstractValidator<GetOptionRequest<TModel>>
    where TModel : class, IEntity, IRentable
{
    public GetOptionValidator()
    {
        RuleFor(x => x.RentItemId)
            .NotEmpty();
    }
}