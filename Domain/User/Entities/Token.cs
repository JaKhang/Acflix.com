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

        public Token(string value, int age, TokenType type) : base(new())
        {
            Value = value;
            CreatedAt = DateTime.Now;
            Age = age;
            Active = true;
            Type = type;
        }

        public string Value { get; internal set; }
        public DateTime CreatedAt { get; internal set; }
        public int Age { get; internal set; }
        public bool Active { get; internal set; }
        public TokenType Type { get; internal set; }
        public bool IsValid(string token, TokenType tokenType)
        {
            bool isValid = Value.Equals(token);
            return isValid && Active && tokenType == Type;
        }

        public bool IsExpired()
        {
            return DateTime.Now < CreatedAt.AddMinutes(Age);
        }
    }
}
