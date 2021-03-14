using System;
using DDDExample.Core.Domain.Services;

namespace DDDExample.Core.Infrastructure.Services
{
    internal sealed class BookingSettingService : IBookingSettingService
    {
        public TimeSpan GetBookingTime() => TimeSpan.FromHours(1);
    }
}