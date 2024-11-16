namespace Domain.User.ObjectValue
{
    public record Name(string FirstName, string LastName)
    {
        public override string ToString()
        {
            return LastName + " " + FirstName;
        }
    }
}
