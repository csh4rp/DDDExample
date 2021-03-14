using System;
using System.Collections.Generic;

namespace DDDExample.Core.Application.DTO
{
    public class BookingDTO
    {
        public Guid Id { get; set; }
        public Guid LocationId { get; set; }
        public IEnumerable<Guid> UserIds { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public BookingDTO()
        {
        }

        public BookingDTO(Guid locationId, IEnumerable<Guid> userIds, DateTime startDate)
        {
            LocationId = locationId;
            UserIds = userIds;
            StartDate = startDate;
        }
    }
}