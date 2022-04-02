using MovieCommentsApplication.EF.Entities;

namespace MovieCommentsApplication.EF
{
    public class DbInitializer // esperimento di seeding dati (non funziona)
    {
        public static void Initializer(MovieCommentContext context)
        {
            context.Database.EnsureCreated();

            //se il db contiene già dati non fa nulla
            if (context.MovieCommentEntities.Any())
            {
                return;
            }

            //se vuoto inserisce 3 entities
            var movieComments = new MovieCommentEntity[]
            {
                new MovieCommentEntity(100, 1, 1, "Che bello questo film!"),
                new MovieCommentEntity(200, 2, 2, "Ehi, ma è fantastico!!!"),
                new MovieCommentEntity(300, 3, 3, "Non ho nulla da dire...")
            };

            foreach (MovieCommentEntity mc in movieComments)
            {
                context.MovieCommentEntities.Add(mc);
            }
            context.SaveChanges();
        }
    }
}
