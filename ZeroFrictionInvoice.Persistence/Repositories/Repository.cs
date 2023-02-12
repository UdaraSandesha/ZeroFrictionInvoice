using ZeroFrictionInvoice.Domain.Entities;
using ZeroFrictionInvoice.Domain.Repositories;

namespace ZeroFrictionInvoice.Persistence.Repositories;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class, IAggregateRoot
{
    protected readonly ZeroFrictionInvoiceDbContext _context;

    protected Repository(ZeroFrictionInvoiceDbContext context)
    {
        _context = context;
    }

    public void Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>().AddRange(entities);
    }

    public void Remove(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>().RemoveRange(entities);
    }
}
