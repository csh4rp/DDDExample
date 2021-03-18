using System.Collections.Generic;
using System.Linq;
using DDDExample.Core.Domain.Abstract;

namespace DDDExample.Core.Domain.Model.Rules
{
    public class BookingOverlappingRule : IBusinessRule<Booking>
    {
        private readonly IEnumerable<Booking> _dayBookings;

        public BookingOverlappingRule(IEnumerable<Booking> bookings) => _dayBookings = bookings;

        public RuleValidationResult Validate(Booking entity) => 
            _dayBookings.Any(booking => booking.Id != entity.Id 
                                        && !booking.CancelledAt.HasValue 
                                        && booking.IsOverlappingWith(entity.DateRange))
                ? RuleValidationResult.Invalid("Booking overlaps with another booking.")
                : RuleValidationResult.Valid;
        
    }
}