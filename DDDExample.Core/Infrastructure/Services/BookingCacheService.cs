using System;
using System.Collections.Generic;
using DDDExample.Core.Application.DTO;
using DDDExample.Core.Application.Services;

namespace DDDExample.Core.Infrastructure.Services
{
    internal sealed class BookingCacheService : IBookingCacheService
    {
        private static readonly Dictionary<Guid, BookingDTO> Bookings = new();
        
        public void Add(BookingDTO booking)
        {
            Bookings[booking.Id] = booking;
        }

        public void Remove(Guid id)
        {
            Bookings.Remove(id);
        }

        public BookingDTO Get(Guid id)
        {
            return Bookings.TryGetValue(id, out var booking) ? booking : null;
        }

        public IEnumerable<BookingDTO> GetAll()
        {
            return Bookings.Values;
        }
    }
}