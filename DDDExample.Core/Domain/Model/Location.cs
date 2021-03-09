using System;
using DDDExample.Core.Domain.Abstract;

namespace DDDExample.Core.Domain.Model
{
    public class Location : AggregateRoot<Guid>
    {
        public string Name { get; set; }

        public Location(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}