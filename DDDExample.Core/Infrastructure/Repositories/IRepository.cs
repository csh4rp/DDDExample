using System.Linq;
using DDDExample.Core.Domain.Abstract;

namespace DDDExample.Core.Infrastructure.Repositories
{
    public interface IRepository<TEntity, TKey> where TEntity : Entity<TKey>
    {
        IQueryable<TEntity> Entities { get; }
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity GetById(TKey id);
    }
}