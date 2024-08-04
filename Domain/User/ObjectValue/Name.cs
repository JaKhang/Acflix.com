namespace Domain.User.ObjectValue
{
    public record Name(string FirstName, string LastName)
    {
        public string FullName() { return FirstName + LastName; }
    }
}
