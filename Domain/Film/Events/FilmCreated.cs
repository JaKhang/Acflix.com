using Domain.Event;

namespace Domain.Film.Events;

public record FilmCreated(Entities.Film Film) : DomainEvent(Film.Id.Value)
{
    
}