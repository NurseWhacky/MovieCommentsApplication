using MovieCommentsApplication.Core.Exceptions;
using MovieCommentsApplication.Core.Model;
using MovieCommentsApplication.Core.Service;
using MovieCommentsApplication.EF.Entities;
using MovieCommentsApplication.EF.Mapper;

namespace MovieCommentsApplication.EF.Service
{

    /* QUESTA CLASSE VA RIFATTA UTILIZZANDO IL CONTEXT */ 
    public class DbService : IMovieCommentRepository
    { 
         public const int MIN_CHARACTERS = 10;
        //public const int MAX_CHARACTERS = 2000;
        public const int MIN_ID_VALUE = 1;
        private MovieCommentContext _context;
        private IMovieCommentRepository _repository;

        public DbService(IMovieCommentRepository repository)
        {
            _repository = repository;
            _context = new();
            _context.Database.EnsureCreated();

        }


        public MovieComment CreateComment(int userId, int movieId, string comment)
        {
            var newComment = new MovieCommentEntity(GetNextCommentId(), userId, movieId, comment);
            // eccezioni
            if (comment.Length < MIN_CHARACTERS) throw new InvalidCharacterNumberException(MIN_CHARACTERS);
            if (userId < MIN_ID_VALUE) throw new UserNotFoundException(userId);
            if (movieId < MIN_ID_VALUE) throw new MovieNotFoundException(movieId);
            //salvo le modifiche nel db
            _context.Add(newComment);
            _context.SaveChanges();
            //restituisco un model del core
            return DbMapper.From(newComment);
        }
      
        public bool DeleteCommentById(int id)
        {
            var commentToDelete = _context.MovieCommentEntities.FirstOrDefault(c => c.Id == id);
            if (commentToDelete != null)
            {
                _context.MovieCommentEntities.Remove(commentToDelete);
                _context.SaveChanges();
                return true;
            }
            return false;
            //return _context.MovieCommentEntities.Remove(DbMapper.From(GetCommentById(id)));
        }

        public List<MovieComment> GetAllComments()
        {
            var comments = _context.MovieCommentEntities.ToList();
            var modelList = new List<MovieComment>();
            foreach (var comment in comments)
            {
                modelList.Add(DbMapper.From(comment));
            }
            return modelList;
        }
       
        public MovieComment GetCommentById(int id)
        {
            var foundComment = _context.MovieCommentEntities.FirstOrDefault(c => c.Id == id);
            if (foundComment == null) throw new CommentNotFoundException(id);
            return DbMapper.From(foundComment);
        }
            //=> _repository.GetCommentById(id);
        
        public List<MovieComment> GetCommentsByMovieId(int movieId)
            => _repository.GetCommentsByMovieId(movieId);

        public List<MovieComment> GetCommentsByUserId(int userId)
            => _repository.GetCommentsByUserId(userId);

        public int GetNextCommentId() => _context.MovieCommentEntities.Max(x => x.Id) + 1;

        public MovieComment UpdateComment(int commentId, MovieComment updatedComment)
        {
            var commentToUpdate = _context.MovieCommentEntities.FirstOrDefault(c => c.Id == commentId);
            if (commentToUpdate == null) throw new CommentNotFoundException(commentId);
            commentToUpdate.Comment = updatedComment.Comment;
            if (commentToUpdate.Comment.Length < MIN_CHARACTERS) throw new InvalidCharacterNumberException(MIN_CHARACTERS);
            _context.MovieCommentEntities.Update(commentToUpdate);
            _context.SaveChanges();
            return DbMapper.From(commentToUpdate);
        }
          
    }
}
