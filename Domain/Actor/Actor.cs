using Domain.Base;
using Domain.Base.ValueObjects;

namespace Domain.Actor
{
    public class Actor : AggregateRoot
    {
        public ID Id { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public ID AvatarId { get; set; };

    }
}
