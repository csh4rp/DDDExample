using System;
using System.Linq;
using DDDExample.Core.Domain.Model;
using DDDExample.Core.Domain.Repositories;

namespace DDDExample.Core.Infrastructure.Repositories
{
    internal sealed class DayBookingRepository : IDayBookingRepository
    {
        private readonly IRepository<DayBooking, Guid> _repository;

        public DayBookingRepository(IRepository<DayBooking, Guid> repository)
        {
            _repository = repository;
        }

        public void Add(DayBooking dayBooking)
        {
            _repository.Add(dayBooking);
        }

        public void Update(DayBooking dayBooking)
        {
            _repository.Update(dayBooking);
        }

        public DayBooking GetForDayAndLocation(DateTime dateTime, Guid locationId) =>
            _repository.Queryable.FirstOrDefault(entity => entity.Date == dateTime && entity.LocationId == locationId);

        public DayBooking GetByBookingId(Guid bookingId) => _repository.Queryable
            .FirstOrDefault(entity => entity.Bookings.Any(booking => booking.Id == bookingId));
    }
}