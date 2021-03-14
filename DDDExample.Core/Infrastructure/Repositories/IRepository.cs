using System.Linq;
using DDDExample.Core.Domain.Abstract;

namespace DDDExample.Core.Infrastructure.Repositories
{
    public interface IRepository<TEntity, in TKey> where TEntity : AggregateRoot<TKey>
    {
        IQueryable<TEntity> Queryable { get; }
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity GetById(TKey id);
    }
}