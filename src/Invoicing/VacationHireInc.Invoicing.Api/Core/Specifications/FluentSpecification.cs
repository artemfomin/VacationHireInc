using System.Linq.Expressions;
using VacationHireInc.Invoicing.Api.Core.Specifications.Core;
using VacationHireInc.Invoicing.Api.Data;

namespace VacationHireInc.Invoicing.Api.Core.Specifications;

public class FluentSpecification<TModel> : AbstractSpecification<TModel>
    where TModel : IEntity
{
    public FluentSpecification() : base(default!)
    {
    }

    public FluentSpecification<TModel> Where(Expression<Func<TModel, bool>> criteria)
    {
        Criteria = criteria;
        return this;
    }

    public new FluentSpecification<TModel> OrderBy(Expression<Func<TModel, object>> orderByExpression)
    {
        ApplyOrderBy(orderByExpression);
        return this;
    }

    public new FluentSpecification<TModel> OrderByDescending(
        Expression<Func<TModel, object>> orderByDescendingExpression)
    {
        ApplyOrderByDescending(orderByDescendingExpression);
        return this;
    }

    public FluentSpecification<TModel> Include(Expression<Func<TModel, object>> includeExpression)
    {
        AddInclude(includeExpression);
        return this;
    }

    public FluentSpecification<TModel> Paginate(int pageNumber, int pageSize)
    {
        if (pageSize <= 0)
            pageSize = 10;

        if (pageNumber <= 0)
            pageNumber = 1;

        ApplyPaging((pageNumber - 1) * pageSize, pageSize);
        return this;
    }
}