using System;
using System.Collections.Generic;
using System.Linq;
using DDDExample.Core.Domain.Abstract;
using DDDExample.Core.Domain.Model.Exceptions;

namespace DDDExample.Core.Domain.Model
{
    public class Booking : Entity<Guid>
    {
        private List<BookingUser> _users = new();
        
        public Guid DayBookingId { get; private set; }
        public DateTime StartsAt { get; private set; }
        public DateTime EndsAt { get; private set; }
        public DateTime? CancelledAt { get; private set; }
        internal DateRange DateRange => new(StartsAt, EndsAt);
        internal IEnumerable<Guid> UserIds => _users.Select(user => user.UserId);

        private Booking()
        {
        }

        public Booking(Guid dayBookingId, DateRange dateRange, IEnumerable<Guid> userIds)
        {
            Id = Guid.NewGuid();
            DayBookingId = dayBookingId;
            StartsAt = dateRange.StartDate;
            EndsAt = dateRange.EndDate;
            _users = userIds?.Any() == true
                ? userIds.Select(userId => new BookingUser(Id, userId)).ToList()
                : throw new InvalidUsersException("Booking has to have at least one user.");
        }

        public bool IsOverlappingWith(DateRange dateRange) => DateRange.Overlaps(dateRange);

        public bool IncludesUserWithId(Guid userId) => _users.Any(user => user.UserId == userId);

        public void Cancel() => CancelledAt = DateTime.UtcNow;

    }
}