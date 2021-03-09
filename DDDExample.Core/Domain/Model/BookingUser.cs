using System;

namespace DDDExample.Core.Domain.Model
{
    public class BookingUser
    {
        public int BookingId { get; private set; }
        public int UserId { get; private set; }

        private BookingUser()
        {
        }
        
        public BookingUser(int bookingId, int userId)
        {
            BookingId = bookingId;
            UserId = userId;
        }
    }
}