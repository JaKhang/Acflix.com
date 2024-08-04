using Domain.Base;
using Domain.Base.ValueObjects;

namespace Domain.Director
{
    public class Director : Entity
    {
        public Director() : base(new())
        {
        }



        public string Name { get; }
    }
}
