using ZeroFrictionInvoice.Domain.Entities.Invoices;

namespace ZeroFrictionInvoice.Domain.Repositories.Invoices;

public interface IInvoiceRepository : IRepository<Invoice>
{
    Task<IEnumerable<Invoice>> GetAllInvoicesAsync();

    Task<Invoice> GetInvoiceByIdAsync(string id);
}
