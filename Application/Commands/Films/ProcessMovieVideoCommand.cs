using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Commands.Films;

public record ProcessMovieVideoCommand(IFormFile Source, Guid MovieId) : IRequest;