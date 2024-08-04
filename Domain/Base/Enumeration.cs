using Domain.Exceptions;
using System.Reflection;

namespace Domain.Base
{
    public abstract class Enumeration<Enum> : IComparable<Enumeration<Enum>> where Enum : Enumeration<Enum>
    {
        public string Name { get; private set; }
        public int Id { get; private set; }


        protected Enumeration(int id, string name)
        {
            Name = name;
            Id = id;
        }

        public static IEnumerable<T> GetAll<T>() where T : Enumeration<Enum> => typeof(T).GetFields(
            BindingFlags.Public |
            BindingFlags.Static |
            BindingFlags.DeclaredOnly
            ).Select(x => x.GetValue(null)).Cast<T>();

        public int CompareTo(Enumeration<Enum> obj)
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
            if (obj is not Enumeration<Enum> that) return false;
            bool type = GetType().Equals(obj.GetType());
            bool id = Id.Equals(that.Id);
            return type && id;
        }
        public static Enum FromId(int value)
        {
            var data = GetAll<Enum>().FirstOrDefault(e => e.Id == value);
            if (data is not null) return data;
            throw new EnumMappingException("Id " + value + " is not match any Enum");
        }

        public static Enum FromName(string name)
        {
            var data = GetAll<Enum>().FirstOrDefault(e => e.Name == name);
            if (data is not null) return data;
            throw new EnumMappingException("Name" + name + " is not match any Enum");
        }






    }
}
