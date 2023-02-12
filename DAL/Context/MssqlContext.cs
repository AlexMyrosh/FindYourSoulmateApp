﻿using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Survey>()
                .Property(survey => survey.StopDateTime)
                .HasDefaultValue(new DateTime(2023, 01, 01));

            modelBuilder.Entity<User>()
                .HasIndex(b => b.Email)
                .IsUnique();

            modelBuilder.Entity<User>().Property(m => m.Name).IsRequired(false);
            modelBuilder.Entity<User>().Property(m => m.Email).IsRequired(false);
            modelBuilder.Entity<User>().Property(m => m.TelegramUsername).IsRequired(false);

            modelBuilder.Entity<User>()
                .HasIndex(b => b.TelegramUsername)
                .IsUnique();

            modelBuilder.Entity<Survey>()
                .HasIndex(b => b.Name)
                .IsUnique();

            modelBuilder.Entity<UserAnswer>()
                .HasKey(userAnswer => new
                {
                    userAnswer.UserId, 
                    userAnswer.QuestionId
                });
        }
    }
}
