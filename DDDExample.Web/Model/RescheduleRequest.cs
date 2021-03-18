using System;

namespace DDDExample.Web.Model
{
    public class RescheduleRequest
    {
        public Guid LocationId { get; set; }
        public DateTime StartDate { get; set; }
    }
}