namespace Identity.Domain.Core.Bases.SeedWork
{
    public interface IDomainEvent
    {
    }

    public abstract record class Message
    {
        public string MessageType { get; init; }
        public Guid AggregateId { get; init; }

        protected Message()
        {
            MessageType = GetType().FullName;
        }
    }

    public abstract record class DomainEvent : Message, IDomainEvent
    {
        public DateTime CreatedAt { get; init; }

        public DomainEvent()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
