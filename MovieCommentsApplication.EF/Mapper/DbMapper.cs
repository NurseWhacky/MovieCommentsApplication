using MovieCommentsApplication.Core.Model;
using MovieCommentsApplication.EF.Entities;

namespace MovieCommentsApplication.EF.Mapper
{
    public static class DbMapper
    {
        // PROVA da utilizzare in DbService (vedi)
        public static MovieCommentEntity From (MovieComment comment)
        {
            return new MovieCommentEntity()
            {
                Id = comment.Id,
                UserId = comment.UserId,
                MovieId = comment.MovieId,
                Comment = comment.Comment
            };
        }

        public static MovieComment From(MovieCommentEntity entity)
        {
            return new MovieComment(entity.Id)
            {
                UserId = entity.UserId,
                MovieId = entity.MovieId,
                Comment = entity.Comment
            };
        }

    }
}
