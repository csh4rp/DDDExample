using System.Collections.Generic;
using System.Linq;
using DDDExample.Core.Domain.Abstract;

namespace DDDExample.Core.Infrastructure.Repositories
{
    internal sealed class InMemoryRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : Entity<TKey>
    {
        private readonly Dictionary<TKey, TEntity> _entities = new();

        public IQueryable<TEntity> Entities => _entities.Values.AsQueryable();

        public void Add(TEntity entity)
        {
            _entities.Add(entity.Id, entity);
        }

        public void Update(TEntity entity)
        {
            _entities[entity.Id] = entity;
        }

        public void Delete(TEntity entity)
        {
            _entities.Remove(entity.Id);
        }

        public TEntity GetById(TKey id) => _entities[id];
    }
}