using Application.Exceptions;
using Application.Models.Comment;
using Application.Models.Film;
using Application.Models.Vote;
using Domain.Base.ValueObjects;
using Domain.Film.Entities;
using Domain.Film.Repositories;

namespace Application.Commands;

public class FilmCommand(IFilmRepository filmRepository) : IFilmCommands {


    public async Task Comment(Guid filmId, Guid userId, CommentRequest request)
    {
        var film = await filmRepository.FindByIdAsync(new ID(filmId));
        if (film is null) throw new ResourceNotFoundException("Film not found with id " + filmId);
        var comment = new Comment(request.Content, new ID(userId), new ID(filmId));
        film.AddComment(comment);
        film = await filmRepository.SaveAsync(film);
    }

    public Task Vote(Guid filmId, Guid userId, VoteRequest request)
    {
        throw new NotImplementedException();
    }

    public Task Hide(Guid filmId)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid filmId)
    {
        throw new NotImplementedException();
    }

    public Task<Guid> Create(FilmRequest request)
    {
        throw new NotImplementedException();
    }
}