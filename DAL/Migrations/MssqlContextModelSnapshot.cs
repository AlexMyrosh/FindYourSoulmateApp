﻿// <auto-generated />
using System;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(MssqlContext))]
    partial class MssqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.Models.Interest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Interests");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b6b6b5b6-376e-4280-a44e-7912ce9fdb18"),
                            IsDeleted = false,
                            Name = "Art"
                        },
                        new
                        {
                            Id = new Guid("16b4ce88-6350-48f7-a1f4-bcab0787201f"),
                            IsDeleted = false,
                            Name = "Science"
                        },
                        new
                        {
                            Id = new Guid("c853b3ec-00d2-4d75-bf00-48dae82c11b2"),
                            IsDeleted = false,
                            Name = "Sport"
                        },
                        new
                        {
                            Id = new Guid("9ec8de86-0eda-4d7d-a87e-fa3e03a532e7"),
                            IsDeleted = false,
                            Name = "Technology"
                        },
                        new
                        {
                            Id = new Guid("ccdb368d-5b30-4186-a465-1adfca154426"),
                            IsDeleted = false,
                            Name = "Music"
                        },
                        new
                        {
                            Id = new Guid("9bb14a6d-e4d5-4897-b959-3e34386151c9"),
                            IsDeleted = false,
                            Name = "Cinema"
                        },
                        new
                        {
                            Id = new Guid("e636a91e-6590-4c89-af37-a3006a018f5e"),
                            IsDeleted = false,
                            Name = "Theater"
                        },
                        new
                        {
                            Id = new Guid("e51766b6-5ba5-4876-851f-6d549d011280"),
                            IsDeleted = false,
                            Name = "Literature"
                        },
                        new
                        {
                            Id = new Guid("c8f53c23-c8e1-4f54-b1e9-c7dcfc1e2d29"),
                            IsDeleted = false,
                            Name = "Hobby"
                        },
                        new
                        {
                            Id = new Guid("e70d7c9d-d31b-4ce3-8f04-15196f3e4714"),
                            IsDeleted = false,
                            Name = "Travel"
                        },
                        new
                        {
                            Id = new Guid("5b3fb6fd-3e7c-4e8a-a1d1-abe8b9288d4b"),
                            IsDeleted = false,
                            Name = "Games"
                        },
                        new
                        {
                            Id = new Guid("d3f0f2ef-bf3f-4db3-aefb-b8fddcbae76c"),
                            IsDeleted = false,
                            Name = "Photography"
                        },
                        new
                        {
                            Id = new Guid("e2f2e2ed-1ada-4836-b5d5-e4dd274ecd47"),
                            IsDeleted = false,
                            Name = "Fashion"
                        },
                        new
                        {
                            Id = new Guid("8d005092-5cf0-408a-b77a-012046c12660"),
                            IsDeleted = false,
                            Name = "Cooking"
                        },
                        new
                        {
                            Id = new Guid("aba4fc4d-3f07-460a-a9a1-ed8881889722"),
                            IsDeleted = false,
                            Name = "Health"
                        },
                        new
                        {
                            Id = new Guid("f0024b65-3f5f-4919-9f23-d9b2ffeb36a5"),
                            IsDeleted = false,
                            Name = "Fitness"
                        },
                        new
                        {
                            Id = new Guid("469c4156-32be-4b40-b3bf-12ba237549d7"),
                            IsDeleted = false,
                            Name = "Environment"
                        },
                        new
                        {
                            Id = new Guid("a303cdbf-8461-430f-b01b-18713898a5cd"),
                            IsDeleted = false,
                            Name = "History"
                        },
                        new
                        {
                            Id = new Guid("b411631b-e17d-48f2-8867-43c13abbfbab"),
                            IsDeleted = false,
                            Name = "Politics"
                        },
                        new
                        {
                            Id = new Guid("a99ceef5-b999-4ec1-8776-2ddffbab7869"),
                            IsDeleted = false,
                            Name = "Philosophy"
                        },
                        new
                        {
                            Id = new Guid("31ba8f86-c502-4b3e-952f-538d03b20906"),
                            IsDeleted = false,
                            Name = "Psychology"
                        },
                        new
                        {
                            Id = new Guid("050e46d9-460b-4ae2-a358-83aaaa754eaf"),
                            IsDeleted = false,
                            Name = "Spirituality"
                        },
                        new
                        {
                            Id = new Guid("cbf3802d-6345-4d95-bbba-d11a1c794e0a"),
                            IsDeleted = false,
                            Name = "Astronomy"
                        },
                        new
                        {
                            Id = new Guid("ea8cbde1-4aee-4bb9-8024-813c1843a3a0"),
                            IsDeleted = false,
                            Name = "Gardening"
                        },
                        new
                        {
                            Id = new Guid("6626a0d3-b999-4cfc-a3e9-cef013036fd0"),
                            IsDeleted = false,
                            Name = "Animals"
                        },
                        new
                        {
                            Id = new Guid("02f2b64d-65b4-41ae-866a-a4d4eb581bef"),
                            IsDeleted = false,
                            Name = "Nature"
                        },
                        new
                        {
                            Id = new Guid("bd1383c5-8fbc-466f-bbdb-ee71b4e59ecc"),
                            IsDeleted = false,
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = new Guid("8c2731a6-1452-488b-898e-2d5e4d3f3e5d"),
                            IsDeleted = false,
                            Name = "Business"
                        },
                        new
                        {
                            Id = new Guid("0b65e394-16eb-4d70-b458-da6cdcd9e7c6"),
                            IsDeleted = false,
                            Name = "Finance"
                        },
                        new
                        {
                            Id = new Guid("6b1051ab-4b2d-4873-9413-054f27c4ad3f"),
                            IsDeleted = false,
                            Name = "Economics"
                        },
                        new
                        {
                            Id = new Guid("feaa0ef3-6041-4651-9949-8217248366da"),
                            IsDeleted = false,
                            Name = "Languages"
                        },
                        new
                        {
                            Id = new Guid("abab9c12-78ea-4477-8bff-dfac715098c3"),
                            IsDeleted = false,
                            Name = "Meditation"
                        },
                        new
                        {
                            Id = new Guid("472f2039-4f7f-4839-a574-d210585c1a87"),
                            IsDeleted = false,
                            Name = "Yoga"
                        },
                        new
                        {
                            Id = new Guid("f6334ce9-ecb0-4c19-8191-5fdeb58ac667"),
                            IsDeleted = false,
                            Name = "Dance"
                        },
                        new
                        {
                            Id = new Guid("9a99f18d-abf2-4b77-b68f-4c786f84acac"),
                            IsDeleted = false,
                            Name = "Writing"
                        },
                        new
                        {
                            Id = new Guid("d8e1456e-ff0b-4f5d-b048-56c8f801d473"),
                            IsDeleted = false,
                            Name = "Painting"
                        },
                        new
                        {
                            Id = new Guid("1d7d9956-7db1-4fe9-9fdb-13b75b3d91eb"),
                            IsDeleted = false,
                            Name = "Drawing"
                        },
                        new
                        {
                            Id = new Guid("320eaaf6-70a9-42fc-af8e-52acf13486fc"),
                            IsDeleted = false,
                            Name = "Sculpture"
                        },
                        new
                        {
                            Id = new Guid("4cc555bf-339c-4149-ba49-7d768a248751"),
                            IsDeleted = false,
                            Name = "Pottery"
                        },
                        new
                        {
                            Id = new Guid("a002700a-b347-4223-a4ac-701c3866aa31"),
                            IsDeleted = false,
                            Name = "Knitting"
                        },
                        new
                        {
                            Id = new Guid("05ca23c4-8cc9-44df-aebd-15fb485dc1fb"),
                            IsDeleted = false,
                            Name = "Sewing"
                        },
                        new
                        {
                            Id = new Guid("c5599a9a-26f9-41ea-bae3-b74604d95b13"),
                            IsDeleted = false,
                            Name = "Woodworking"
                        },
                        new
                        {
                            Id = new Guid("ae373365-338d-4311-9b06-7109a71e1215"),
                            IsDeleted = false,
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = new Guid("b8418249-92eb-4fa2-8fa3-c7525ba7d1bf"),
                            IsDeleted = false,
                            Name = "Programming"
                        },
                        new
                        {
                            Id = new Guid("75f24fc4-cbfc-48e1-8fba-d21b0e314678"),
                            IsDeleted = false,
                            Name = "DIY"
                        },
                        new
                        {
                            Id = new Guid("862b8574-e9da-45fb-8ca6-454bafcaa0af"),
                            IsDeleted = false,
                            Name = "Magic"
                        },
                        new
                        {
                            Id = new Guid("e31050ce-b632-4f19-b04d-8749258c8d9f"),
                            IsDeleted = false,
                            Name = "Puzzles"
                        },
                        new
                        {
                            Id = new Guid("a5eb6675-1a7e-4eb4-819b-ec4a8569cc70"),
                            IsDeleted = false,
                            Name = "CardGames"
                        },
                        new
                        {
                            Id = new Guid("77083050-3e8c-4e5e-80e7-4e486b552328"),
                            IsDeleted = false,
                            Name = "BoardGames"
                        },
                        new
                        {
                            Id = new Guid("a5c420ba-e666-4bfc-9a6a-d44b605a403e"),
                            IsDeleted = false,
                            Name = "Volunteer"
                        });
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("LookingForGender")
                        .HasColumnType("int");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RelationType")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("InterestUser", b =>
                {
                    b.Property<Guid>("InterestsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UsersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("InterestsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("InterestsUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("InterestUser", b =>
                {
                    b.HasOne("DAL.Models.Interest", null)
                        .WithMany()
                        .HasForeignKey("InterestsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DAL.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DAL.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DAL.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
