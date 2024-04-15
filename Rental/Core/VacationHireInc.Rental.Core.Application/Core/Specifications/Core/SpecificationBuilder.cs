using System.Linq.Expressions;

namespace VacationHireInc.Rental.Core.Application.Core.Specifications.Core;

public class SpecificationBuilder<TModel>
{
    internal List<Expression<Func<TModel, bool>>> Predicates { get; set; } = new();

    internal SpecificationBuilder<TModel> Condition(Expression<Func<TModel, bool>> exp)
    {
        Predicates.Add(exp);
        return this;
    }

    internal List<Expression<Func<TModel, bool>>> Build()
    {
        return Predicates;
    }

    public static implicit operator Expression<Func<TModel, bool>>(SpecificationBuilder<TModel> builder)
    {
        return CombineConditions(builder);
    }

    private static Expression<Func<TModel, bool>> CombineConditions(SpecificationBuilder<TModel> builder)
    {
        if (builder?.Predicates.Any() != true)
            return null!;

        var resultingCondition = builder.Predicates[0];

        if (builder.Predicates.Count == 1)
            return resultingCondition;

        for (var i = 1; i < builder.Predicates.Count; i++)
        {
            //resultingCondition = model => resultingCondition.Compile()(model) && builder.Predicates[i].Compile()(model
            var binaryExpression = Expression.AndAlso(resultingCondition.Body,
                new ExpressionParameterReplacer(builder.Predicates[i].Parameters, resultingCondition.Parameters).Visit(
                    builder.Predicates[i].Body));
            resultingCondition = Expression.Lambda<Func<TModel, bool>>(binaryExpression, resultingCondition.Parameters);
        }

        return resultingCondition;
    }
}