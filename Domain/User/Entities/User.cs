using Domain.Base;
using Domain.Base.ValueObjects;
using Domain.Exceptions;
using Domain.User.ObjectValue;


namespace Domain.User.Entities
{
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
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
        public string RefreshToken { get; protected set; } = string.Empty;
        private readonly List<Code> _codes = [];
        public virtual ISet<ID> SavedFilms { get; protected set; } = new HashSet<ID>();
        public virtual ISet<ID> Histories { get; protected set; } = new HashSet<ID>();
        public virtual IReadOnlyList<Code> Codes => _codes;

        public User() : base(new ID())
        {
        }

        public User(Name name, DateOnly birthday, string email, string phoneNumber, List<Role> roles, string password, DateTime? verifiedAt, UserProvider provider, ID? avatarId) : base(new ID())
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

        private Code? GetToken(string? verifyToken, TokenType type)
        {
            return verifyToken is null
                ? throw new ArgumentNullException(nameof(verifyToken))
                : _codes.FirstOrDefault(t => t.IsValid(verifyToken, type));
        }

        public bool Verify(string verifyToken)
        {
            if (VerifiedAt is null)
                return false;

            var token = GetToken(verifyToken, TokenType.VERIFY);
            if (token is null) throw new InvalidTokenException("Verify token " + verifyToken + " is invalid !");
            if (token.IsExpired()) throw new ExpiredTokenException("Verify token " + verifyToken + " is expired !");

            VerifiedAt = DateTime.Now;
            token.Active = false;
            return true;

        }

        public bool ResetPassword(string newPassword, string resetToken)
        {
            var token = GetToken(resetToken, TokenType.RESSET);
            if (token is null) throw new InvalidTokenException("Verify token " + resetToken + " is invalid !");
            if (token.IsExpired()) throw new ExpiredTokenException("Verify token " + resetToken + " is expired !");

            Password = newPassword;
            token.Active = false;
            return true;

        }

        public bool AddCode(string token, int age, TokenType tokenType)
        {
            var t = new Code(token, age, tokenType, Id);
            _codes.Add(t);
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
            if(birthday is not null) Birthday = birthday;
            if(fistName is not null && lastName is not null) Name = new Name(fistName, lastName);
            if(phoneNumber is not null) PhoneNumber = phoneNumber;
        }

        public static UserBuilder builder()
        {
            return new UserBuilder();
        }

    }


    public class UserBuilder
    {
        private string _firstName;
        private string _lastName;
        private DateOnly _birthday;
        private string _password;
        private string _email;
        private string _phoneNumber;
        private ID _avatar;
        private UserProvider _provider;
        private List<Role> _roles;

        internal UserBuilder()
        {

        }

        public UserBuilder FirstName(string firstName)
        {

            _firstName = firstName;
            return this;
        }


        public UserBuilder LastName(string lastName)
        {

            _lastName = lastName;
            return this;
        }


        public UserBuilder Email(string email)
        {

            _email = email;
            return this;
        }


        public UserBuilder Provider(UserProvider v)
        {

            _provider = v;
            return this;
        }

        public UserBuilder PhoneNumber(string v)
        {

            _phoneNumber = v;
            return this;
        }

        public UserBuilder Birthday(DateOnly dateOnly)
        {
            _birthday = dateOnly;
            return this;
        }

        public UserBuilder Roles(params Role[] roles)
        {
            _roles = new List<Role>(roles);
            return this;
        }

        public UserBuilder Password(string password)
        {
            _password = password;
            return this;
        }

        public UserBuilder AvatarId(ID avatarId)
        {
            _avatar = avatarId;
            return this;
        }

        public User build()
        {
            return new User(
                new Name(_firstName, _lastName),
                _birthday,
                _email,
                _phoneNumber,
                _roles,
                _password,
                null,
                _provider,
                _avatar
            );
        }

}
}
