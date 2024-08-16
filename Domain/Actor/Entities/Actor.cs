using Domain.Base;
using Domain.Base.ValueObjects;

namespace Domain.Actor.Entities
{
    public class Actor : AggregateRoot
    {
        public ID AvatarId { get; private set; }
        public string Name { get; private set; }



        public Actor(ID avatarId, string name) : base(new())
        {
            AvatarId = avatarId;
            Name = name;
        }

        public Actor() : base(new())
        {

        }
    }
}
