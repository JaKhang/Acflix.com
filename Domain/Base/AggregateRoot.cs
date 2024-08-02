using Domain.Base.ValueObjects;

namespace Domain.Base
{
    public abstract class AggregateRoot : Entity
    {
        protected AggregateRoot(ID id) : base(id)
        {
        }
    }
}
