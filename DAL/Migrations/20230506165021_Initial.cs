using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LookingForGender = table.Column<int>(type: "int", nullable: false),
                    RelationType = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterestsUsers",
                columns: table => new
                {
                    InterestsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestsUsers", x => new { x.InterestsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_InterestsUsers_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestsUsers_Interests_InterestsId",
                        column: x => x.InterestsId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("02f2b64d-65b4-41ae-866a-a4d4eb581bef"), false, "Nature" },
                    { new Guid("050e46d9-460b-4ae2-a358-83aaaa754eaf"), false, "Spirituality" },
                    { new Guid("05ca23c4-8cc9-44df-aebd-15fb485dc1fb"), false, "Sewing" },
                    { new Guid("0b65e394-16eb-4d70-b458-da6cdcd9e7c6"), false, "Finance" },
                    { new Guid("16b4ce88-6350-48f7-a1f4-bcab0787201f"), false, "Science" },
                    { new Guid("1d7d9956-7db1-4fe9-9fdb-13b75b3d91eb"), false, "Drawing" },
                    { new Guid("31ba8f86-c502-4b3e-952f-538d03b20906"), false, "Psychology" },
                    { new Guid("320eaaf6-70a9-42fc-af8e-52acf13486fc"), false, "Sculpture" },
                    { new Guid("469c4156-32be-4b40-b3bf-12ba237549d7"), false, "Environment" },
                    { new Guid("472f2039-4f7f-4839-a574-d210585c1a87"), false, "Yoga" },
                    { new Guid("4cc555bf-339c-4149-ba49-7d768a248751"), false, "Pottery" },
                    { new Guid("5b3fb6fd-3e7c-4e8a-a1d1-abe8b9288d4b"), false, "Games" },
                    { new Guid("6626a0d3-b999-4cfc-a3e9-cef013036fd0"), false, "Animals" },
                    { new Guid("6b1051ab-4b2d-4873-9413-054f27c4ad3f"), false, "Economics" },
                    { new Guid("75f24fc4-cbfc-48e1-8fba-d21b0e314678"), false, "DIY" },
                    { new Guid("77083050-3e8c-4e5e-80e7-4e486b552328"), false, "BoardGames" },
                    { new Guid("862b8574-e9da-45fb-8ca6-454bafcaa0af"), false, "Magic" },
                    { new Guid("8c2731a6-1452-488b-898e-2d5e4d3f3e5d"), false, "Business" },
                    { new Guid("8d005092-5cf0-408a-b77a-012046c12660"), false, "Cooking" },
                    { new Guid("9a99f18d-abf2-4b77-b68f-4c786f84acac"), false, "Writing" },
                    { new Guid("9bb14a6d-e4d5-4897-b959-3e34386151c9"), false, "Cinema" },
                    { new Guid("9ec8de86-0eda-4d7d-a87e-fa3e03a532e7"), false, "Technology" },
                    { new Guid("a002700a-b347-4223-a4ac-701c3866aa31"), false, "Knitting" },
                    { new Guid("a303cdbf-8461-430f-b01b-18713898a5cd"), false, "History" },
                    { new Guid("a5c420ba-e666-4bfc-9a6a-d44b605a403e"), false, "Volunteer" },
                    { new Guid("a5eb6675-1a7e-4eb4-819b-ec4a8569cc70"), false, "CardGames" },
                    { new Guid("a99ceef5-b999-4ec1-8776-2ddffbab7869"), false, "Philosophy" },
                    { new Guid("aba4fc4d-3f07-460a-a9a1-ed8881889722"), false, "Health" },
                    { new Guid("abab9c12-78ea-4477-8bff-dfac715098c3"), false, "Meditation" },
                    { new Guid("ae373365-338d-4311-9b06-7109a71e1215"), false, "Electronics" },
                    { new Guid("b411631b-e17d-48f2-8867-43c13abbfbab"), false, "Politics" },
                    { new Guid("b6b6b5b6-376e-4280-a44e-7912ce9fdb18"), false, "Art" },
                    { new Guid("b8418249-92eb-4fa2-8fa3-c7525ba7d1bf"), false, "Programming" },
                    { new Guid("bd1383c5-8fbc-466f-bbdb-ee71b4e59ecc"), false, "Adventure" },
                    { new Guid("c5599a9a-26f9-41ea-bae3-b74604d95b13"), false, "Woodworking" },
                    { new Guid("c853b3ec-00d2-4d75-bf00-48dae82c11b2"), false, "Sport" },
                    { new Guid("c8f53c23-c8e1-4f54-b1e9-c7dcfc1e2d29"), false, "Hobby" },
                    { new Guid("cbf3802d-6345-4d95-bbba-d11a1c794e0a"), false, "Astronomy" },
                    { new Guid("ccdb368d-5b30-4186-a465-1adfca154426"), false, "Music" },
                    { new Guid("d3f0f2ef-bf3f-4db3-aefb-b8fddcbae76c"), false, "Photography" },
                    { new Guid("d8e1456e-ff0b-4f5d-b048-56c8f801d473"), false, "Painting" },
                    { new Guid("e2f2e2ed-1ada-4836-b5d5-e4dd274ecd47"), false, "Fashion" },
                    { new Guid("e31050ce-b632-4f19-b04d-8749258c8d9f"), false, "Puzzles" },
                    { new Guid("e51766b6-5ba5-4876-851f-6d549d011280"), false, "Literature" },
                    { new Guid("e636a91e-6590-4c89-af37-a3006a018f5e"), false, "Theater" },
                    { new Guid("e70d7c9d-d31b-4ce3-8f04-15196f3e4714"), false, "Travel" },
                    { new Guid("ea8cbde1-4aee-4bb9-8024-813c1843a3a0"), false, "Gardening" },
                    { new Guid("f0024b65-3f5f-4919-9f23-d9b2ffeb36a5"), false, "Fitness" },
                    { new Guid("f6334ce9-ecb0-4c19-8191-5fdeb58ac667"), false, "Dance" },
                    { new Guid("feaa0ef3-6041-4651-9949-8217248366da"), false, "Languages" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InterestsUsers_UsersId",
                table: "InterestsUsers",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "InterestsUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Interests");
        }
    }
}
