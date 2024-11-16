using MediatR;
using Microsoft.AspNetCore.Http;
using Minio.DataModel.ILM;

namespace Application.Commands.Films;

public record AddMovieVideoCommand(Guid FilmId, string Reference, int Duration, int Quality, bool Process) : IRequest;