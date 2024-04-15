namespace VacationHireInc.Rental.Core.Domain.Enums;

public enum BillingPeriods
{
    None = 0,
    Hourly = 1,
    Daily = 24,
    Weekly = 168,
    Monthly = 720, // average. improve precision depending on calendar month duration
    Yearly = 8760  // same here
}