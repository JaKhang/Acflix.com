using Application.Models.Comment;
using Application.Models.Film;
using Application.Models.Vote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public interface IFilmCommands
    {
        Task Comment(Guid filmId, Guid userId, CommentRequest request);

        Task Vote(Guid filmId, Guid userId, VoteRequest request);

        Task Hide(Guid filmId);

        Task Delete(Guid filmId);

        Task<Guid> Create(FilmRequest request);
    }
}
