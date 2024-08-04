
namespace Domain.Base.ValueObjects
{
    public record ID(Guid Value)
    {
        public ID(): this(Guid.NewGuid())
        {
        }
    }
}
