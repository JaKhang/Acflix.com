using Application.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public interface ICategoryCommands
    {
        Task<Guid> Create(CategoryRequest request);
        Task AddFilm(Guid id, IEnumerable<Guid> filmIds);
        Task Update(Guid id, CategoryRequest request);
        Task Hide(Guid id);
        Task Delete(Guid id);

    }
}
