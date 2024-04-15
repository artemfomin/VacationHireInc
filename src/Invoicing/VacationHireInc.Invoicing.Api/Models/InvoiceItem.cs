using VacationHireInc.Invoicing.Api.Data;

namespace VacationHireInc.Invoicing.Api.Models;

public class InvoiceItem : IEntity
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    public double ItemTotal { get; set; }
    public Guid FkInvoice { get; set; }
}