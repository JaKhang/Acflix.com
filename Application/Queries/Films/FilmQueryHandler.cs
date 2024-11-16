using Application.Exceptions;
using Application.Mappers;
using Application.Models.Base;
using Application.Models.Episode;
using Application.Models.Film;
using Domain.Base.ValueObjects;
using Domain.Film.Entities;
using Infrastructure.Media;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Minio;

namespace Application.Queries.Films;

public class FilmQueryHandler(DatabaseContext databaseContext, HLSProperties hlsProperties) :
    IRequestHandler<NewReleaseFIlmQuery, Page<FilmResponse>>,
    IRequestHandler<RelatedFilmsQuery, IEnumerable<FilmResponse>>,
    IRequestHandler<GetStreamLinkQuery, string>,
    IRequestHandler<FindFilmHasNewEpisodeQuery, Page<FilmResponse>>,
    IRequestHandler<FindFilmByIdQuery, FilmResponse>,
    IRequestHandler<FilmSearchQuery,  Page<FilmResponse>>,
        IRequestHandler<FindEpisodeByFilmQuery,  IEnumerable<EpisodeResponse>>


{
    public async Task<Page<FilmResponse>> Handle(NewReleaseFIlmQuery request, CancellationToken cancellationToken)
    {
        var query = from film in databaseContext.Films.Include(f => f.ActorIds)
            orderby film.ReleaseDate.Value descending
            select new
            {
                Film = film,
                Actors = new List<SimpleObjectResponse>(),
                Director = (from director in databaseContext.Directors
                    where film.DirectorId.Equals(director.Id)
                    select director.Name).First(),
                Poster = (from poster in databaseContext.Images where poster.Id.Equals(film.PosterId) select poster)
                    .Include(i => i.Variants).First(),
                Cover = (from poster in databaseContext.Images where poster.Id.Equals(film.CoverId) select poster)
                    .Include(i => i.Variants).First()
            };

        var res = await query
            .Take(request.Limit)
            .Skip(request.Offset)
            .ToListAsync(cancellationToken: cancellationToken);

        var films = res.Select(f => FilmMapper.Map(
            film: f.Film,
            actors: f.Actors,
            director: f.Director,
            poster: ImageMapper.Map(f.Poster),
            cover: ImageMapper.Map(f.Cover)
        )).ToList();
        var count = await query.CountAsync(cancellationToken: cancellationToken);

        return new Page<FilmResponse>(
            count,
            films,
            request.Offset == 0,
            request.Offset + request.Limit < count,
            request.Limit,
            request.Offset
        );
    }

    public async Task<IEnumerable<FilmResponse>> Handle(RelatedFilmsQuery request, CancellationToken cancellationToken)
    {
        var ids = await databaseContext.Films
            .Include(f => f.RelatedFilmIds)
            .Where(f => f.Id.Equals(new Id(request.FilmId)))
            .Select(f => f.RelatedFilmIds)
            .AsNoTracking()
            .FirstAsync(cancellationToken: cancellationToken);
        var query = from film in databaseContext.Films
                .Include(f => f.ActorIds)
                .Include(f => f.RelatedFilmIds)
            orderby film.ReleaseDate.Value descending
            where ids.Contains(film.Id)
            select new
            {
                Film = film,
                Actors = new List<SimpleObjectResponse>(),
                Director = (from director in databaseContext.Directors
                    where film.DirectorId.Equals(director.Id)
                    select director.Name).First(),
                Poster = (from poster in databaseContext.Images where poster.Id.Equals(film.PosterId) select poster)
                    .Include(i => i.Variants).First(),
                Cover = (from poster in databaseContext.Images where poster.Id.Equals(film.CoverId) select poster)
                    .Include(i => i.Variants).First()
            };

        var res = await query.ToListAsync(cancellationToken);
        return res.Select(f => FilmMapper.Map(
            film: f.Film,
            actors: f.Actors,
            director: f.Director,
            poster: ImageMapper.Map(f.Poster),
            cover: ImageMapper.Map(f.Cover)
        ));
    }

    public async Task<string> Handle(GetStreamLinkQuery request, CancellationToken cancellationToken)
    {
        var film = await databaseContext.Movies.Include(f => f.Video).FirstOrDefaultAsync(f => f.Id == new Id(request.FilmId), cancellationToken: cancellationToken);
        if (film is null)             throw new ResourceNotFoundException("Movie Not found");

        if (film.Video is null)
            throw new ResourceNotFoundException("Movie' src Not found");

        return string.Format(hlsProperties.BaseUrl, film.Video.Reference);
    }

    public async Task<Page<FilmResponse>> Handle(FindFilmHasNewEpisodeQuery request, CancellationToken cancellationToken)
    {
        var query = from film in databaseContext.Series.Include(f => f.ActorIds)
            orderby film.LastReleasedEpisodeAt descending
            select new
            {
                Film = film,
                Actors = new List<SimpleObjectResponse>(),
                Director = (from director in databaseContext.Directors
                    where film.DirectorId.Equals(director.Id)
                    select director.Name).First(),
                Poster = (from poster in databaseContext.Images where poster.Id.Equals(film.PosterId) select poster)
                    .Include(i => i.Variants).First(),
                Cover = (from poster in databaseContext.Images where poster.Id.Equals(film.CoverId) select poster)
                    .Include(i => i.Variants).First()
            };

        var res = await query
            .Take(request.Limit)
            .Skip(request.Offset)
            .ToListAsync(cancellationToken: cancellationToken);

        var films = res.Select(f => FilmMapper.Map(
            film: f.Film,
            actors: f.Actors,
            director: f.Director,
            poster: ImageMapper.Map(f.Poster),
            cover: ImageMapper.Map(f.Cover)
        )).ToList();
        var count = await query.CountAsync(cancellationToken: cancellationToken);

        return new Page<FilmResponse>(
            count,
            films,
            request.Offset == 0,
            request.Offset + request.Limit < count,
            request.Limit,
            request.Offset
        );
    }

    public async Task<FilmResponse> Handle(FindFilmByIdQuery request, CancellationToken cancellationToken)
    {
        var query = from film in databaseContext.Films.Include(f => f.ActorIds)
            where  film.Id == new Id(request.Id)
            select new
            {
                Film = film,
                Actors = new List<SimpleObjectResponse>(),
                Director = (from director in databaseContext.Directors
                    where film.DirectorId.Equals(director.Id)
                    select director.Name).First(),
                Poster = (from poster in databaseContext.Images where poster.Id.Equals(film.PosterId) select poster)
                    .Include(i => i.Variants).First(),
                Cover = (from poster in databaseContext.Images where poster.Id.Equals(film.CoverId) select poster)
                    .Include(i => i.Variants).First()
            };
        var f = await query.FirstOrDefaultAsync(cancellationToken);
        return FilmMapper.Map(
            film: f.Film,
            actors: f.Actors,
            director: f.Director,
            poster: ImageMapper.Map(f.Poster),
            cover: ImageMapper.Map(f.Cover));
    }

    public async Task<Page<FilmResponse>> Handle(FilmSearchQuery request, CancellationToken cancellationToken)
    {
        var query = from film in databaseContext.Films.Include(f => f.ActorIds)
            where ( EF.Functions.Like(film.Name, $"%{request.Keyword}%") ||  EF.Functions.Like(film.OriginalLanguage, $"%{request.Keyword}%"))
            select new
            {
                Film = film,
                Actors = new List<SimpleObjectResponse>(),
                Director = (from director in databaseContext.Directors
                    where film.DirectorId.Equals(director.Id)
                    select director.Name).First(),
                Poster = (from poster in databaseContext.Images where poster.Id.Equals(film.PosterId) select poster)
                    .Include(i => i.Variants).First(),
                Cover = (from poster in databaseContext.Images where poster.Id.Equals(film.CoverId) select poster)
                    .Include(i => i.Variants).First()
            };

        var res = await query
            .Take(request.Limit)
            .Skip(request.Offset)
            .ToListAsync(cancellationToken: cancellationToken);

        var films = res.Select(f => FilmMapper.Map(
            film: f.Film,
            actors: f.Actors,
            director: f.Director,
            poster: ImageMapper.Map(f.Poster),
            cover: ImageMapper.Map(f.Cover)
        )).ToList();
        var count = await query.CountAsync(cancellationToken: cancellationToken);

        return new Page<FilmResponse>(
            count,
            films,
            request.Offset == 0,
            request.Offset + request.Limit < count,
            request.Limit,
            request.Offset
        );
    }

    public async Task<IEnumerable<EpisodeResponse>> Handle(FindEpisodeByFilmQuery request, CancellationToken cancellationToken)
    {
        var film = await databaseContext.Series.Include(f => f.Episodes).FirstOrDefaultAsync(f => f.Id == new Id(request.FilmId),cancellationToken);
        if (film is null)
        {
            throw new ResourceNotFoundException("Not found series");
        }

        return film.Episodes.Select(e => new EpisodeResponse(e.Id.Value, e.Index, e.Label, e.Name, Guid.Empty)).OrderBy(e => e.Index);
    }
}