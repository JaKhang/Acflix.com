using System.Reflection;

namespace Domain.Base
{
    public abstract class Enumeration : IComparable<Enumeration>
    {
        public string Name { get; private set; }
        public int Id { get; private set; }


        protected Enumeration(int id, string name)
        {
            Name = name;
            Id = id;
        }

        public static IEnumerable<T> GetAll<T>() where T : Enumeration => typeof(T).GetFields(
            BindingFlags.Public |
            BindingFlags.Static |
            BindingFlags.DeclaredOnly
            ).Select(x => x.GetValue(null)).Cast<T>();

        public int CompareTo(Enumeration obj)
        {
            return Id.CompareTo(obj.Id);
        }


        public override string ToString()
        {
            return Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Enumeration that) return false;
            bool type = GetType().Equals(obj.GetType());
            bool id = Id.Equals(that.Id);
            return type && id;
        }




    }
}
