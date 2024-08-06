using Application.Models.Base;
using Application.Models.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public interface ICommentQueries
    {

        /// <summary>
        /// Find page of comments by film id
        /// </summary>
        /// <param name="filmId">Id of film</param>
        /// <param name="page">Paging parameter</param>
        /// <returns>A page of comment</returns>
        public Task<Page<CommentResponse>> FindByFilmId(Guid filmId, PageRequest page);

    }
}
