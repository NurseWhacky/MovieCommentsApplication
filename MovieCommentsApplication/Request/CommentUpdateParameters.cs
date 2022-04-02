using System.Text.Json.Serialization;

namespace MovieCommentsApplication.RestAPI.Request
{
    public class CommentUpdateParameters
    {
        [JsonPropertyName("comment")]
        public string Comment { get; set; }
    }
}
