using System;

namespace DDDExample.Core.Domain.Abstract
{
    public abstract class DomainException : Exception
    {
        protected DomainException(string message) : base(message)
        {
            
        }
        
        public abstract string Code { get; }
    }
}