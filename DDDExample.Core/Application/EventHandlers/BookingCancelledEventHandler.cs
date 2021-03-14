using DDDExample.Core.Application.Services;
using DDDExample.Core.Domain.Abstract;
using DDDExample.Core.Domain.Model.Events;

namespace DDDExample.Core.Application.EventHandlers
{
    public sealed class BookingCancelledEventHandler : IEventHandler<BookingCancelled>
    {
        private readonly IBookingCacheService _bookingCacheService;

        public BookingCancelledEventHandler(IBookingCacheService bookingCacheService)
        {
            _bookingCacheService = bookingCacheService;
        }

        public void Handle(BookingCancelled @event)
        {
            _bookingCacheService.Remove(@event.BookingId);
        }
    }
}