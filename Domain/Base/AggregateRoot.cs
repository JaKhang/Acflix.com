using Domain.Base.ValueObjects;

namespace Domain.Base
{
    public abstract class AggregateRoot : Entity
    {
        protected AggregateRoot(Id id) : base(id)
        {
        }
    }
}
