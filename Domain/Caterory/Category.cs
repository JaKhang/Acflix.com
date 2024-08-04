using Domain.Base.ValueObjects;
using Domain.Base;

namespace Domain.Caterory
{
    public class Category : AggregateRoot
    {
        public ID CoverId { get; private set; }
        public string Name { get; private set; }
        public List<ID> FilmIds { get; private set; } = [];

        public Category() : base(new())
        {

        }

        public Category(ID id, ID coverId, string name) : base(id)
        {
            Name = name;
            CoverId = coverId;
        }
    }
}
