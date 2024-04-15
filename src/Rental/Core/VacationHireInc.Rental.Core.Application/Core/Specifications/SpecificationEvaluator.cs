using Microsoft.EntityFrameworkCore;
using VacationHireInc.Rental.Core.Application.Core.Specifications.Core;
using VacationHireInc.Rental.Core.Domain;

namespace VacationHireInc.Rental.Core.Application.Core.Specifications;

public static class SpecificationEvaluator<TModel>
    where TModel : class, IEntity
{
    public static IQueryable<TModel> GetQuery(IQueryable<TModel> inputQuery, ISpecification<TModel>? spec)
    {
        var query = inputQuery;

        if (spec?.Criteria is not null) query = query.Where(spec.Criteria);

        query = spec?.Includes.Aggregate(query, (current, include) => current.Include(include));
        query = spec?.IncludeStrings.Aggregate(query, (current, include) => current?.Include(include));

        if (spec?.OrderBy is not null)
            query = query?.OrderBy(spec.OrderBy);
        else if (spec?.OrderByDescending is not null) query = query?.OrderByDescending(spec.OrderByDescending);

        if (spec?.IsPagingEnabled ?? false) query = query?.Skip(spec.Skip).Take(spec.Take);

        return query!;
    }
}