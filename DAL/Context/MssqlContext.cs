using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class MssqlContext : DbContext
    {
        public MssqlContext(DbContextOptions<MssqlContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
