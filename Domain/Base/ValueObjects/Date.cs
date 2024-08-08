namespace Domain.Base.ValueObjects
{
    public record Date(Precision precision, DateTime Value)
    {
    }

    public enum Precision
    {
        Year,
        Month,
        Day,
    }
}
