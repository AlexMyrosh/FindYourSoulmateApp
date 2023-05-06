using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class MssqlContext : DbContext
    {
        public MssqlContext(DbContextOptions<MssqlContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Interest> Interests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Interests)
                .WithMany(i => i.Users)
                .UsingEntity(j => j.ToTable("UserInterests"));

            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Interest>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWID()");
        }
    }
}