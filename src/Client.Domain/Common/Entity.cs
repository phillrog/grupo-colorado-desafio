namespace Client.Domain.Common
{
    public abstract class Entity
    {
        public Entity() {}
    }

    public abstract class BasicEntity<T> : Entity
    {
        public T Id { get; protected set; }

        protected BasicEntity(T id)
        {
            Id = id;
        }
    }
}
