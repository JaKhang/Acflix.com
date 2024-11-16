using Application.Mappers;
using Application.Models.Base;
using Application.Models.Category;
using Application.Models.Film;
using Domain.Base.ValueObjects;
using Domain.Category;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Categories;

public class CategoryQueryHandler(DatabaseContext databaseContext)
    : IRequestHandler<FindCategoriesDetailsQuery, IEnumerable<CategoryDetailsResponse>>,
        IRequestHandler<FindAllCategoriesQuery, Page<CategoryResponse>>,
        IRequestHandler<FindFilmsByCategoryIdQuery, Page<FilmResponse>>

{
    public async Task<IEnumerable<CategoryDetailsResponse>> Handle(FindCategoriesDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var categories = await databaseContext.Categories.Include(c => c.FilmIds).OrderByDescending(c => c.Popularity)
            .Take(request.Limit)
            .ToListAsync(cancellationToken);

        var res = new List<CategoryDetailsResponse>();

        foreach (var c in categories)
        {
            var queryable = from film in databaseContext.Films.Include(f => f.ActorIds)
                orderby film.ReleaseDate.Value descending
                where c.FilmIds.Contains(film.Id)
                select new
                {
                    Film = film,
                    Actors = new List<SimpleObjectResponse>(),
                    Director = (from director in databaseContext.Directors
                        where film.DirectorId.Equals(director.Id)
                        select director.Name).First(),
                    Poster = (from poster in databaseContext.Images
                            where poster.Id.Equals(film.PosterId)
                            select poster)
                        .Include(i => i.Variants).First(),
                    Cover = (from poster in databaseContext.Images
                            where poster.Id.Equals(film.CoverId)
                            select poster)
                        .Include(i => i.Variants).First()
                };
            var rs = await queryable.Skip(request.FilmOffset).Take(request.FilmLimit).ToListAsync(cancellationToken);

            var v1 = new CategoryDetailsResponse(
                c.Id.Value,
                c.Name,
                rs.Select(f => FilmMapper.Map(
                        film: f.Film,
                        actors: f.Actors,
                        director: f.Director,
                        poster: ImageMapper.Map(f.Poster),
                        cover: ImageMapper.Map(f.Cover)
                    )
                )
            );
            res.Add(v1);
        }

        return res;
    }

    public async Task<Page<CategoryResponse>> Handle(FindAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var query = from category in databaseContext.Categories
            select new CategoryResponse(
                category.Id.Value,
                category.Name,
                ImageMapper.Map((from poster in databaseContext.Images
                        where poster.Id.Equals(category.CoverId)
                        select poster)
                    .Include(i => i.Variants).First()).Variants
            );

        var count = await query.Take(request.Limit).Skip(request.Offset).CountAsync(cancellationToken);
        var items = await query.ToListAsync(cancellationToken);
        return new Page<CategoryResponse>(
            count,
            items,
            request.Offset == 0,
            request.Offset + request.Limit > count,
            request.Limit,
            request.Offset
        );
    }

    public async Task<Page<FilmResponse>> Handle(FindFilmsByCategoryIdQuery request, CancellationToken cancellationToken)
    {
        var c = await databaseContext.Categories.FindAsync(new object?[] { new Id(request.Id) }, cancellationToken: cancellationToken);
        var queryable = from film in databaseContext.Films.Include(f => f.ActorIds)
            orderby film.ReleaseDate.Value descending
            where c.FilmIds.Contains(film.Id)
            select new
            {
                Film = film,
                Actors = new List<SimpleObjectResponse>(),
                Director = (from director in databaseContext.Directors
                    where film.DirectorId.Equals(director.Id)
                    select director.Name).First(),
                Poster = (from poster in databaseContext.Images
                        where poster.Id.Equals(film.PosterId)
                        select poster)
                    .Include(i => i.Variants).First(),
                Cover = (from poster in databaseContext.Images
                        where poster.Id.Equals(film.CoverId)
                        select poster)
                    .Include(i => i.Variants).First()
            };
        var rs = await queryable.Skip(request.Offset).Take(request.Limit).ToListAsync(cancellationToken);

        var count = await queryable.CountAsync(cancellationToken);
        var items = rs.Select(f => FilmMapper.Map(
            film: f.Film,
            actors: f.Actors,
            director: f.Director,
            poster: ImageMapper.Map(f.Poster),
            cover: ImageMapper.Map(f.Cover)
        ));
        return new Page<FilmResponse>(
            count,
            items,
            request.Offset == 0,
            request.Offset + request.Limit > count,
            request.Limit,
            request.Offset
        );
    }
}