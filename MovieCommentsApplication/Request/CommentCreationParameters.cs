using System.Text.Json.Serialization;

namespace MovieCommentsApplication.RestAPI.Request
{
    public class CommentCreationParameters
    {
        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("movieId")]
        public int MovieId { get; set; }

        [JsonPropertyName("comment")]
        public string Comment { get; set; }
    }
}
