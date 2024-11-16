using Domain.Base;
using Domain.Base.ValueObjects;

namespace Domain.Director
{
    public class Director : Entity
    {
        public Director() : base(new())
        {
        }

        public Director(string name) : base(new())
        {
            Name = name;
        }


        public string Name { get; protected set; }
    }
}
