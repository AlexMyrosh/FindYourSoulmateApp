using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class NewIsDeletedcolumninIntereststable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Interests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Interests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("02f2b64d-65b4-41ae-866a-a4d4eb581bef"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("050e46d9-460b-4ae2-a358-83aaaa754eaf"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("05ca23c4-8cc9-44df-aebd-15fb485dc1fb"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("0b65e394-16eb-4d70-b458-da6cdcd9e7c6"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("16b4ce88-6350-48f7-a1f4-bcab0787201f"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("1d7d9956-7db1-4fe9-9fdb-13b75b3d91eb"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("31ba8f86-c502-4b3e-952f-538d03b20906"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("320eaaf6-70a9-42fc-af8e-52acf13486fc"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("469c4156-32be-4b40-b3bf-12ba237549d7"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("472f2039-4f7f-4839-a574-d210585c1a87"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("4cc555bf-339c-4149-ba49-7d768a248751"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("5b3fb6fd-3e7c-4e8a-a1d1-abe8b9288d4b"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("6626a0d3-b999-4cfc-a3e9-cef013036fd0"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("6b1051ab-4b2d-4873-9413-054f27c4ad3f"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("75f24fc4-cbfc-48e1-8fba-d21b0e314678"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("77083050-3e8c-4e5e-80e7-4e486b552328"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("862b8574-e9da-45fb-8ca6-454bafcaa0af"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("8c2731a6-1452-488b-898e-2d5e4d3f3e5d"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("8d005092-5cf0-408a-b77a-012046c12660"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("9a99f18d-abf2-4b77-b68f-4c786f84acac"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("9bb14a6d-e4d5-4897-b959-3e34386151c9"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("9ec8de86-0eda-4d7d-a87e-fa3e03a532e7"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("a002700a-b347-4223-a4ac-701c3866aa31"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("a303cdbf-8461-430f-b01b-18713898a5cd"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("a5c420ba-e666-4bfc-9a6a-d44b605a403e"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("a5eb6675-1a7e-4eb4-819b-ec4a8569cc70"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("a99ceef5-b999-4ec1-8776-2ddffbab7869"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("aba4fc4d-3f07-460a-a9a1-ed8881889722"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("abab9c12-78ea-4477-8bff-dfac715098c3"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("ae373365-338d-4311-9b06-7109a71e1215"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("b411631b-e17d-48f2-8867-43c13abbfbab"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("b6b6b5b6-376e-4280-a44e-7912ce9fdb18"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("b8418249-92eb-4fa2-8fa3-c7525ba7d1bf"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("bd1383c5-8fbc-466f-bbdb-ee71b4e59ecc"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("c5599a9a-26f9-41ea-bae3-b74604d95b13"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("c853b3ec-00d2-4d75-bf00-48dae82c11b2"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("c8f53c23-c8e1-4f54-b1e9-c7dcfc1e2d29"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("cbf3802d-6345-4d95-bbba-d11a1c794e0a"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("ccdb368d-5b30-4186-a465-1adfca154426"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("d3f0f2ef-bf3f-4db3-aefb-b8fddcbae76c"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("d8e1456e-ff0b-4f5d-b048-56c8f801d473"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("e2f2e2ed-1ada-4836-b5d5-e4dd274ecd47"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("e31050ce-b632-4f19-b04d-8749258c8d9f"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("e51766b6-5ba5-4876-851f-6d549d011280"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("e636a91e-6590-4c89-af37-a3006a018f5e"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("e70d7c9d-d31b-4ce3-8f04-15196f3e4714"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("ea8cbde1-4aee-4bb9-8024-813c1843a3a0"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("f0024b65-3f5f-4919-9f23-d9b2ffeb36a5"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("f6334ce9-ecb0-4c19-8191-5fdeb58ac667"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: new Guid("feaa0ef3-6041-4651-9949-8217248366da"),
                column: "IsDeleted",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Interests");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Interests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
