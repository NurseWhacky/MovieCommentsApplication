namespace MovieCommentsApplication.RestAPI.Response
{
    public class MovieCommentResponse
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public string Comment { get; set; }
    }
}
