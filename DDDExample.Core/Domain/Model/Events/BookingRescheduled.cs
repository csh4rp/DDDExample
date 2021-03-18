using System;
using System.Collections.Generic;
using DDDExample.Core.Domain.Abstract;

namespace DDDExample.Core.Domain.Model.Events
{
    public class BookingRescheduled : DomainEvent
    {
        public Guid BookingId { get; private set; }
        public Guid LocationId { get; private set; }
        public DateRange DateRange { get; private set; }
        public IEnumerable<Guid> UserIds { get; private set; }

        public BookingRescheduled(Guid bookingId, Guid locationId, DateRange dateRange, IEnumerable<Guid> userIds)
        {
            BookingId = bookingId;
            LocationId = locationId;
            DateRange = dateRange;
            UserIds = userIds;
        }
    }
}