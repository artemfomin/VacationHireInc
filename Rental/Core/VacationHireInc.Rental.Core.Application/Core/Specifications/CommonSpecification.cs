using System.Linq.Expressions;
using VacationHireInc.Rental.Core.Application.Core.Specifications.Core;

namespace VacationHireInc.Rental.Core.Application.Core.Specifications;

internal class CommonSpecification<TModel> : AbstractSpecification<TModel>
{
    public CommonSpecification(Expression<Func<TModel, bool>> criteria)
        : base(criteria)
    {
    }
}