using Microsoft.AspNetCore.Mvc;
using MovieCommentsApplication.Core.Exceptions;
using MovieCommentsApplication.Core.Service;
using MovieCommentsApplication.EF.Service;
using MovieCommentsApplication.RestAPI.Mapper;
using MovieCommentsApplication.RestAPI.Request;
using MovieCommentsApplication.RestAPI.Response;

namespace MovieCommentsApplication.RestAPI.Controllers
{
    [ApiController]
    [Route("comments")]
    public class MovieCommentsController : ControllerBase
    {
        //private IMovieCommentRepository _repository;
        private DbService _repository;

        public MovieCommentsController(/*IMovieCommentRepository*/ DbService repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public ActionResult<MovieCommentResponse> CreateComment([FromBody] CommentCreationParameters parameters)
        {
            try
            {
                var movieComment = _repository.CreateComment
                    (parameters.UserId, parameters.MovieId, parameters.Comment);
                return Ok(MovieCommentMapper.From(movieComment));
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(new ErrorResponse()
                {
                    ErrorMessage = e.Message,
                    Timestamp = DateTime.Now
                });
            }
            catch (MovieNotFoundException e)
            {
                return BadRequest(new ErrorResponse()
                {
                    ErrorMessage = e.Message,
                    Timestamp = DateTime.Now
                });
            }
            catch (InvalidCharacterNumberException e)
            {
                return BadRequest(new ErrorResponse()
                {
                    ErrorMessage = e.Message,
                    Timestamp = DateTime.Now
                });
            }

        }

        [HttpGet]
        public ActionResult<List<MovieCommentResponse>> GetComments()
        {
            var comments = _repository.GetAllComments();
            return Ok(comments.Select(c => MovieCommentMapper.From(c)));
        }

        [HttpGet]
        [Route("{comment-id}")]
        public ActionResult<MovieCommentResponse> GetCommentById([FromRoute(Name = "comment-id")] int commentId)
        {
            try
            {
                var commentById = _repository.GetCommentById(commentId);
                return Ok(MovieCommentMapper.From(commentById));
            }
            catch (CommentNotFoundException e)
            {
                return NotFound(new ErrorResponse()
                {
                    ErrorMessage = e.Message,
                    Timestamp = DateTime.Now
                });
            }
        }

        [HttpPatch]
        [Route("{comment-id}")]
        public ActionResult<MovieCommentResponse> UpdateComment([FromRoute(Name = "comment-id")] int id, [FromBody] CommentUpdateParameters parameters)
        {
            try
            {
                var commentToUpdate = _repository.GetCommentById(id);
                commentToUpdate.Comment = parameters.Comment;
                _repository.UpdateComment(id, commentToUpdate);
                return Ok(MovieCommentMapper.From(commentToUpdate));
            }
            catch (CommentNotFoundException e)
            {
                return NotFound(new ErrorResponse()
                {
                    ErrorMessage = e.Message,
                    Timestamp = DateTime.Now
                });
            }
            catch (InvalidCharacterNumberException e)
            {
                return BadRequest(new ErrorResponse()
                {
                    ErrorMessage = e.Message,
                    Timestamp = DateTime.Now
                });
            }
        }

        [HttpDelete]
        [Route("{comment-id}")]
        public ActionResult DeleteComment([FromRoute(Name = "comment-id")] int id)
        {
            try
            {
                _repository.DeleteCommentById(id);
                return NoContent();
            }
            catch (CommentNotFoundException e)
            {
                return NotFound(new ErrorResponse()
                {
                    ErrorMessage = e.Message,
                    Timestamp = DateTime.Now
                });
            }
        }
    }
}
