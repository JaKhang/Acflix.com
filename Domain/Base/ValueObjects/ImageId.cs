namespace Domain.Base.ValueObjects
{
    public record ImageId(Guid id)
    {
        protected ImageId() : this(Guid.NewGuid())
        {
        }
    }
}
