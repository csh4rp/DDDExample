using System.Collections.Generic;
using System.Linq;
using DDDExample.Core.Domain.Abstract;

namespace DDDExample.Core.Domain.Model.Rules
{
    public class SingleBookingPerDayRule : IBusinessRule<Booking>
    {
        private IEnumerable<Booking> _dayBookings;

        public SingleBookingPerDayRule(IEnumerable<Booking> dayBookings)
        {
            _dayBookings = dayBookings;
        }

        public RuleValidationResult Validate(Booking entity)
        {
            foreach (var userId in entity.UserIds)
            {
                if (_dayBookings.Any(booking => booking.IncludesUserWithId(userId)))
                {
                    return RuleValidationResult.Invalid($"User with ID: \"{userId}\" already has booking in that day.");
                }
            }
            
            return RuleValidationResult.Valid;
        }
    }
}