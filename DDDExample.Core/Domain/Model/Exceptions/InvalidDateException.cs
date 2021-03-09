using DDDExample.Core.Domain.Abstract;

namespace DDDExample.Core.Domain.Model.Exceptions
{
    public sealed class InvalidDateException : DomainException
    {
        public InvalidDateException(string message) : base(message)
        {
        }

        public override string Code => "invalid_date";
    }
}