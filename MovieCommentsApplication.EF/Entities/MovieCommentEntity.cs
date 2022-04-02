using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieCommentsApplication.EF.Entities
{
    [Table("movie_comment")]
    public class MovieCommentEntity
    {
        [Column("id"), Key]
        public int Id { get; set; }

        [Column("user_id"), Required]
        public int UserId { get; set; }

        [Column("movie_id"), Required]
        public int MovieId { get; set; }

        [Column("comment"), Required]
        public string Comment { get; set; }

        public MovieCommentEntity(int id, int userId, int movieId, string comment)
        {
            Id = id;
            UserId = userId;
            MovieId = movieId;
            Comment = comment;
        }

        public MovieCommentEntity() { }
    }
}
