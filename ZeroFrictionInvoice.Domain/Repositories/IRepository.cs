using ZeroFrictionInvoice.Domain.Entities;

namespace ZeroFrictionInvoice.Domain.Repositories;

public interface IRepository<TEntity>
    where TEntity : class, IAggregateRoot
{
    void Remove(TEntity entity);

    void Add(TEntity entity);

    void AddRange(IEnumerable<TEntity> entities);

    void RemoveRange(IEnumerable<TEntity> entities);
}