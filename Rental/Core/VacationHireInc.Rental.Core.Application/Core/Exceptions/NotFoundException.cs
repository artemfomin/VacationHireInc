namespace VacationHireInc.Rental.Core.Application.Core.Exceptions;

public class NotFoundException : ApplicationFaultException
{
    public NotFoundException()
    {
    }

    public NotFoundException(string message) : base(message)
    {
    }

    public NotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public Type? SubjectType { get; set; }
    public string? Subject { get; set; }
    public override short ErrorCode { get; protected set; } = 404;
}