namespace VacationHireInc.Rental.Core.Application.Core.Options;

public class JwtOptions
{
    public const string Position = "JwtSettings";

    public string? Key { get; set; }
    public string? Issuer { get; set; }
    public string? Audience { get; set; }
    public string? Secret { get; set; }
    public int ExpirationInMinutes { get; set; }
}