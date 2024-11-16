using Domain.Base.ValueObjects;
using Domain.Base;

namespace Domain.Film.Entities
{
    public class Comment : Entity
    {
        public string Content { get; private set; }
        public Id UserId { get; private set; }
        public Id FilmId { get; private set; }
        public Comment() : base(new())
        {
        }

        public Comment(string content, Id userId, Id filmId) : base(new Id())
        {
            Content = content;
            UserId = userId;
            FilmId = filmId;
        }
    }
}
