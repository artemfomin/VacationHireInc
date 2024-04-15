using VacationHireInc.Rental.Core.Application.Core.Specifications.Core;

namespace VacationHireInc.Rental.Core.Application.Core.Specifications;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
internal class ConcreteSpecification : AbstractSpecification<TestModel>
{
    public ConcreteSpecification()
    : base(model => model.Name.StartsWith("A")
                    && !model.Id.Equals(Guid.Empty))
    {
    }
}
