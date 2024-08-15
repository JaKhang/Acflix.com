using Domain.Base.ValueObjects;
using Domain.Base;

namespace Domain.Caterory
{
    public class Category : AggregateRoot
    {
        public ID CoverId { get; set; }
        public string Name { get; set; }
        public List<ID> FilmIds { get; set; } = [];

        private readonly List<Film.Entities.Film> _films = [];
        
        public Category() : base(new())
        {

        }

        public Category(ID id, ID coverId, string name) : base(id)
        {
            Name = name;
            CoverId = coverId;
            FilmIds = new List<ID>();
        }

        public void AddFilm(Film.Entities.Film film) 
        {
            ArgumentNullException.ThrowIfNull(film);
            _films.Add(film);
        }

        public void isHide()
        {
            throw new NotImplementedException();
        }
        
        public void Update(string name)
        {
            Name = name;
        }
    }
}
