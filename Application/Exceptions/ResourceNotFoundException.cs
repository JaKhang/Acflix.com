namespace Application.Exceptions;

public class ResourceNotFoundException : SystemException
{
    public ResourceNotFoundException(string? message) : base(message)
    {
    }
}