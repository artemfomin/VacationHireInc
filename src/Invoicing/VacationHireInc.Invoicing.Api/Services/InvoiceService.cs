using VacationHireInc.Invoicing.Api.Core.Exceptions;
using VacationHireInc.Invoicing.Api.Core.Result;
using VacationHireInc.Invoicing.Api.Data.Repositories.Core;
using VacationHireInc.Invoicing.Api.Models;

namespace VacationHireInc.Invoicing.Api.Services;

internal interface IInvoiceService
{
    Task<Result> CreateInvoice(Invoice invoice, CancellationToken ct);
    Task<Result<Invoice>> GetInvoice(Guid id, CancellationToken ct);
    Task<Result<IList<Invoice>>> GetInvoices(CancellationToken ct);
}

internal class InvoiceService(ICrudRepository<Invoice> invoiceRepo) : IInvoiceService
{
    public async Task<Result> CreateInvoice(Invoice invoice, CancellationToken ct)
    {
        var result = await invoiceRepo.CreateAsync(invoice, ct);
        
        return result.Id.Equals(Guid.Empty)
            ? Result.Failure(new InvalidOperationException("Error creating invoice"))
            : Result.Success();
    }

    public async Task<Result<Invoice>> GetInvoice(Guid id, CancellationToken ct)
    {
        var result = await invoiceRepo.GetAsync(id, ct);
        return result is null
            ? Result<Invoice>.Failure(new NotFoundException($"Invoice with ID {id} not found"))
            : Result<Invoice>.Success(result);
    }
    
    public async Task<Result<IList<Invoice>>> GetInvoices(CancellationToken ct)
    {
        var result = await invoiceRepo.GetManyAsync(ct);
        return result is null || !result.Any()
            ? Result<IList<Invoice>>.Failure(new NotFoundException($"No invoices have been found"))
            : Result<IList<Invoice>>.Success(result);
    }
}