namespace VacationHireInc.Invoicing.Api.Core.Exceptions;

[Serializable]
public class UnauthorizedException : ApplicationFaultException
{
    public UnauthorizedException()
    {
    }

    public UnauthorizedException(string message) : base(message)
    {
    }

    public UnauthorizedException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public override short ErrorCode { get; protected set; } = 401;
}