using Domain.Base;
using Domain.Base.ValueObjects;

namespace Domain.Category
{
    public class Category : AggregateRoot
    {
        public Id CoverId { get; private set; }
        public string Name { get; private set; }
        public List<Id> FilmIds { get; private set; }
        public int Popularity  { get; private set; }
        public Category() : base(new())
        {

        }

        public Category(Id coverId, string name, List<Id> filmIds, int popularity) : base(new Id())
        {
            CoverId = coverId;
            Name = name;
            FilmIds = filmIds;
            Popularity = popularity;
        }
    }
}
