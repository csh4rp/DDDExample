using DDDExample.Core.Domain.Abstract;

namespace DDDExample.Core.Infrastructure.Events
{
    public interface IEventPublisher
    {
        void Publish(DomainEvent domainEvent);
    }
}