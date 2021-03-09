using System;

namespace DDDExample.Core.Domain.Abstract
{
    public abstract class DomainEvent
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime OccuredAt { get; private set; } = DateTime.UtcNow;
    }
}