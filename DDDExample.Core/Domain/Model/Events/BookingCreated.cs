using System;
using System.Collections.Generic;
using DDDExample.Core.Domain.Abstract;

namespace DDDExample.Core.Domain.Model.Events
{
    public class BookingCreated : DomainEvent
    {
        public DateRange DateRange { get; private set; }
        public IEnumerable<int> UserIds { get; set; }

        public BookingCreated(DateRange dateRange, IEnumerable<int> userIds)
        {
            DateRange = dateRange;
            UserIds = userIds;
        }
    }
}