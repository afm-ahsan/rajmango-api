namespace RajMango.Domain.Common
{
    public abstract class Entity<TKey> : IEntity<TKey>
    {
        public virtual TKey Id { get; protected set; }

        protected Entity() { }

        protected Entity(TKey id)
        {
            Id = id;
        }
    }
}
