using Employee.Permissions.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Permissions.Domain.Primitives
{
    public abstract class AggregateRoot
    {
        private readonly List<DomainEvent> _domainEvents = new();

        public ICollection<DomainEvent> GetDomainEvents() => _domainEvents;

        protected void Raise(DomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
