namespace Application.Exceptions;

public class UserAlreadyExistException(string userAlreadyExistWithEmail) : SystemException(userAlreadyExistWithEmail);
