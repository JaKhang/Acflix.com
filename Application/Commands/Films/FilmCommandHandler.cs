using Application.Commands.Images;
using Application.Exceptions;
using Application.Mappers;
using Application.Worker;
using Domain.Base.ValueObjects;
using Domain.Film.Entities;
using Domain.Film.Repositories;
using Infrastructure.Media;
using Infrastructure.Storage.Local;
using MediatR;

namespace Application.Commands.Films;

public class FilmCommandHandler(IFilmRepository filmRepository, IVideoWorker iVideoWorker, ILocalStorage localStorage) :
    IRequestHandler<CreateFilmCommand, Guid>,
    IRequestHandler<CommentCommand>,
    IRequestHandler<VoteCommand>,
    IRequestHandler<HideFilmCommand>,
    IRequestHandler<DeleteFilmCommand>,
    IRequestHandler<AddMovieVideoCommand>,
    IRequestHandler<AddNewEpisodeCommand, Guid>,
    IRequestHandler<ProcessMovieVideoCommand>,
    IRequestHandler<AddRelatedFilmCommand>


{


    public async Task Handle(CommentCommand notification, CancellationToken cancellationToken)
    {
        var film = await filmRepository.FindByIdAsync(new Id(notification.FilmId));
        if (film is null) throw new ResourceNotFoundException("Film not found with id " + notification.FilmId);
        film.AddComment(notification.Content, notification.UserId);
        film = await filmRepository.SaveAsync(film);
    }

    public async Task<Guid> Handle(CreateFilmCommand notification, CancellationToken cancellationToken)
    {
        var film = FilmMapper.Map(notification);
        film = await filmRepository.Create(film);
        return film.Id.Value;
    }

    public async Task Handle(VoteCommand request, CancellationToken cancellationToken)
    {
        var film = await filmRepository.FindByIdAsync(new Id(request.FilmId));
        if (film is null) throw new ResourceNotFoundException("Film not found with id " + request.FilmId);
        var userId = new Id(request.UserId);
        var vote = film.Votes.FirstOrDefault(v => v.UserId == new Id(request.UserId));
        if (vote is null)
        {
            vote = new Vote(request.Vote, userId);
            film.Rate(vote);

        }
        else
        {
            vote.SetScore(request.Vote);
        }
        film = await filmRepository.SaveAsync(film);
    }

    public async Task Handle(HideFilmCommand request, CancellationToken cancellationToken)
    {
        var film = await filmRepository.FindByIdAsync(new Id(request.FilmId));
        if (film is null) throw new ResourceNotFoundException("Film not found with id " + request.FilmId);
        film.Hide();
        film = await filmRepository.SaveAsync(film);
    }

    public async Task Handle(DeleteFilmCommand request, CancellationToken cancellationToken)
    {
        var film = await filmRepository.FindByIdAsync(new Id(request.FilmId));
        if (film is null) throw new ResourceNotFoundException("Film not found with id " + request.FilmId);
        await filmRepository.DeleteAsync(film.Id);
    }

    public async Task Handle(AddMovieVideoCommand request, CancellationToken cancellationToken)
    {
        var film = await filmRepository.FindByIdAsync(new Id(request.FilmId));
        if (film is not Movie movie) throw new ResourceNotFoundException("Film not found with id " + request.FilmId);
        movie.SetVideo(duration: request.Duration, reference: request.Reference, quality: request.Quality, process: request.Process);
        await filmRepository.SaveAsync(film);
    }

    public async Task<Guid> Handle(AddNewEpisodeCommand request, CancellationToken cancellationToken)
    {
        var film = await filmRepository.FindSeriesByIdAsync(new Id(request.SeriesId));
        if (film is not Series series) throw new ResourceNotFoundException("Film not found with id " + request.SeriesId);
        var episode = series.AddEpisode(request.Name, request.Label);
         await filmRepository.SaveAsync(series);
        return episode.Id.Value;
    }

    public async Task Handle(ProcessMovieVideoCommand request, CancellationToken cancellationToken)
    {
        var src = await localStorage.StorageToTmpAsync(request.Source);
            _ = iVideoWorker.DoWork(new Id(request.MovieId), src);


    }

    public async Task Handle(AddRelatedFilmCommand request, CancellationToken cancellationToken)
    {
        var film = await filmRepository.FindByIdAsync(new Id(request.FilmId));
        if (film is null) throw new ResourceNotFoundException("Film not found with id " + request.FilmId);
        film.AddRelatedFilm(request.FilmIds.Select(f => new Id(f)));
        await filmRepository.SaveAsync(film);
    }


}