using MediatR;
using VacationHireInc.Rental.Core.Application.Core.Result;
using VacationHireInc.Rental.Core.Application.Data;
using VacationHireInc.Rental.Core.Domain;
using VacationHireInc.Rental.Core.Domain.Models;

namespace VacationHireInc.Rental.Core.Application.UseCases.Cars.GetAvailableOptions;

public class GetAvailableOptionsHandler<TModel>(ICrudRepository<TModel> repository) 
    : IRequestHandler<GetAvailableOptionsRequest<TModel>, Result<IList<RentItem<TModel>>>>
    where TModel : class, IEntity, IRentable
{
    public async Task<Result<IList<RentItem<TModel>>>> Handle(GetAvailableOptionsRequest<TModel> request, CancellationToken cancellationToken)
    {        
        var items = await repository.GetManyAsync(cancellationToken);
        var rentItems = items
            .Select(x => new RentItem<TModel>(x))
            .ToList();
        
        return new Result<IList<RentItem<TModel>>>(rentItems);
    }
}
