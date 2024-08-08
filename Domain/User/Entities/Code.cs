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
    public class Code : Entity

    {
        public Code(ID userId) : base(new ID())
        {
            UserId = userId;
        }

        public Code(string value, int age, TokenType type, ID userId) : base(new ID())
        {
            Value = value;
            CreatedAt = DateTime.Now;
            Age = age;
            Active = true;
            Type = type;
            UserId = userId;
        }

        public string Value { get; internal set; }
        public int Age { get; internal set; }
        public bool Active { get; internal set; }
        public TokenType Type { get; internal set; }
        public ID UserId { get; internal set; }

        public bool IsValid(string code, TokenType tokenType)
        {
            var isValid = Value.Equals(code);
            return isValid && Active && tokenType.Equals(Type);
        }

        public bool IsExpired()
        {
            return DateTime.Now < CreatedAt.AddMinutes(Age);
        }
    }
}
