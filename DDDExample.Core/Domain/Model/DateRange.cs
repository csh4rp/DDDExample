using System;
using DDDExample.Core.Domain.Abstract;
using DDDExample.Core.Domain.Model.Exceptions;

namespace DDDExample.Core.Domain.Model
{
    public record DateRange : IValueObject<DateRange>
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public DateRange(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate > DateTime.UtcNow
                ? startDate
                : throw new InvalidDateException("Start date must be in future.");
            EndDate = endDate > startDate
                ? endDate
                : throw new InvalidDateException("End date must be greater than start date.");
        }
        
        public bool Overlaps(DateRange dateRange)
        {
            if (dateRange.StartDate <= StartDate && dateRange.EndDate > StartDate)
            {
                return true;
            }

            if (dateRange.StartDate <= StartDate && dateRange.EndDate >= EndDate)
            {
                return true;
            }

            if (dateRange.StartDate >= StartDate && dateRange.StartDate <= EndDate && dateRange.EndDate <= EndDate)
            {
                return false;
            }

            if (dateRange.StartDate >= StartDate && dateRange.StartDate < EndDate && dateRange.EndDate >= EndDate)
            {
                return false;
            }
            
            return false;
        }
    }
}