using Microsoft.EntityFrameworkCore;
using ZeroFrictionInvoice.Domain.Entities.Invoices;
using ZeroFrictionInvoice.Domain.Repositories.Invoices;

namespace ZeroFrictionInvoice.Persistence.Repositories.Invoices;

public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
{
    public InvoiceRepository(ZeroFrictionInvoiceDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<Invoice>> GetAllInvoicesAsync()
    {
        return await _context.Invoices.ToListAsync();
    }

    public async Task<Invoice> GetInvoiceByIdAsync(string id)
    {
        return await _context.Invoices.FirstOrDefaultAsync(i => i.Id == id);
    }
}