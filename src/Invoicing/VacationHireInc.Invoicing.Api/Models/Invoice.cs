using VacationHireInc.Invoicing.Api.Data;

namespace VacationHireInc.Invoicing.Api.Models;

public class Invoice : IEntity
{
    public Guid Id { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerPhone { get; set; }
    public List<InvoiceItem> Items { get; } = new();
    public DateTime InvoiceDate { get; set; }
    public DateTime ValidTill { get; set; }
}