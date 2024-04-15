using MediatR;
using VacationHireInc.Rental.Core.Application.Core.Result;
using VacationHireInc.Rental.Core.Application.Data;
using VacationHireInc.Rental.Core.Domain;
using VacationHireInc.Rental.Core.Domain.Models;

namespace VacationHireInc.Rental.Core.Application.UseCases.Cars.AddOption;

public class AddOptionHandler<TModel>(ICrudRepository<TModel> modelRepository, ICrudRepository<RentItem> rentRepository) 
    : IRequestHandler<AddOptionRequest<TModel>, Result>
    where TModel : class, IEntity, IRentable
{
    public async Task<Result> Handle(AddOptionRequest<TModel> request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.RentObject.QualifiedTypeName))
            request.RentObject.QualifiedTypeName = typeof(TModel).FullName;

        if (request.RentObject.SubjectId.Equals(Guid.Empty))
            request.RentObject.SubjectId = request.RentObject.RentSubject!.Id;
        
        var modelResult = await modelRepository.CreateAsync(request.RentObject.RentSubject!, cancellationToken);
        var itemResult = await rentRepository.CreateAsync(request.RentObject, cancellationToken);
        
        if (!modelResult.Id.Equals(Guid.Empty) && !itemResult.Id.Equals(Guid.Empty))
            return Result.Success();
        return Result.Failure(new InvalidOperationException($"Unknown error while creating {typeof(TModel).Name}"));
    }
}