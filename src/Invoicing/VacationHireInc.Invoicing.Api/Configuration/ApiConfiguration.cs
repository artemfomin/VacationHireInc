using VacationHireInc.Invoicing.Api.Models;
using VacationHireInc.Invoicing.Api.Services;

namespace VacationHireInc.Invoicing.Api.Configuration;

internal static class ApiConfiguration
{
    internal static WebApplication ConfigureApi(this WebApplication app)
    {
        var invoiceApi = app.MapGroup("/invoices");

        invoiceApi.MapGet("/", async (HttpContext http) =>
        {
            var invoices = await http.RequestServices.GetRequiredService<IInvoiceService>().GetInvoices(new CancellationToken());
            if (invoices.Failed)
                return Results.BadRequest(invoices.Errors.Select(x => x.Message));
            
            return invoices.Failed || !invoices.Payload.Any()
                ? Results.NotFound()
                : Results.Ok(invoices.Payload);
        });
        
        invoiceApi.MapGet("/{id}", async (HttpContext http, Guid id) =>
        {
            var invoice = await http.RequestServices.GetRequiredService<IInvoiceService>().GetInvoice(id, new CancellationToken());
            return invoice is null
                ? Results.NotFound()
                : Results.Ok(invoice);
        });
        
        invoiceApi.MapPost("/", async (HttpContext http, Invoice invoice) =>
            await http.RequestServices.GetRequiredService<IInvoiceService>().CreateInvoice(invoice, new CancellationToken()));
        
        return app;
    }
}