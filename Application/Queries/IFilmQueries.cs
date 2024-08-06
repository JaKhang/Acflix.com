using Application.Models.Base;
using Application.Models.Comment;
using Application.Models.Episode;
using Application.Models.Film;
using Application.Models.Vote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public interface IFilmQueries
    {
        /// <summary>
        /// Find film set by a ids set
        /// </summary>
        /// <param name="ids">Ids set</param>
        /// <returns>Set of films <see cref="FilmResponse"/></returns>
        Task<IEnumerable<FilmResponse>> FindByIds(IEnumerable<Guid> ids);

        /// <summary>
        /// Find a film by Id
        /// </summary>
        /// <param name="id">id of film</param>
        /// <returns>Film <see cref="FilmResponse"/></returns>
        /// <exception cref="ResourceNotFoundException"></exception>
        Task<FilmResponse> FindById(Guid id);

        /// <summary>
        /// Find user saved films
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="pageRequest">Page request <see cref="PageRequest"/></param>
        /// <returns>Page of film </returns>
        Task<Page<FilmResponse>> FindUserSaved(Guid userId, PageRequest pageRequest);

        /// <summary>
        /// Check user saved
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="filmIds">List of film's id</param>
        /// <returns>List of bool</returns>
        Task<IEnumerable<bool>> CheckSaved(Guid userId, IEnumerable<Guid> filmIds);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageRequest"></param>
        /// <returns></returns>
        Task<Page<FilmResponse>> FindNewRelease(PageRequest pageRequest);

        /// <summary>
        /// Find Related Films by Film's ID
        /// </summary>
        /// <param name="filmId"></param>
        /// <returns></returns>
        Task<IEnumerable<FilmResponse>> FindRelatedFilms(Guid filmId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageRequest"></param>
        /// <returns></returns>
        Task<Page<FilmResponse>> FindNewEpisode(PageRequest pageRequest);





    }
}
