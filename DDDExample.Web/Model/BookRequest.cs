using System;
using System.Collections.Generic;

namespace DDDExample.Web.Model
{
    public class BookRequest
    {
        public Guid LocationId { get; set; }
        public IEnumerable<Guid> UserIds { get; set; }
        public DateTime StartDate { get; set; }
    }
}