using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User.ObjectValue
{
    public class Role : Enumeration<Role>
    {

        public static readonly Role ADMIN = new(0, "ADMIN");
        public static readonly Role USER = new(1, "USER");

        public Role(int id, string name) : base(id, name)
        {
        }
    }
}
