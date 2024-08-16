using Domain.Base.ValueObjects;
using Domain.Film.ObjectValues;

namespace Domain.Film.Entities
{
    public class Movie : Film
    {
        public Video Video {  get; protected set; }
        public ID VideoId {  get; protected set; }

    }
}
