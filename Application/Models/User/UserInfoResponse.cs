using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.User
{
    public record UserInfoResponse(string Name, string Email, IEnumerable<string> Roles, bool Verified)
    {
    }
}
