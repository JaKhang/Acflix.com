using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User.ObjectValue
{
    public class UserProvider : Enumeration<UserProvider>
    {
        public static readonly UserProvider GOOGLE = new(1, "google");
        public static readonly UserProvider FACEBOOK = new(2, "facebook");
        public static readonly UserProvider ACFLIX = new(0, "acflix");
        public UserProvider(int id, string name) : base(id, name)
        {
        }
    }
}
