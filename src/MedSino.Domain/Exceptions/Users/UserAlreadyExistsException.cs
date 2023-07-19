namespace MedSino.Domain.Exceptions.Users;

public class UserAlreadyExistsException : AlreadyExistsException
{
    public UserAlreadyExistsException()
    {
        TitleMessage = "User already exists";
    }

    public UserAlreadyExistsException(string phone)
    {
        TitleMessage = "This email is already registered";
    }
}
