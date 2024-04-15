using System.Linq.Expressions;

namespace VacationHireInc.Rental.Core.Application.Core.Specifications.Core;

internal class ExpressionParameterReplacer : ExpressionVisitor
{
    public ExpressionParameterReplacer(IList<ParameterExpression> fromParameters,
        IList<ParameterExpression> toParameters)
    {
        ParameterReplacements = new Dictionary<ParameterExpression, ParameterExpression>();
        for (var i = 0; i != fromParameters.Count && i != toParameters.Count; i++)
            ParameterReplacements.Add(fromParameters[i], toParameters[i]);
    }

    private IDictionary<ParameterExpression, ParameterExpression> ParameterReplacements { get; }

    protected override Expression VisitParameter(ParameterExpression node)
    {
        ParameterExpression replacement;
        if (ParameterReplacements.TryGetValue(node, out replacement!))
            node = replacement;
        return base.VisitParameter(node);
    }
}