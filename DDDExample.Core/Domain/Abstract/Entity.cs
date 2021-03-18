namespace DDDExample.Core.Domain.Abstract
{
    public abstract class Entity<TKey>
    {
        public TKey Id { get; protected set; }

        public bool IsTransient { get; internal set; }

        protected Entity()
        {
        }

        protected Entity(TKey id)
        {
            Id = id;
            IsTransient = true;
        }
    }
}