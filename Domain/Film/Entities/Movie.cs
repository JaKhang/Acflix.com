using Domain.Base.ValueObjects;
using Domain.Film.ObjectValues;

namespace Domain.Film.Entities
{
    public class Movie : Film
    {
        public Source? Source {  get; set; }

    }
}
