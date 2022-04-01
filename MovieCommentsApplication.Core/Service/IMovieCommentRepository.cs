using MovieCommentsApplication.Core.Model;

namespace MovieCommentsApplication.Core.Service
{
    public interface IMovieCommentRepository
    {
        MovieComment CreateComment(int userId, int movieId, string comment);

        List<MovieComment> GetAllComments();

        MovieComment GetCommentById(int id);

        MovieComment UpdateComment(int commentId, MovieComment updatedComment);

        bool DeleteCommentById(int id);

        List<MovieComment> GetCommentsByUserId(int userId);

        List<MovieComment> GetCommentsByMovieId(int movieId);
    }
}
