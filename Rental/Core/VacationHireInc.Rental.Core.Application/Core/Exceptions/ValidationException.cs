using FluentValidation.Results;

namespace VacationHireInc.Rental.Core.Application.Core.Exceptions;

public class ValidationException : ApplicationFaultException
{
    public ValidationException()
        : base("One or more validation failures have occurred.")
    {
    }

    public ValidationException(List<ValidationFailure> failures) : this()
    {
        AddToFailures(failures);
    }

    protected ValidationException(string message) : base(message)
    {
    }

    protected ValidationException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public IDictionary<string, string[]> Failures { get; } = new Dictionary<string, string[]>();
    public override short ErrorCode { get; protected set; } = 400;
    public override short DetailsCode { get; protected set; } = 1;

    private void AddToFailures(List<ValidationFailure> failures)
    {
        var propertyNames = failures
            .Select(e => e.PropertyName)
            .Distinct();

        foreach (var propertyName in propertyNames)
        {
            var propertyFailures = failures
                .Where(e => e.PropertyName == propertyName)
                .Select(e => e.ErrorMessage)
                .ToArray();

            Failures.Add(propertyName, propertyFailures);
        }
    }
}