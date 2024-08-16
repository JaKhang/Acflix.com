using Domain.Base.ValueObjects;
using Domain.Event;
using MediatR;

namespace Domain.Base
{
    public abstract class Entity : IEquatable<Entity?>
    {
        public ID Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime LastUpdatedAt { get; protected set; }
        public bool IsDeleted { get; protected set; }


        private List<DomainEvent> _domainEvents;
        public List<DomainEvent> DomainEvents => _domainEvents;

        public void AddDomainEvent(DomainEvent eventItem)
        {
            _domainEvents = _domainEvents ?? new List<DomainEvent>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(DomainEvent eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        protected Entity(ID id)
        {
            Id = id;
            CreatedAt = DateTime.Now;
            LastUpdatedAt = DateTime.Now;
        }

        protected Entity()
        {

        }


        public void Hide()
        {
            IsDeleted = true;
        }

        public void Show()
        {

            IsDeleted = false; 
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Entity);
        }

        public bool Equals(Entity? other)
        {
            return other is not null &&
                   EqualityComparer<ID>.Default.Equals(Id, other.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public static bool operator ==(Entity? left, Entity? right)
        {
            return EqualityComparer<Entity>.Default.Equals(left, right);
        }

        public static bool operator !=(Entity? left, Entity? right)
        {
            return !(left == right);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}
