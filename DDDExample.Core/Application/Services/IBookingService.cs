using System;
using System.Collections.Generic;
using DDDExample.Core.Application.DTO;

namespace DDDExample.Core.Application.Services
{
    public interface IBookingService
    {
        int Add(BookingDTO booking);
        void Cancel(DateTime date, int locationId, int bookingId);
        List<BookingDTO> GetAll(DateTime date, int locationId);
    }
}