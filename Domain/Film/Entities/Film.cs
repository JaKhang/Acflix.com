using Domain.Base.ValueObjects;
using Domain.Film.ObjectValues;
using Domain.Base;

namespace Domain.Film.Entities
{
    public abstract class Film : AggregateRoot
    {
        public string Name { get; protected set; }
        public string? Description { get; protected set; }
        public string OriginalName { get; protected set; }
        public string Language { get; protected set; }
        public string OriginalLanguage { get; protected set; }
        public int? AgeRestriction { get; protected set; }
        public string Country { get; protected set; }
        public int Popularity { get; protected set; }
        public Date ReleaseDate { get; protected set; }
        public Quality Quality { get; protected set; }
        public FilmStatus Status { get; protected set; }
        public Id DirectorId { get; protected set; }
        public Id PosterId { get; protected set; }
        public Id? CoverId { get; protected set; }
        public int Duration { get; protected set; }

        private readonly List<Genre> _genres  ;
        private readonly List<Id> _relatedFilmIds  ;
        private readonly List<Comment> _comments = [];
        private readonly List<Vote> _votes = [];
        private readonly List<Id> _actorIds;

        //getter
        public IReadOnlyList<Id> ActorIds => _actorIds;
        public IReadOnlyList<Vote> Votes => _votes;
        public IReadOnlyList<Comment> Comments => _comments;
        public IReadOnlyList<Id> RelatedFilmIds => _relatedFilmIds;
        public IReadOnlyList<Genre> Genres => _genres;


        public Film() : base(new())
        {

        }

        protected Film(Id id, List<Genre> genres, List<Id> relatedFilmIds, List<Id> actorIds, string name, string? description, string originalName, string language, string originalLanguage, int? ageRestriction, string country, int popularity, Date releaseDate, Quality quality, FilmStatus status, Id directorId, Id posterId, int duration, Id coverId) : base(id)
        {
            _genres = genres;
            _relatedFilmIds = relatedFilmIds;
            _actorIds = actorIds;
            Name = name;
            Description = description;
            OriginalName = originalName;
            Language = language;
            OriginalLanguage = originalLanguage;
            AgeRestriction = ageRestriction;
            Country = country;
            Popularity = popularity;
            ReleaseDate = releaseDate;
            Quality = quality;
            Status = status;
            DirectorId = directorId;
            PosterId = posterId;
            Duration = duration;
            CoverId = coverId;
        }

        public void AddComment(string content, Guid userId)
        {
            var comment = new Comment(content, new Id(userId), this.Id);
            _comments.Add(comment);
        }

        public void RemoveComment(Comment commnent)
        {
            ArgumentNullException.ThrowIfNull(commnent);
            _comments.Remove(commnent);
        }

        public void Rate(Vote rating)
        {
            ArgumentNullException.ThrowIfNull(rating);
            _votes.Add(rating);
        }


        public void AddRelatedFilm(IEnumerable<Id> select)
        {
            _relatedFilmIds.AddRange((select));
        }
    }
}
