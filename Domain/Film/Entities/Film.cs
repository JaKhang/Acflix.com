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
        public ID DirectorId { get; protected set; }
        public ID PosterId { get; protected set; }

        private readonly List<Genre> _genres  = [];
        private readonly List<ID> _relatedFilmIds  = [];
        private readonly List<Comment> _comments = [];
        private readonly List<Vote> _votes = [];
        private readonly List<ID> _actorIds = [];

        //getter
        public IReadOnlyList<ID> ActorIds => _actorIds;
        public IReadOnlyList<Vote> Votes => _votes;
        public IReadOnlyList<Comment> Comments => _comments;
        public IReadOnlyList<ID> RelatedFilmIds => _relatedFilmIds;
        public IReadOnlyList<Genre> Genres => _genres;


        public Film() : base(new())
        {

        }

        public void AddComment(Comment commnent)
        {
            ArgumentNullException.ThrowIfNull(commnent);
            _comments.Add(commnent);
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


    }
}
