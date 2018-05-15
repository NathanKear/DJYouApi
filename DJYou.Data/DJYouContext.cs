using Microsoft.EntityFrameworkCore;

namespace DJYou.Data
{
    public class DJYouContext : DbContext
    {
        public DJYouContext(DbContextOptions<DJYouContext> options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
    }
}
