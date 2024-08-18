using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FilmManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddImageAndVideoToFilmEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("5785c353-4823-4128-9c37-a7e02ac68271"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("8f5713e8-da50-47b8-901c-01f1ce7162df"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("a5550c34-b8f2-412e-8401-c5dd97146639"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("c0d19e87-f26b-4533-80ee-65ee3c98b192"));

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Films",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Video",
                table: "Films",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Directors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "IsActive", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("239d861b-e8bc-427f-95ac-059f73b4ccb8"), new DateTime(2024, 8, 16, 1, 37, 39, 359, DateTimeKind.Utc).AddTicks(4155), null, "Fantastik filmler, sihir, mitoloji ve doğaüstü olaylar içeren fantastik evrenlerde geçer.", true, "Fantastik", null },
                    { new Guid("af2f6c0c-de66-485e-848a-d65966380c59"), new DateTime(2024, 8, 16, 1, 37, 39, 359, DateTimeKind.Utc).AddTicks(4142), null, "Aksiyon filmleri, hızlı tempolu sahneleri ve sürekli hareket içeren maceralar sunar.", true, "Aksiyon", null },
                    { new Guid("c5976af2-ea38-4a83-a6e5-4a0759f49f57"), new DateTime(2024, 8, 16, 1, 37, 39, 359, DateTimeKind.Utc).AddTicks(4153), null, "Bilim kurgu filmleri, teknolojinin ve bilimin sınırlarını zorlayan, gelecekte geçen hikayeler sunar.", true, "Bilim Kurgu", null },
                    { new Guid("ed1a7d8a-3f5c-4059-83f9-94286c873595"), new DateTime(2024, 8, 16, 1, 37, 39, 359, DateTimeKind.Utc).AddTicks(4150), null, "Dram filmleri, insan doğasını ve kişisel ilişkileri derinlemesine ele alır.", true, "Dram", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("239d861b-e8bc-427f-95ac-059f73b4ccb8"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("af2f6c0c-de66-485e-848a-d65966380c59"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("c5976af2-ea38-4a83-a6e5-4a0759f49f57"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("ed1a7d8a-3f5c-4059-83f9-94286c873595"));

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Video",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Actors");

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "IsActive", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("5785c353-4823-4128-9c37-a7e02ac68271"), new DateTime(2024, 8, 14, 21, 34, 5, 931, DateTimeKind.Utc).AddTicks(7263), null, "Dram filmleri, insan doğasını ve kişisel ilişkileri derinlemesine ele alır.", true, "Dram", null },
                    { new Guid("8f5713e8-da50-47b8-901c-01f1ce7162df"), new DateTime(2024, 8, 14, 21, 34, 5, 931, DateTimeKind.Utc).AddTicks(7267), null, "Fantastik filmler, sihir, mitoloji ve doğaüstü olaylar içeren fantastik evrenlerde geçer.", true, "Fantastik", null },
                    { new Guid("a5550c34-b8f2-412e-8401-c5dd97146639"), new DateTime(2024, 8, 14, 21, 34, 5, 931, DateTimeKind.Utc).AddTicks(7254), null, "Aksiyon filmleri, hızlı tempolu sahneleri ve sürekli hareket içeren maceralar sunar.", true, "Aksiyon", null },
                    { new Guid("c0d19e87-f26b-4533-80ee-65ee3c98b192"), new DateTime(2024, 8, 14, 21, 34, 5, 931, DateTimeKind.Utc).AddTicks(7265), null, "Bilim kurgu filmleri, teknolojinin ve bilimin sınırlarını zorlayan, gelecekte geçen hikayeler sunar.", true, "Bilim Kurgu", null }
                });
        }
    }
}
