using System.Collections.Generic;

namespace DDDExample.Core.Domain.Abstract
{
    public abstract class AggregateRoot<TKey> : Entity<TKey>
    {
        private readonly List<DomainEvent> _domainEvents = new();
        
        public int Version { get; protected set; }

        public IReadOnlyList<DomainEvent> DomainEvents => _domainEvents;

        public void RegisterDomainEvent(DomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
        
        public void ClearEvents() => _domainEvents.Clear();
    }
}