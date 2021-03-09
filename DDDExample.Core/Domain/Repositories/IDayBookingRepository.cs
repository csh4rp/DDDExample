using System;
using DDDExample.Core.Domain.Model;

namespace DDDExample.Core.Domain.Repositories
{
    public interface IDayBookingRepository
    {
        void Add(DayBooking dayBooking);
        void Update(DayBooking dayBooking);
        DayBooking GetForDayAndLocation(DateTime dateTime, int locationId);
    }
}