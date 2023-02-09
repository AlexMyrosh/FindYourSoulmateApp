using Data_Access_Layer.Models;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Context
{
    public class MssqlContext : DbContext
    {
        public MssqlContext(DbContextOptions<MssqlContext> options) : base(options)
        {}

        public DbSet<Question> Questions { get; set; }

        public DbSet<AnswerOption> AnswerOptions { get; set; }

        public DbSet<Survey> Surveys { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserAnswer> UserAnswers { get; set; }
    }
}
