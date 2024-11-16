using Domain.Exceptions;
using System.Reflection;

namespace Domain.Base
{
    public abstract class Enumeration<TEnum> : IComparable<Enumeration<TEnum>> where TEnum : Enumeration<TEnum>
    {
        public string Name { get; private set; }
        public int Id { get; private set; }


        protected Enumeration(int id, string name)
        {
            Name = name;
            Id = id;
        }

        public static IEnumerable<T> GetAll<T>() where T : Enumeration<TEnum> => typeof(T).GetFields(
            BindingFlags.Public |
            BindingFlags.Static |
            BindingFlags.DeclaredOnly
            ).Select(x => x.GetValue(null)).Cast<T>();

        public int CompareTo(Enumeration<TEnum> obj)
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
            if (obj is not Enumeration<TEnum> that) return false;
            bool type = GetType().Equals(obj.GetType());
            bool id = Id.Equals(that.Id);
            return type && id;
        }
        public static TEnum FromId(int value)
        {
            var data = GetAll<TEnum>().FirstOrDefault(e => e.Id == value);
            if (data is not null) return data;
            throw new EnumMappingException("Id " + value + " is not match any Enum");
        }

        public static TEnum FromName(string name)
        {
            var data = GetAll<TEnum>().FirstOrDefault(e => e.Name == name);
            if (data is not null) return data;
            throw new EnumMappingException("Name" + name + " is not match any Enum");
        }






    }
}
