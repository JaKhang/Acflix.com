using Domain.Base.ValueObjects;

namespace Domain.Base
{
    public abstract class Entity : IEquatable<Entity?>
    {
        public ID Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime LastUpdatedAt { get; protected set; }
        public bool IsDeleted { get; protected set; }



        protected Entity(ID id)
        {
            Id = id;
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
    }
}
