using Application.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public interface IUserQueries
    {
        Task<UserInfoResponse> FindUserInfoAsync(Guid userId);

      
    }
}
