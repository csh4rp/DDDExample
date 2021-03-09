using DDDExample.Core.Domain.Abstract;

namespace DDDExample.Core.Domain.Model.Exceptions
{
    public sealed class BookingNotFoundException : DomainException
    {
        public BookingNotFoundException(string message) : base(message)
        {
        }

        public override string Code => "booking_not_found";
    }
}