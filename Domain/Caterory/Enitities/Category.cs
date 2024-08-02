using Domain.Base.ValueObjects;
using Domain.Base;

namespace Domain.Caterory.Enitities
{
    public class Category : AggregateRoot
    {
        public ID CoverId { get; set; }
        public string Name { get; set; }
        public readonly List<ID> FilmIds = [];


    }
}
