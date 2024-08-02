using Domain.Base.ValueObjects;
using Domain.Film.ObjectValues;
using Domain.Base;
using Domain.Film.Entities;

namespace Domain.Film.Entities
{
    public abstract class Film : AggregateRoot
    {
        public string Name { get; }
        public string Description { get; }
        public string OriginalName { get; }
        public Date PublishDate { get; }
        public Director Director { get; }
        public readonly List<Actor> actors = [];
        public readonly List<Genre> categories = [];
        public int Popularity { get; }
        public readonly List<ID> relation = [];
        public int AgeRestriction { get; }
        public FilmStatus Status { get; }
        public ImageId PosterId;
        public string CountryCode { get; }
        public readonly List<Comment> commnents = [];
        public readonly List<Rating> ratings = [];
        public Film() : base(new())
        {

        }

        public void AddComment(Comment commnent)
        {
            ArgumentNullException.ThrowIfNull(commnent);
            commnents.Add(commnent);
        }

        public void RemoveComment(Comment commnent)
        {
            ArgumentNullException.ThrowIfNull(commnent);
            commnents.Remove(commnent);
        }

        public void Rate(Rating rating)
        {
            ArgumentNullException.ThrowIfNull(rating);
            ratings.Add(rating);
        }




    }
}
