using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Mission6_Richards.Models
{

    // set up the movie context class that will be used to create the database and store the information from the form
    public class MovieContext : DbContext
    {

        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
            // Leave blank for now
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; } 



    }
}
