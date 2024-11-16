using Domain.Base.ValueObjects;
using Domain.Film.ObjectValues;

namespace Domain.Film.Entities
{
    public class Movie : Film
    {
        public Movie(int duration)
        {
            Duration = duration;
        }

        public Movie(List<Genre> genres, List<Id> relatedFilmIds, List<Id> actorIds, string name, string? description, string originalName, string language, string originalLanguage, int? ageRestriction, string country, int popularity, Date releaseDate, Quality quality, FilmStatus status, Id directorId, Id posterId, int duration,  Id coverId) : base(new(), genres, relatedFilmIds, actorIds, name, description, originalName, language, originalLanguage, ageRestriction, country, popularity, releaseDate, quality, status, directorId, posterId, duration, coverId)
        {
        }

        public Video Video {  get; protected set; }
        public Id VideoId {  get; protected set; }


        public void SetVideo(Id requestVideoId)
        {
            this.VideoId = requestVideoId;
        }

        public void SetVideo(string reference, int duration, int quality, bool process)
        {
            this.Video = new Video(duration, quality, process, reference);
            this.VideoId = this.Video.Id;
        }
    }
}
