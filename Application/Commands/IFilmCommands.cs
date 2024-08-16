using Application.Models.Comment;
using Application.Models.Film;
using Application.Models.Vote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.Commands
{
    public interface IFilmCommands
    {
        /// <summary>
        /// User tạo comments map request thành Domain.Comment thêm vào film save film lại
        /// </summary>
        /// <param name="filmId"></param>
        /// <param name="userId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task Comment(Guid filmId, Guid userId, CommentRequest request);

        Task Vote(Guid filmId, Guid userId, VoteRequest request);

        /// <summary>
        /// set deleted = true
        /// </summary>
        /// <param name="filmId"></param>
        /// <returns></returns>
        Task Hide(Guid filmId);

        Task Delete(Guid filmId);

        Task<Guid> Create(FilmRequest request);

        Task AddMoveSource(Guid filmId, IFormFile file);
    }
}
