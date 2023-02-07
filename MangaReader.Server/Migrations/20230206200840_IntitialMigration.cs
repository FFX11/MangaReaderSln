using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangaReader.Server.Migrations
{
    /// <inheritdoc />
    public partial class IntitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Manga",
                keyColumn: "MangaClassId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserModel",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Manga",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Manga",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Manga",
                columns: new[] { "MangaClassId", "MangaName", "MyUserModelId", "UserId" },
                values: new object[] { 1, "0b5dc24c-cbd1-4348-abeb-7e54a0705635", null, "71cb42ad-77ac-4d4c-b158-cdd83eae5e02" });

            migrationBuilder.InsertData(
                table: "UserModel",
                columns: new[] { "Id", "ConfirmEmail", "DateOfBirth", "Email", "FirstName", "Gender", "LastName", "MangaClassId", "PhotoPath" },
                values: new object[] { 1, "Test@yahoo.com", new DateTime(2023, 2, 5, 17, 25, 56, 178, DateTimeKind.Local).AddTicks(9363), "Test@yahoo.com", "Test", 0, "Test", 1, "images/mary.png" });
        }
    }
}
