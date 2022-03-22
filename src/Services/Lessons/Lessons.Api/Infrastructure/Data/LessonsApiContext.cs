using Microsoft.EntityFrameworkCore;

namespace Lessons.Api.Infrastructure.Data
{
    public class LessonsApiContext : DbContext
    {
        public LessonsApiContext(DbContextOptions<LessonsApiContext> options) : base(options) {}

        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Alternative> Alternatives { get; set; }
    }
}