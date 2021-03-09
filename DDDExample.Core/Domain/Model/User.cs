using System;
using DDDExample.Core.Domain.Abstract;

namespace DDDExample.Core.Domain.Model
{
    public class User : AggregateRoot<Guid>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        
        public User(Guid id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}