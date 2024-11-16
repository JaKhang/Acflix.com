using Application.Models.Director;
using Domain.Director;
using MediatR;

namespace Application.Commands.Directors;

public class DirectorCommandHandler(IDirectorRepository repository) : IRequestHandler<CreateDirectorCommand, Guid>
{

    public async Task<Guid> Handle(CreateDirectorCommand request, CancellationToken cancellationToken)
    {
        var d = new Director(request.Name);
        d = await repository.CreateAsync(d);
        return d.Id.Value;
    }
}