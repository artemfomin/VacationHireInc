namespace VacationHireInc.Invoicing.Api.Core.Exceptions;

public class ServiceMarketException : Exception
{
    public ServiceMarketException()
    {
    }

    public ServiceMarketException(string message) : base(message)
    {
    }

    public ServiceMarketException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public virtual short ErrorCode { get; protected set; }
    public virtual short DetailsCode { get; protected set; }
}