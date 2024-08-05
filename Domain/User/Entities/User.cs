using Domain.Base;
using Domain.Base.ValueObjects;
using Domain.Exceptions;
using Domain.User.ObjectValue;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User.Entities
{
    public class User : AggregateRoot
    {
        public Name Name { get; protected set; }
        public DateOnly? Birthday { get; protected set; }
        public string Email { get; protected set; }
        public string? PhoneNumber { get; protected set; }
        public List<Role> Roles { get; protected set; } = [];
        public string Password { get; protected set; }
        public DateTime? VerifiedAt { get; protected set; }
        public UserProvider Provider { get; protected set; }
        public bool IsEnabled { get; protected set; }
        public ID? AvatarId { get; protected set; }

        private readonly List<Token> _tokens = [];
        public virtual ISet<ID> SavedFilms { get; protected set; } = new HashSet<ID>();
        public virtual ISet<ID> Histories { get; protected set; } = new HashSet<ID>();

        //getter
        public virtual IReadOnlyList<Token> Tokens => _tokens;

        public User() : base(new())
        {
        }

        public User(ID id, Name name, DateOnly birthday, string email, string phoneNumber, List<Role> roles, string password, DateTime? verifiedAt, ISet<Token> tokens, UserProvider provider, ID? avatarId) : base(id)
        {
            Name = name;
            Birthday = birthday;
            Email = email;
            PhoneNumber = phoneNumber;
            Roles = roles;
            Password = password;
            VerifiedAt = verifiedAt;
            Provider = provider;
            AvatarId = avatarId;
        }

        public Token? GetToken(string? verifyToken, TokenType type)
        {
            return verifyToken is null
                ? throw new ArgumentNullException(nameof(verifyToken))
                : _tokens.FirstOrDefault(t => t.IsValid(verifyToken, type));
        }

        public bool Verify(string verifyToken)
        {
            if (VerifiedAt is null)
                return false;

            Token? token = GetToken(verifyToken, TokenType.VERIFY);
            if (token is not null)
            {
                if (token.IsExpired()) throw new ExpiredTokenException("Verify token " + verifyToken + " is exprired !");

                VerifiedAt = DateTime.Now;
                token.Active = false;
                return true;
            }

            throw new InvalidTokenException("Verify token " + verifyToken + " is invalid !");
        }

        public bool ResetPassword(string newPassword, string resetToken)
        {
            Token? token = GetToken(resetToken, TokenType.RESSET);
            if (token is not null)
            {
                if (token.IsExpired()) throw new ExpiredTokenException("Verify token " + resetToken + " is exprired !");

                Password = newPassword;
                token.Active = false;
                return true;
            }

            throw new InvalidTokenException("Verify token " + resetToken + " is invalid !");
        }

        public bool AddToken(string token, int age, TokenType tokenType)
        {
            Token t = new Token(token, age, tokenType);
            return true;
        }
        
        public void ChangeAvatar(ID avatarId)
        {
            AvatarId = avatarId;
        }

        public void SetEnabled(bool enabled) { 
            IsEnabled = enabled;
        }

        public void Update(DateOnly? birthday, string? fistName, string? lastName, string? phoneNumber)
        {
            if(birthday is not null)Birthday = birthday;
            if(fistName is not null && lastName is not null) Name = new(fistName, lastName);
            if(phoneNumber is not null) PhoneNumber = phoneNumber;
        }

    }
}
