using System;
using DDDExample.Core.Domain.Abstract;

namespace DDDExample.Core.Domain.Model.Events
{
    public class BookingCancelled : DomainEvent
    {
        public int BookingId { get; private set; }

        public BookingCancelled(int bookingId) => BookingId = bookingId;
    }
}