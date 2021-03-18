using System;
using System.Collections.Generic;

namespace DDDExample.Core.Application.DTO
{
    public class BookingRescheduleDTO
    {
        public Guid Id { get; set; }
        public Guid LocationId { get; set; }
        public DateTime StartDate { get; set; }

        public BookingRescheduleDTO(Guid id, Guid locationId, DateTime startDate)
        {
            Id = id;
            LocationId = locationId;
            StartDate = startDate;
        }
    }
}