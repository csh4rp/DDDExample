using System;
using System.Collections.Generic;
using DDDExample.Core.Application.DTO;

namespace DDDExample.Core.Application.Services
{
    public interface IBookingCacheService
    {
        void Add(BookingDTO booking);
        void Remove(Guid id);
        BookingDTO Get(Guid id);
        IEnumerable<BookingDTO> GetAll();
    }
}