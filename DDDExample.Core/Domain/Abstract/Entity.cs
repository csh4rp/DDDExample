namespace DDDExample.Core.Domain.Abstract
{
    public abstract class Entity<TKey>
    {
        public TKey Id { get; protected set; }

        public bool IsTransient => Id is null || Id.Equals(default);
    }
}