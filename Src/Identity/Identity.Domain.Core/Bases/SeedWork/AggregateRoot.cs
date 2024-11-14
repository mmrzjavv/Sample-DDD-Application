﻿namespace Identity.Domain.Core.Bases.SeedWork
{
    public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot
    {
       
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents = _domainEvents ?? new List<IDomainEvent>();
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        private List<IDomainEvent> _domainEvents;
       
    }
}
