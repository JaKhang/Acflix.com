using Domain.Base;

namespace 
    
    Domain.Film.ObjectValues
{
    public class FilmStatus : Enumeration<FilmStatus>
    {
        public static readonly FilmStatus COMMING_SOON = new(0, "comming-soon");
        public static readonly FilmStatus RELEASED = new(1, "released");
        
        public static readonly FilmStatus COMPLETED = new(2, "completed");
        public static readonly FilmStatus PENDING = new(3, "pending");
        public static readonly FilmStatus NEW = new(4, "released");

        public FilmStatus(int id, string name) : base(id, name)
        {
        }
    }
}
