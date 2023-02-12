using ZeroFrictionInvoice.Domain.Repositories;

namespace ZeroFrictionInvoice.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ZeroFrictionInvoiceDbContext _context;

    public UnitOfWork(ZeroFrictionInvoiceDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}