using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using VacationHireInc.Invoicing.Api.Core.Exceptions;
using VacationHireInc.Invoicing.Api.Core.Pagination;
using VacationHireInc.Invoicing.Api.Core.Specifications;
using VacationHireInc.Invoicing.Api.Core.Specifications.Core;
using VacationHireInc.Invoicing.Api.Extensions;

namespace VacationHireInc.Invoicing.Api.Data.Repositories.Core;

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

internal class CrudRepository<TModel>(ApplicationDbContext context) : ICrudRepository<TModel>
    where TModel : class, IEntity
{
    private DbSet<TModel> DbSet => context.Set<TModel>();

    public virtual async Task<uint> GetCountAsync()
    {
        return (uint) await DbSet.CountAsync();
    }

    public virtual async Task<TModel> CreateAsync(TModel model, CancellationToken cancellationToken = default)
    {
        await DbSet.AddAsync(model, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return model;
    }

    public virtual async Task<TModel?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await DbSet.AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync(x => x.Id!.Equals(id), cancellationToken);
    }

    public virtual async Task<IList<TModel>> GetManyAsync(CancellationToken cancellationToken = default,
        params ISpecification<TModel>[] specifications)
    {
        return await GetBySpecifications(cancellationToken, specifications).ToListAsync(cancellationToken);
    }

    public virtual async Task<IList<TModel>> GetManyAsync(CancellationToken cancellationToken = default,
        PaginationOptions paginationOptions = default!,
        params ISpecification<TModel>[] specifications)
    {
        var set = GetBySpecifications(cancellationToken, specifications);

        if (paginationOptions is not null && !paginationOptions.EmptyOrDisabled)
            set = set.ApplyPagination(paginationOptions);

        return await set.ToListAsync(cancellationToken);
    }

    public virtual async Task<TModel> PatchAsync(Guid id, JsonPatchDocument<TModel> patch, CancellationToken cancellationToken = default)
    {
        if (patch is null)
            throw new ArgumentNullException(nameof(patch));

        var entity = await DbSet.FindAsync(id, cancellationToken);

        patch.ApplyTo(entity!);

        await context.SaveChangesAsync(cancellationToken);

        return entity!;
    }

    public virtual async Task<TModel> UpdateAsync(TModel model, CancellationToken cancellationToken = default)
    {
        if (model is null || (model.Id.Equals(Guid.Empty)))
            throw new InvalidOperationException("Cannot update empty model or model with empty ID");

        var entity = await DbSet.FindAsync(model.Id, cancellationToken);

        if (entity is null)
            throw new NotFoundException($"Model `{typeof(TModel).Name}` with requested ID is not found");

        entity.TraverseUpdate(model);
        await context.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public virtual async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var itemToDelete = await DbSet.FindAsync(id, cancellationToken);
        if (itemToDelete != null)
        {
            DbSet.Remove(itemToDelete);
            await context.SaveChangesAsync(cancellationToken);
        }
    }

    private IQueryable<TModel> GetBySpecifications(CancellationToken cancellationToken = default, params ISpecification<TModel>[] specifications)
    {
        var set = DbSet.AsNoTrackingWithIdentityResolution().AsQueryable();
        
        if (specifications?.Any() == true)
        {
            foreach (var spec in specifications)
            {
                set = SpecificationEvaluator<TModel>.GetQuery(DbSet.AsQueryable(), spec);
            }
        }

        return set;
    }
}
