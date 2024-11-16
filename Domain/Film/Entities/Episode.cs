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
        public Id FilmId { get; protected set; }
        public Id VideoId {  get; protected set; }

        public Episode() : base(new())
        {

        }

        public Episode(string name, int index, string label, Id filmId) : base(new())
        {
            Name = name;
            Index = index;
            Label = label;
            FilmId = filmId;
        }

        public void AddVideo(Video video)
        {
            Video = video;
            VideoId = video.Id;
        }
    }
}
