using VacationHireInc.Rental.Core.Application.Core.MediatR.Types;
using VacationHireInc.Rental.Core.Application.Core.Result;
using VacationHireInc.Rental.Core.Domain;
using VacationHireInc.Rental.Core.Domain.Models;

namespace VacationHireInc.Rental.Core.Application.UseCases.Cars.AddOption;

public class AddOptionRequest<TModel>(RentItem<TModel> rentObject) : ICommand<Result>
    where TModel : class, IEntity, IRentable
{
    public RentItem<TModel> RentObject { get; } = rentObject;
}