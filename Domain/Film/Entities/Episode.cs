using Domain.Base.ValueObjects;
using Domain.Film.ObjectValues;
using Domain.Base;

namespace Domain.Film.Entities
{
    public class Episode : Entity
    {
        public string Name { get; protected set; }
        public int Index { get; protected set; }
        public Video Video {  get; set; }
        public string Label { get; protected set; }
        public ID FilmId { get; protected set; }
        public ID VideoId {  get; protected set; }

        public Episode() : base(new())
        {

        }

        public Episode(string name, int index, Video video, string label, ID filmId) : base(new())
        {
            Name = name;
            Index = index;
            Video = video;
            Label = label;
            FilmId = filmId;
        }
    }
}
