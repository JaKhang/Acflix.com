using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ExpiredTokenException : BusinessException
    {
        public ExpiredTokenException(string? message) : base(message)
        {
        }
    }
}
