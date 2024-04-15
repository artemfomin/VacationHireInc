using Microsoft.EntityFrameworkCore;
using VacationHireInc.Invoicing.Api.Models;

namespace VacationHireInc.Invoicing.Api.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<InvoiceItem> InvoiceItems { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Invoice>()
            .HasMany(x => x.Items)
            .WithOne()
            .HasForeignKey(x => x.FkInvoice)
            .OnDelete(DeleteBehavior.Cascade);
    }
}