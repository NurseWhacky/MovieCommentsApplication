using MovieCommentsApplication.Core.Model;
using MovieCommentsApplication.RestAPI.Models;

namespace MovieCommentsApplication.RestAPI.Mapper
{
    public static class MovieCommentMapper
    {
        public static MovieCommentDTO From(MovieComment comment)
        {
            return new()
            {
                Id = comment.Id,
                UserId = comment.UserId,
                MovieId = comment.MovieId,
                Comment = comment.Comment
            };
        }

        public static MovieComment From(MovieCommentDTO commentDTO)
        {
            return new(commentDTO.Id)
            {
                UserId = commentDTO.UserId,
                Comment = commentDTO.Comment,
                MovieId = commentDTO.MovieId
            };
        }
    }
}
