using System.Linq.Expressions;

namespace VacationHireInc.Rental.Core.Application.Core.Specifications.Core;

public class AbstractSpecification<TModel> : ISpecification<TModel>
{
    protected AbstractSpecification(Expression<Func<TModel, bool>> criteria)
    {
        Criteria = criteria;
    }

    public Expression<Func<TModel, bool>> Criteria { get; set; }

    public List<Expression<Func<TModel, object>>> Includes { get; } = new();

    public List<string> IncludeStrings { get; } = new();

    public Expression<Func<TModel, object>> OrderBy { get; private set; } = null!;

    public Expression<Func<TModel, object>> OrderByDescending { get; private set; } = null!;

    public int Take { get; private set; }

    public int Skip { get; private set; }

    public bool IsPagingEnabled { get; private set; }

    protected virtual void AddInclude(Expression<Func<TModel, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }

    protected virtual void AddInclude(string includeString)
    {
        IncludeStrings.Add(includeString);
    }

    protected virtual void ApplyPaging(int skip, int take)
    {
        Skip = skip;
        Take = take;
        IsPagingEnabled = true;
    }

    protected virtual void ApplyOrderBy(Expression<Func<TModel, object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }

    protected virtual void ApplyOrderByDescending(Expression<Func<TModel, object>> orderByDescendingExpression)
    {
        OrderByDescending = orderByDescendingExpression;
    }
}