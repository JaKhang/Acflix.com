using Domain.Base.ValueObjects;
using MediatR;

namespace Domain.Event;

public record DomainEvent(Guid Id) : INotification
{

}