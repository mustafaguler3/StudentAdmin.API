using Microsoft.EntityFrameworkCore;

namespace StudentAdmin.API.Data
{
    public class VtContext : DbContext
    {
        public VtContext(DbContextOptions<VtContext> options) : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Address> Address { get; set; }
    }
}
