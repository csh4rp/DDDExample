using System;
using DDDExample.Core.Application.DTO;
using DDDExample.Core.Domain.Model;
using DDDExample.Core.Domain.Repositories;
using DDDExample.Core.Domain.Services;

namespace DDDExample.Core.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IDayBookingRepository _dayBookingRepository;
        private readonly IBookingSettingService _bookingSettingService;
        
        public void Add(BookingDTO booking)
        {
            var dayBooking = _dayBookingRepository.GetForDayAndLocation(booking.StartDate.Date, booking.LocationId) ??
                             new DayBooking(booking.StartDate.Date, booking.LocationId);
            
            var bookingTime = _bookingSettingService.GetBookingTime();
            var dateRange = new DateRange(booking.StartDate, booking.StartDate.Add(bookingTime));
            dayBooking.AddBooking(dateRange, booking.UserIds);

            if (dayBooking.IsTransient)
            {
                _dayBookingRepository.Add(dayBooking);
            }
            else
            {
                _dayBookingRepository.Update(dayBooking);
            }
        }
    }
}