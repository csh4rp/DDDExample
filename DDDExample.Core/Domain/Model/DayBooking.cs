using System;
using System.Collections.Generic;
using System.Linq;
using DDDExample.Core.Domain.Abstract;
using DDDExample.Core.Domain.Model.Events;
using DDDExample.Core.Domain.Model.Exceptions;
using DDDExample.Core.Domain.Model.Rules;

namespace DDDExample.Core.Domain.Model
{
    public class DayBooking : AggregateRoot<Guid>
    {
        private List<Booking> _bookings = new();
        public DateTime Date { get; private set; }
        public Guid LocationId { get; private set; }

        public IEnumerable<Booking> Bookings => _bookings;

        public DayBooking(DateTime date, Guid locationId)
        {
            Id = Guid.NewGuid();
            Date = date.Date;
            LocationId = locationId;
        }

        public Booking AddBooking(DateRange dateRange, IEnumerable<Guid> userIds)
        {
            var booking = new Booking(Id, dateRange, userIds);
            foreach (var rule in GetValidationRules())
            {
                var validationResult = rule.Validate(booking);
                if (!validationResult.IsValid)
                {
                    throw new BookingValidationException(validationResult.Errors);
                }
            }
            
            RegisterDomainEvent(new BookingCreated(booking.Id, LocationId, dateRange, userIds));
            _bookings.Add(booking);
            return booking;
        }

        public void CancelBooking(Guid bookingId)
        {
            var bookingToCancel = _bookings.FirstOrDefault(booking => booking.Id == bookingId);
            if (bookingToCancel is null)
            {
                throw new BookingNotFoundException($"Booking with ID: \"{bookingId}\" was not found.");
            }
            
            RegisterDomainEvent(new BookingCancelled(bookingId));
            bookingToCancel.Cancel();
        }

        private IEnumerable<IBusinessRule<Booking>> GetValidationRules()
        {
            yield return new BookingOverlappingRule(_bookings);
            yield return new SingleBookingPerDayRule(_bookings);
        }
    }
}