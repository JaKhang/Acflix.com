namespace Domain.Base.ValueObjects
{
    public record ID(Guid id)
    {
        public ID() : this(Guid.NewGuid())
        {
        }
    }
}
