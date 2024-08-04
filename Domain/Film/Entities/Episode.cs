using Domain.Base.ValueObjects;
using Domain.Film.ObjectValues;
using Domain.Base;

namespace Domain.Film.Entities
{
    public class Episode : Entity
    {
        public string Name { get; protected set; }
        public int Index { get; protected set; }
        public Source Source { get; protected set; }
        public string Label { get; protected set; }
        public ID FilmId { get; protected set; }
        public Episode() : base(new())
        {

        }

        public Episode(string name, int index, Source source, string label, ID filmId) : base(new())
        {
            Name = name;
            Index = index;
            Source = source;
            Label = label;
            FilmId = filmId;
        }
    }
}
