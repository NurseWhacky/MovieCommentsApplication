namespace MovieCommentsApplication.Core.Exceptions
{
    public class MovieNotFoundException : Exception
    {
        public MovieNotFoundException(int movieId) 
            : base($"Non è stato trovato un film con id {movieId}.") 
        { }
    }
}
