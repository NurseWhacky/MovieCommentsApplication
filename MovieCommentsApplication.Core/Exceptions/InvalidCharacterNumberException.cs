namespace MovieCommentsApplication.Core.Exceptions
{
    public class InvalidCharacterNumberException : Exception
    {
        public InvalidCharacterNumberException(int minCharacters)
       
            : base($"I commenti devono avere un minimo di {minCharacters} caratteri.") 
        {  }
    }
}
