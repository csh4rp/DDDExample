using System;
using System.Collections.Generic;
using DDDExample.Core.Domain.Abstract;

namespace DDDExample.Core.Domain.Model.Events
{
    public class BookingCreated : DomainEvent
    {
        public Guid BookingId { get; set; }
        public Guid LocationId { get; set; }
        public DateRange DateRange { get; private set; }
        public IEnumerable<Guid> UserIds { get; set; }

        public BookingCreated(Guid bookingId, Guid locationId, DateRange dateRange, IEnumerable<Guid> userIds)
        {
            BookingId = bookingId;
            LocationId = locationId;
            DateRange = dateRange;
            UserIds = userIds;
        }
    }
}