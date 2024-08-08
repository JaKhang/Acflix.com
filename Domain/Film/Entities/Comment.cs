using Domain.Base.ValueObjects;
using Domain.Base;

namespace Domain.Film.Entities
{
    public class Comment : Entity
    {
        public string Content { get; private set; }
        public ID UserId { get; private set; }
        public ID FilmId { get; private set; }
        public Comment() : base(new())
        {
        }

        public Comment(string content, ID userId, ID filmId) : base(new ID())
        {
            Content = content;
            UserId = userId;
            FilmId = filmId;
        }
    }
}
