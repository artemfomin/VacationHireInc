namespace VacationHireInc.Invoicing.Api.Core.Exceptions;

public abstract class ApplicationFaultException : Exception
{
    protected ApplicationFaultException()
    {
    }

    protected ApplicationFaultException(string message) : base(message)
    {
    }

    protected ApplicationFaultException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public virtual short ErrorCode { get; protected set; }
    public virtual short DetailsCode { get; protected set; }
}