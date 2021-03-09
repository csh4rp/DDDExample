using System;

namespace DDDExample.Core.Domain.Services
{
    public interface IBookingSettingService
    {
        TimeSpan GetBookingTime();
    }
}