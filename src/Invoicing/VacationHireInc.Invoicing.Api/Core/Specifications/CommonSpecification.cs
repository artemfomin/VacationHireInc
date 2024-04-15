using System.Linq.Expressions;
using VacationHireInc.Invoicing.Api.Core.Specifications.Core;

namespace VacationHireInc.Invoicing.Api.Core.Specifications;

internal class CommonSpecification<TModel> : AbstractSpecification<TModel>
{
    public CommonSpecification(Expression<Func<TModel, bool>> criteria)
        : base(criteria)
    {
    }
}