using System.Collections.Generic;
using System.Linq;
using DDDExample.Core.Domain.Abstract;
using DDDExample.Core.Infrastructure.Events;

namespace DDDExample.Core.Infrastructure.Repositories
{
    internal sealed class InMemoryRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : AggregateRoot<TKey>
    {
        private static readonly Dictionary<TKey, TEntity> Entities = new();
        private readonly IEventPublisher _eventPublisher;

        public InMemoryRepository(IEventPublisher eventPublisher)
        {
            _eventPublisher = eventPublisher;
        }

        public IQueryable<TEntity> Queryable => Entities.Values.AsQueryable();

        public void Add(TEntity entity)
        {
            Entities.Add(entity.Id, entity);
            PublishEvents(entity);
        }

        public void Update(TEntity entity)
        {
            Entities[entity.Id] = entity;
            PublishEvents(entity);
        }

        public void Delete(TEntity entity)
        {
            Entities.Remove(entity.Id);
        }

        public TEntity GetById(TKey id) => Entities.TryGetValue(id, out var entity) ? entity : null;

        private void PublishEvents(TEntity entity)
        {
            foreach (var domainEvent in entity.DomainEvents)
            {
                _eventPublisher.Publish(domainEvent);
            }
            
            entity.ClearEvents();
        }
    }
}