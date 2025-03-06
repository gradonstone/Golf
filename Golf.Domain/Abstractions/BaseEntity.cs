namespace Golf.Domain.Abstractions
{
    public abstract class BaseEntity
    {
        protected BaseEntity(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; init; }
    }
}
