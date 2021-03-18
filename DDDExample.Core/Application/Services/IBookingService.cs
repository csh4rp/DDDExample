using System;
using System.Collections.Generic;
using DDDExample.Core.Application.DTO;

namespace DDDExample.Core.Application.Services
{
    public interface IBookingService
    {
        Guid Add(BookingDTO booking);
        void Cancel(Guid bookingId);
        void Reschedule(BookingRescheduleDTO booking);
    }
}