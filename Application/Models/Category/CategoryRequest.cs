using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Category
{
    public record CategoryRequest(IEnumerable<Guid> FilmsIds, string Name, Guid CoverId, int Popularity);
}
