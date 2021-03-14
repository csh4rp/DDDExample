using DDDExample.Core.Application.DTO;
using DDDExample.Core.Application.Services;
using DDDExample.Core.Domain.Abstract;
using DDDExample.Core.Domain.Model.Events;

namespace DDDExample.Core.Application.EventHandlers
{
    public sealed class BookingCreatedEventHandler : IEventHandler<BookingCreated>
    {
        private readonly IBookingCacheService _bookingCacheService;

        public BookingCreatedEventHandler(IBookingCacheService bookingCacheService)
        {
            _bookingCacheService = bookingCacheService;
        }

        public void Handle(BookingCreated @event)
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