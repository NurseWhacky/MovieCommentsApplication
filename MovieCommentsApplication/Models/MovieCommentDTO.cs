namespace MovieCommentsApplication.RestAPI.Models
{
    public class MovieCommentDTO
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
    }
}
