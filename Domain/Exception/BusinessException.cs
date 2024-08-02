namespace Domain.Exception
{
    public class BusinessException : SystemException
    {
        public BusinessException()
        {
        }

        public BusinessException(string? message) : base(message)
        {
        }


    }
}
