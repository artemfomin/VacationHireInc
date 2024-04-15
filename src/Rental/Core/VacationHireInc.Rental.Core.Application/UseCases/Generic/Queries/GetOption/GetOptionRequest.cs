using VacationHireInc.Rental.Core.Application.Core.MediatR.Types;
using VacationHireInc.Rental.Core.Application.Core.Result;
using VacationHireInc.Rental.Core.Domain;
using VacationHireInc.Rental.Core.Domain.Models;

namespace VacationHireInc.Rental.Core.Application.UseCases.Cars.GetOption;

public class GetOptionRequest<TModel> : IQuery<Result<RentItem<TModel>>>
    where TModel : class, IEntity, IRentable
{
    public Guid RentItemId { get; set; }
}