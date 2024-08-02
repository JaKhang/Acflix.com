namespace 
    Domain.Film.ObjectValues
{
    public class Genre : Enumeration
    {
        public static readonly Genre ACTION = new(0, "action");
        public static readonly Genre ADVENTURE = new(1, "adventure");
        public static readonly Genre ANIMATION = new(2, "animation");
        public static readonly Genre COMEDY = new(3, "comedy");
        public static readonly Genre CRIME = new(4, "crime");
        public static readonly Genre WAR = new(5, "war");
        public static readonly Genre DOCUMENTARY = new(6, "documentary");
        public static readonly Genre DRAMA = new(7, "drama");
        public static readonly Genre FAMILY = new(8, "family");
        public static readonly Genre FANTACY = new(9, "fantacy");
        public static readonly Genre HISTORY = new(10, "history");
        public static readonly Genre HORROR = new(11, "horror");
        public static readonly Genre MUSICAL = new(12, "musical");
        public static readonly Genre MYSTERY = new(13, "mystery");
        public static readonly Genre ROMANCE = new(14, "romance");
        public static readonly Genre SCIFI = new(15, "scifi");
        public static readonly Genre SPORT = new(16, "sport");
        public static readonly Genre THRILLER = new(17, "thriller");
        public static readonly Genre BIOGRAPHY = new(18, "biography");
        public static readonly Genre WESTERN = new(19, "western");






        private Genre(int id, string name) : base(id, name)
        {

        }
    }
}
