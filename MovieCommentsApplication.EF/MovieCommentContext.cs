using Microsoft.EntityFrameworkCore;
using MovieCommentsApplication.EF.Entities;

namespace MovieCommentsApplication.EF
{
    public class MovieCommentContext : DbContext
    {
        //public MovieCommentContext(DbContextOptions<MovieCommentContext> options)
        //    : base(options)
        //{  }

        public DbSet<MovieCommentEntity> MovieCommentEntities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;Port=3306;Database=movie_comments;Uid=root;Pwd=";
            var mySqlServerVersion = new MySqlServerVersion(new Version(5, 7, 24));

            optionsBuilder.UseMySql(connectionString, mySqlServerVersion);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MovieCommentEntity>().ToTable("comments");
        }

    }
}
