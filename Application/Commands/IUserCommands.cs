using Application.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public interface IUserCommands
    {
        Task UpdateProfile();

        Task UpdateAvatar(Guid userId, string base64);
    }
}
