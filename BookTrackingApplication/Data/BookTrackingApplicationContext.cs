using Microsoft.EntityFrameworkCore;

namespace BookTrackingApplication.Data
{
    public class BookTrackingApplicationContext : DbContext
    {
        public BookTrackingApplicationContext(DbContextOptions<BookTrackingApplicationContext> bookTrackingApplicationContext)
            : base(bookTrackingApplicationContext)
        { }

        public DbSet<BookTrackingApplication.Models.Category> Category { get; set; }
    }
}
