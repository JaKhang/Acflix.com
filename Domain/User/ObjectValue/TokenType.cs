using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User.ObjectValue
{
    public class TokenType : Enumeration<TokenType>
    {
        public static readonly TokenType VERIFY = new (0, "verify");
        public static readonly TokenType RESSET = new(1, "reset");

        private TokenType(int id, string name) : base(id, name)
        {

        }
    }
}
