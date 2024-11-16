using Application.Models.Director;

namespace Application.Commands;

public interface IDirectorCommands
{
    Task<Guid> Create(DirectorRequest directorRequest);
}