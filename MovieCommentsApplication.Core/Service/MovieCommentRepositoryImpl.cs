using MovieCommentsApplication.Core.Exceptions;
using MovieCommentsApplication.Core.Model;

namespace MovieCommentsApplication.Core.Service
{
    public class MovieCommentRepositoryImpl : IMovieCommentRepository
    {
        public const int MIN_CHARACTERS = 10;
        //public const int MAX_CHARACTERS = 2000;
        public const int MIN_ID_VALUE = 1;
        private List<MovieComment> _movieComments;

        public MovieCommentRepositoryImpl()
        {
            _movieComments = new();
        }

        public int GetNextCommentId()
        {
            if (_movieComments.Count == 0) return MIN_ID_VALUE;
            return _movieComments.Max(c => c.Id) + 1;
        }

        public MovieComment CreateComment(int userId, int movieId, string comment)
        {
            //id = GetNextCommentId();
            var newComment = new MovieComment(GetNextCommentId(), userId, movieId, comment);
            if (comment.Length < MIN_CHARACTERS) throw new InvalidCharacterNumberException(MIN_CHARACTERS);
            if (userId < MIN_ID_VALUE) throw new UserNotFoundException(userId);
            if (movieId < MIN_ID_VALUE) throw new MovieNotFoundException(movieId);
            _movieComments.Add(newComment);
            return newComment;

        }

        public bool DeleteCommentById(int id)
        {
            var commentToDelete = GetCommentById(id);
            return _movieComments.Remove(commentToDelete);
        }

        public List<MovieComment> GetAllComments() => _movieComments;

        public MovieComment GetCommentById(int commentId)
        {
            var foundComment = _movieComments.FirstOrDefault(c => c.Id == commentId);
            if (foundComment == null) throw new CommentNotFoundException(commentId);
            return foundComment;

        }

        public List<MovieComment> GetCommentsByMovieId(int movieId)
            => _movieComments.FindAll(c => c.MovieId == movieId);

        public List<MovieComment> GetCommentsByUserId(int userId)
            => _movieComments.FindAll(c => c.UserId == userId);

        public MovieComment UpdateComment(int commentId, MovieComment updatedComment)
        {
            var commentToUpdate = GetCommentById(commentId);
            commentToUpdate.Comment = updatedComment.Comment;
            if (updatedComment.Comment.Length < MIN_CHARACTERS) throw new InvalidCharacterNumberException(MIN_CHARACTERS);
            return commentToUpdate;
        }
    }
}
