using Microsoft.AspNetCore.JsonPatch;
using VacationHireInc.Rental.Core.Application.Core.Pagination;
using VacationHireInc.Rental.Core.Application.Core.Specifications.Core;
using VacationHireInc.Rental.Core.Domain;

namespace VacationHireInc.Rental.Core.Application.Data;

public interface ICrudRepository<TModel> where TModel : class, IEntity
{
    Task<uint> GetCountAsync();
    Task<TModel> CreateAsync(TModel model, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<TModel?> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IList<TModel>> GetManyAsync(CancellationToken cancellationToken = default, params ISpecification<TModel>[] specifications);
    Task<IList<TModel>> GetManyAsync(CancellationToken cancellationToken = default, PaginationOptions paginationOptions = default!, params ISpecification<TModel>[] specifications);
    Task<TModel> PatchAsync(Guid id, JsonPatchDocument<TModel> patch, CancellationToken cancellationToken = default);
    Task<TModel> UpdateAsync(TModel model, CancellationToken cancellationToken = default);
}
