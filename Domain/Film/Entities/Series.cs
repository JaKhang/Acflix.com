using Domain.Base.ValueObjects;
using Domain.Exceptions;
using Domain.Film.ObjectValues;

namespace Domain.Film.Entities
{
    public class Series : Film
    {
        private readonly List<Episode> _episodes = [];
        public IReadOnlyList<Episode> Episodes => _episodes;
        public int TotalEpisode { get; protected set; }
        public int LastEpisode { get; protected set; }
        public DateTime? LastReleasedEpisodeAt { get; protected set; }

        public Series(List<Genre> genres, List<Id> relatedFilmIds, List<Id> actorIds, string name, string? description, string originalName, string language, string originalLanguage, int? ageRestriction, string country, int popularity, Date releaseDate, Quality quality, FilmStatus status, Id directorId, Id posterId, int totalEpisode, int lastEpisode, int duration,  Id coverId) : base(new Id(), genres, relatedFilmIds, actorIds, name, description, originalName, language, originalLanguage, ageRestriction, country, popularity, releaseDate, quality, status, directorId, posterId, duration, coverId)
        {
            TotalEpisode = totalEpisode;
            LastEpisode = lastEpisode;
        }

        public Series()
        {
        }

        public Episode AddEpisode(string name, string label)
        {
            int index = _episodes.Count + 1;
            Episode episode = new(name, index, label, Id);
            LastEpisode = index;
            LastReleasedEpisodeAt = DateTime.Now;
            _episodes.Add(episode);
            return episode;
        }


        public void SetVideo(int duration, string reference, int quality, bool process)
        {
            throw new NotImplementedException();
        }
    }
}
