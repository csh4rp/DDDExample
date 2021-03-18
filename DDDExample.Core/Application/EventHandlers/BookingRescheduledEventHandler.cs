using DDDExample.Core.Application.DTO;
using DDDExample.Core.Application.Services;
using DDDExample.Core.Domain.Abstract;
using DDDExample.Core.Domain.Model.Events;

namespace DDDExample.Core.Application.EventHandlers
{
    public class BookingRescheduledEventHandler : IEventHandler<BookingRescheduled>
    {
        private readonly IBookingCacheService _bookingCacheService;

        public BookingRescheduledEventHandler(IBookingCacheService bookingCacheService)
        {
            _bookingCacheService = bookingCacheService;
        }

        public void Handle(BookingRescheduled @event)
        {
            var dto = new BookingDTO
            {
                Id = @event.BookingId,
                LocationId = @event.LocationId,
                StartDate = @event.DateRange.StartDate,
                EndDate = @event.DateRange.EndDate,
                UserIds = @event.UserIds
            };
            
            _bookingCacheService.Add(dto);
        }
    }
}