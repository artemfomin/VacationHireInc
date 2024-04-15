using MediatR;
using VacationHireInc.Rental.Core.Application.Core.Result;
using VacationHireInc.Rental.Core.Application.Data;
using VacationHireInc.Rental.Core.Domain;
using VacationHireInc.Rental.Core.Domain.Models;

namespace VacationHireInc.Rental.Core.Application.UseCases.Cars.GetOption;

public class GetOptionHandler<TModel> (ICrudRepository<TModel> modelRepository, ICrudRepository<RentItem> rentRepository) 
    : IRequestHandler<GetOptionRequest<TModel>, Result<RentItem<TModel>>>
    where TModel : class, IEntity, IRentable
{
    public async Task<Result<RentItem<TModel>>> Handle(GetOptionRequest<TModel> request, CancellationToken cancellationToken)
    {
        var rentItem = await rentRepository.GetAsync(request.RentItemId);
        if (rentItem is null)
            return Result<RentItem<TModel>>.Failure();
        
        var model = await modelRepository.GetAsync(rentItem.SubjectId);
        if (model is null)
            return Result<RentItem<TModel>>.Failure();
        
        return Result<RentItem<TModel>>.Success(new RentItem<TModel>(model));
    }
}