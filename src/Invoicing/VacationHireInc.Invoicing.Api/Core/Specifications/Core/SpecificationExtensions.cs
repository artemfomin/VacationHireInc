namespace VacationHireInc.Invoicing.Api.Core.Specifications.Core;

internal static class SpecificationExtensions
{
    internal static bool SatisfiesSpecification<TSpec, TModel>(this TModel model)
        where TSpec : ISpecification<TModel>, new()
    {
        var specification = new TSpec();

        if (specification.Criteria == null)
            return true;

        var predicate = specification.Criteria.Compile();
        return predicate(model);
    }
}