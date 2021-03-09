using System;
using System.Collections.Generic;

namespace DDDExample.Core.Application.DTO
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public IEnumerable<int> UserIds { get; set; }
        public DateTime StartDate { get; set; }
    }
}