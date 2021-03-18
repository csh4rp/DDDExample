using System;
using System.Collections.Generic;
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

        public BookingService(IDayBookingRepository dayBookingRepository, IBookingSettingService bookingSettingService)
        {
            _dayBookingRepository = dayBookingRepository;
            _bookingSettingService = bookingSettingService;
        }

        public Guid Add(BookingDTO booking)
        {
            var dayBooking = _dayBookingRepository.GetForDayAndLocation(booking.StartDate.Date, booking.LocationId) ??
                             new DayBooking(booking.StartDate.Date, booking.LocationId);
            
            var bookingTime = _bookingSettingService.GetBookingTime();
            var dateRange = new DateRange(booking.StartDate, booking.StartDate.Add(bookingTime));
            var dbBooking = dayBooking.AddBooking(dateRange, booking.UserIds);

            if (dayBooking.IsTransient)
            {
                _dayBookingRepository.Add(dayBooking);
            }
            else
            {
                _dayBookingRepository.Update(dayBooking);
            }

            return dbBooking.Id;
        }

        public void Cancel(Guid bookingId)
        {
            var dayBooking = _dayBookingRepository.GetByBookingId(bookingId);
            dayBooking.CancelBooking(bookingId);
            _dayBookingRepository.Update(dayBooking);
        }

        public void Reschedule(BookingRescheduleDTO booking)
        {
            var currentDayBooking = _dayBookingRepository.GetByBookingId(booking.Id) ?? new DayBooking(booking.StartDate, booking.LocationId);
            var bookingTime = _bookingSettingService.GetBookingTime();
            var dateRange = new DateRange(booking.StartDate, booking.StartDate.Add(bookingTime));
            if (currentDayBooking.Date != booking.StartDate.Date || currentDayBooking.LocationId != booking.LocationId)
            {
                var rescheduledDayBooking = _dayBookingRepository.GetForDayAndLocation(booking.StartDate, booking.LocationId) ?? new DayBooking(booking.StartDate, booking.LocationId);
                var oldBooking = rescheduledDayBooking.GetBooking(booking.Id);
                rescheduledDayBooking.CancelBooking(booking.Id);
                currentDayBooking.AddBooking(dateRange, oldBooking.UserIds);

                if (rescheduledDayBooking.IsTransient)
                {
                    _dayBookingRepository.Add(rescheduledDayBooking);
                }
                else
                {
                    _dayBookingRepository.Update(rescheduledDayBooking);
                }
            }
            else
            {
                currentDayBooking.Reschedule(booking.Id, dateRange);
            }

            if (currentDayBooking.IsTransient)
            {
                _dayBookingRepository.Add(currentDayBooking);
            }
            else
            {
                _dayBookingRepository.Update(currentDayBooking);
            }
        }
    }
}