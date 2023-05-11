using DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class MssqlContext : IdentityDbContext<User>
    {
        public MssqlContext(DbContextOptions<MssqlContext> options) : base(options)
        {
            
        }

        public DbSet<Interest> Interests { get; set; }

        public DbSet<ChatMessage> ChatMessages { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Interests)
                .WithMany(i => i.Users)
                .UsingEntity(j => j.ToTable("InterestsUsers"));

            modelBuilder.Entity<User>()
                .HasMany(u => u.LikedUsers)
                .WithMany(i => i.LikedByUsers)
                .UsingEntity<Dictionary<string, object>>(
                    "UserLikes",
                    b => b.HasOne<User>().WithMany().HasForeignKey("LikedUserId"),
                    b => b.HasOne<User>().WithMany().HasForeignKey("UserId"))
                .ToTable("UserLikes");

            modelBuilder.Entity<ChatMessage>()
                .HasOne(c => c.Sender)
                .WithMany(u => u.SentMessages)
                .HasForeignKey(c => c.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ChatMessage>()
                .HasOne(c => c.Receiver)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(c => c.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contact>()
                .HasOne(c => c.User)
                .WithMany(u => u.Contacts)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contact>()
                .HasOne(c => c.ContactUser)
                .WithMany(u => u.UsersWithThisContact)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Interest>().HasData(new List<Interest>
            {
                new Interest { Id = new Guid("b6b6b5b6-376e-4280-a44e-7912ce9fdb18"), Name = "Art" },
                new Interest { Id = new Guid("16b4ce88-6350-48f7-a1f4-bcab0787201f"), Name = "Science" },
                new Interest { Id = new Guid("c853b3ec-00d2-4d75-bf00-48dae82c11b2"), Name = "Sport" },
                new Interest { Id = new Guid("9ec8de86-0eda-4d7d-a87e-fa3e03a532e7"), Name = "Technology" },
                new Interest { Id = new Guid("ccdb368d-5b30-4186-a465-1adfca154426"), Name = "Music" },
                new Interest { Id = new Guid("9bb14a6d-e4d5-4897-b959-3e34386151c9"), Name = "Cinema" },
                new Interest { Id = new Guid("e636a91e-6590-4c89-af37-a3006a018f5e"), Name = "Theater" },
                new Interest { Id = new Guid("e51766b6-5ba5-4876-851f-6d549d011280"), Name = "Literature" },
                new Interest { Id = new Guid("c8f53c23-c8e1-4f54-b1e9-c7dcfc1e2d29"), Name = "Hobby" },
                new Interest { Id = new Guid("e70d7c9d-d31b-4ce3-8f04-15196f3e4714"), Name = "Travel" },
                new Interest { Id = new Guid("5b3fb6fd-3e7c-4e8a-a1d1-abe8b9288d4b"), Name = "Games" },
                new Interest { Id = new Guid("d3f0f2ef-bf3f-4db3-aefb-b8fddcbae76c"), Name = "Photography" },
                new Interest { Id = new Guid("e2f2e2ed-1ada-4836-b5d5-e4dd274ecd47"), Name = "Fashion" },
                new Interest { Id = new Guid("8d005092-5cf0-408a-b77a-012046c12660"), Name = "Cooking" },
                new Interest { Id = new Guid("aba4fc4d-3f07-460a-a9a1-ed8881889722"), Name = "Health" },
                new Interest { Id = new Guid("f0024b65-3f5f-4919-9f23-d9b2ffeb36a5"), Name = "Fitness" },
                new Interest { Id = new Guid("469c4156-32be-4b40-b3bf-12ba237549d7"), Name = "Environment" },
                new Interest { Id = new Guid("a303cdbf-8461-430f-b01b-18713898a5cd"), Name = "History" },
                new Interest { Id = new Guid("b411631b-e17d-48f2-8867-43c13abbfbab"), Name = "Politics" },
                new Interest { Id = new Guid("a99ceef5-b999-4ec1-8776-2ddffbab7869"), Name = "Philosophy" },
                new Interest { Id = new Guid("31ba8f86-c502-4b3e-952f-538d03b20906"), Name = "Psychology" },
                new Interest { Id = new Guid("050e46d9-460b-4ae2-a358-83aaaa754eaf"), Name = "Spirituality" },
                new Interest { Id = new Guid("cbf3802d-6345-4d95-bbba-d11a1c794e0a"), Name = "Astronomy" },
                new Interest { Id = new Guid("ea8cbde1-4aee-4bb9-8024-813c1843a3a0"), Name = "Gardening" },
                new Interest { Id = new Guid("6626a0d3-b999-4cfc-a3e9-cef013036fd0"), Name = "Animals" },
                new Interest { Id = new Guid("02f2b64d-65b4-41ae-866a-a4d4eb581bef"), Name = "Nature" },
                new Interest { Id = new Guid("bd1383c5-8fbc-466f-bbdb-ee71b4e59ecc"), Name = "Adventure" },
                new Interest { Id = new Guid("8c2731a6-1452-488b-898e-2d5e4d3f3e5d"), Name = "Business" },
                new Interest { Id = new Guid("0b65e394-16eb-4d70-b458-da6cdcd9e7c6"), Name = "Finance" },
                new Interest { Id = new Guid("6b1051ab-4b2d-4873-9413-054f27c4ad3f"), Name = "Economics" },
                new Interest { Id = new Guid("feaa0ef3-6041-4651-9949-8217248366da"), Name = "Languages" },
                new Interest { Id = new Guid("abab9c12-78ea-4477-8bff-dfac715098c3"), Name = "Meditation" },
                new Interest { Id = new Guid("472f2039-4f7f-4839-a574-d210585c1a87"), Name = "Yoga" },
                new Interest { Id = new Guid("f6334ce9-ecb0-4c19-8191-5fdeb58ac667"), Name = "Dance" },
                new Interest { Id = new Guid("9a99f18d-abf2-4b77-b68f-4c786f84acac"), Name = "Writing" },
                new Interest { Id = new Guid("d8e1456e-ff0b-4f5d-b048-56c8f801d473"), Name = "Painting" },
                new Interest { Id = new Guid("1d7d9956-7db1-4fe9-9fdb-13b75b3d91eb"), Name = "Drawing" },
                new Interest { Id = new Guid("320eaaf6-70a9-42fc-af8e-52acf13486fc"), Name = "Sculpture" },
                new Interest { Id = new Guid("4cc555bf-339c-4149-ba49-7d768a248751"), Name = "Pottery" },
                new Interest { Id = new Guid("a002700a-b347-4223-a4ac-701c3866aa31"), Name = "Knitting" },
                new Interest { Id = new Guid("05ca23c4-8cc9-44df-aebd-15fb485dc1fb"), Name = "Sewing" },
                new Interest { Id = new Guid("c5599a9a-26f9-41ea-bae3-b74604d95b13"), Name = "Woodworking" },
                new Interest { Id = new Guid("ae373365-338d-4311-9b06-7109a71e1215"), Name = "Electronics" },
                new Interest { Id = new Guid("b8418249-92eb-4fa2-8fa3-c7525ba7d1bf"), Name = "Programming" },
                new Interest { Id = new Guid("75f24fc4-cbfc-48e1-8fba-d21b0e314678"), Name = "DIY" },
                new Interest { Id = new Guid("862b8574-e9da-45fb-8ca6-454bafcaa0af"), Name = "Magic" },
                new Interest { Id = new Guid("e31050ce-b632-4f19-b04d-8749258c8d9f"), Name = "Puzzles" },
                new Interest { Id = new Guid("a5eb6675-1a7e-4eb4-819b-ec4a8569cc70"), Name = "CardGames" },
                new Interest { Id = new Guid("77083050-3e8c-4e5e-80e7-4e486b552328"), Name = "BoardGames" },
                new Interest { Id = new Guid("a5c420ba-e666-4bfc-9a6a-d44b605a403e"), Name = "Volunteer" }
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}