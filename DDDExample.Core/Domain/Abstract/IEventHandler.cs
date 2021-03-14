namespace DDDExample.Core.Domain.Abstract
{
    public interface IEventHandler<in TEvent> where  TEvent : DomainEvent
    {
        void Handle(TEvent @event);
    }
}