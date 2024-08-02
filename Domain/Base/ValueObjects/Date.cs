namespace Domain.Base.ValueObjects
{
    public record Date(Rrecision Rrecision, DateTime Value)
    {
    }

    public enum Rrecision
    {
        Year,
        Month,
        day,
    }
}
