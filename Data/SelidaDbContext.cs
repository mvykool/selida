using Microsoft.EntityFrameworkCore;
using selida.Models.Domain;

namespace selida.Data
{
    public class SelidaDbContext : DbContext
    {
        public SelidaDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}
