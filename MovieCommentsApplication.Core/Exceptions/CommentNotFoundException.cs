namespace MovieCommentsApplication.Core.Exceptions
{
    public class CommentNotFoundException : Exception
    {
        public CommentNotFoundException(int commentId) 
            : base($"Non è stato trovato un commento con id {commentId}.")
        { }
    }
}
