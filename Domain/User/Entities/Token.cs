using Domain.Base;
using Domain.Base.ValueObjects;
using Domain.User.ObjectValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User.Entities
{
    public class Token : Entity

    {
        public Token() : base(new())
        {

        }

        public Token(string code, int age, TokenType type) : base(new ID())
        {
            Code = code;
            CreatedAt = DateTime.Now;
            Age = age;
            Active = true;
            Type = type;
        }

        public string Code { get; internal set; }
        public DateTime CreatedAt { get; internal set; }
        public int Age { get; internal set; }
        public bool Active { get; internal set; }
        public TokenType Type { get; internal set; }
        public bool IsValid(string code, TokenType tokenType)
        {
            var isValid = Code.Equals(code);
            return isValid && Active && tokenType.Equals(Type);
        }

        public bool IsExpired()
        {
            return DateTime.Now < CreatedAt.AddMinutes(Age);
        }
    }
}
