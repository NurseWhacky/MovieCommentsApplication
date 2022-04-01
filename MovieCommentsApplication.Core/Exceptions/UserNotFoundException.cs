namespace MovieCommentsApplication.Core.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(int userId)
            : base($"Non è stato trovato un utente con id {userId}.") 
        { }
    }
}
