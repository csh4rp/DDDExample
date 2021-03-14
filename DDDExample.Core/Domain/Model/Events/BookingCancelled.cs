using System;
using DDDExample.Core.Domain.Abstract;

namespace DDDExample.Core.Domain.Model.Events
{
    public class BookingCancelled : DomainEvent
    {
        public Guid BookingId { get; private set; }

        public BookingCancelled(Guid bookingId) => BookingId = bookingId;
    }
}