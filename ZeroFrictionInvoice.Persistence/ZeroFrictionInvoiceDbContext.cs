using Microsoft.EntityFrameworkCore;
using ZeroFrictionInvoice.Domain.Entities.Invoices;

namespace ZeroFrictionInvoice.Persistence;

public class ZeroFrictionInvoiceDbContext : DbContext
{
    public ZeroFrictionInvoiceDbContext(DbContextOptions<ZeroFrictionInvoiceDbContext> options)
        : base(options)
    {
    }

    public DbSet<Invoice> Invoices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Invoice>()
            .ToContainer("Invoices")
            .HasPartitionKey(i => i.Id);

        modelBuilder.Entity<Invoice>().OwnsMany(i => i.InvoiceLines);
    }
}
