using Domain.Base.ValueObjects;
using Domain.Base;

namespace Domain.Film.Entities
{
    public class Comment : Entity
    {
        public string Content { get; set; }
        public ID UserId { get; set; }

        public Comment() : base(new())
        {
        }
    }
}
