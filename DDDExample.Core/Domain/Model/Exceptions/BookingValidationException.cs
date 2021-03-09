using System.Collections.Generic;
using DDDExample.Core.Domain.Abstract;

namespace DDDExample.Core.Domain.Model.Exceptions
{
    public sealed class BookingValidationException : DomainException
    {
        public BookingValidationException(string message) : base(message)
        {
        }
        
        public BookingValidationException(IEnumerable<string> errors) : base($"Errors: {string.Join(",", errors)}")
        {
        }

        public override string Code => "booking_validation_exception";
    }
}