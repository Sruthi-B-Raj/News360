using Microsoft.EntityFrameworkCore;

namespace Authentication_API.Models
{
    public class AuthDbContext:DbContext
    {
        #region Constructor
        public AuthDbContext(DbContextOptions options):base(options)
        {
            Database.EnsureCreated();
        }
        #endregion

        #region DbSet
        public DbSet<User> Users { get; set; }
        #endregion

    }
}
