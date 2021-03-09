using System;
using DDDExample.Core.Application.DTO;

namespace DDDExample.Core.Application.Services
{
    public interface IBookingService
    {
        void Add(BookingDTO booking);
    }
}