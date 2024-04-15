using System.Linq.Expressions;

namespace VacationHireInc.Invoicing.Api.Core.Specifications.Core;

public interface ISpecification<TModel>
{
    Expression<Func<TModel, bool>> Criteria { get; }
    List<Expression<Func<TModel, object>>> Includes { get; }
    List<string> IncludeStrings { get; }
    Expression<Func<TModel, object>> OrderBy { get; }
    Expression<Func<TModel, object>> OrderByDescending { get; }
    int Take { get; }
    int Skip { get; }
    bool IsPagingEnabled { get; }
}