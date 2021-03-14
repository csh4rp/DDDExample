using System;
using DDDExample.Core.Domain.Abstract;

namespace DDDExample.Core.Infrastructure.Events
{
    internal sealed class EventPublisher : IEventPublisher
    {
        private readonly IServiceProvider _serviceProvider;

        public EventPublisher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Publish(DomainEvent domainEvent)
        {
            var type = domainEvent.GetType();
            var handlerType = typeof(IEventHandler<>).MakeGenericType(type);

            var handler = _serviceProvider.GetService(handlerType);
            var method = handlerType.GetMethod("Handle");
            method.Invoke(handler, new[]{domainEvent});
        }
    }
}