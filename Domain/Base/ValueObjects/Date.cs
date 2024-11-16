namespace Domain.Base.ValueObjects
{
    public record Date(Precision Precision, DateTime Value)
    {
        public override string ToString()
        {
            if (Precision.YEAR == Precision)  return Value.ToString("yyyy");
            return Value.ToString(Precision == Precision.MONTH ? "MM/yyyy" : "dd/MM/yyyy");
        }
    }

    public class Precision : Enumeration<Precision>
    {
        public static readonly Precision DAY = new Precision(0, "day");
        public static readonly Precision MONTH = new Precision(2, "month");
        public static readonly Precision YEAR = new Precision(3, "year");

        private Precision(int id, string name) : base(id, name)
        {
        }


    }
}
