using DDDExample.Core.Domain.Abstract;

namespace DDDExample.Core.Domain.Model.Exceptions
{
    public sealed class InvalidUsersException : DomainException
    {
        public InvalidUsersException(string message) : base(message)
        {
        }

        public override string Code => "invalid_users";
    }
}