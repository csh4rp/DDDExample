using System;

namespace DDDExample.Core.Domain.Model
{
    public class BookingUser
    {
        public Guid BookingId { get; private set; }
        public Guid UserId { get; private set; }

        private BookingUser()
        {
        }
        
        public BookingUser(Guid bookingId, Guid userId)
        {
            BookingId = bookingId;
            UserId = userId;
        }
    }
}