using StudentPortalNew.Data;
using StudentPortalNew.Models.Entities;

namespace StudentPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }

    public class DbContext
    {
    }
}