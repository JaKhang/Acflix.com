using Domain.Base.ValueObjects;
using Domain.Film.ObjectValues;
using Domain.Base;

namespace Domain.Film.Entities
{
    public class Episode : Entity
    {
        public string Name { get; set; }
        public int Index { get; set; }
        public Source Source { get; set; }
        public String Label { get; set; }
        public ID SeriesId { get; set; }

        public Episode(ID id) : base(id)
        {

        }

        public Episode(string name, int index, Source source, string label, ID seriesId) : this(new())
        {
            Name = name;
            Index = index;
            Source = source;
            Label = label;
            SeriesId = seriesId;
        }
    }
}
