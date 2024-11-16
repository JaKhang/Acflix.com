
namespace Domain.Base.ValueObjects
{
    public record Id(Guid Value)
    {
        public Id(): this(Guid.NewGuid())
        {
        }
    }
}
