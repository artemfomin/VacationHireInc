using VacationHireInc.Invoicing.Api.Models;
using VacationHireInc.Invoicing.Api.Services;

namespace VacationHireInc.Invoicing.Api.Configuration;

internal static class ApiConfiguration
{
    internal static WebApplication ConfigureApi(this WebApplication app)
    {
        var invoiceApi = app.MapGroup("/invoices");

        invoiceApi.MapGet("/", async (HttpContext http) =>
            await http.RequestServices.GetRequiredService<IInvoiceService>().GetInvoices(new CancellationToken()));
        
        invoiceApi.MapGet("/{id}", async (HttpContext http, Guid id) =>
            await http.RequestServices.GetRequiredService<IInvoiceService>().GetInvoice(id, new CancellationToken()));
        
        invoiceApi.MapPost("/", async (HttpContext http, Invoice invoice) =>
            await http.RequestServices.GetRequiredService<IInvoiceService>().CreateInvoice(invoice, new CancellationToken()));
        
        return app;
    }
}