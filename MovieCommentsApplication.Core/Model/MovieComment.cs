﻿namespace MovieCommentsApplication.Core.Model
{
    public class MovieComment
    {
        public int Id { get; }

        public int UserId { get; set; }

        public int MovieId { get; set; }

        public string Comment { get; set; }

        public MovieComment() { }

        public MovieComment(int id) 
        {
            Id = id;
        }

        public MovieComment(int id, int userId, int movieId, string comment)
        {
            Id = id;
            UserId = userId;
            MovieId = movieId;
            Comment = comment;
        }
    }
}
