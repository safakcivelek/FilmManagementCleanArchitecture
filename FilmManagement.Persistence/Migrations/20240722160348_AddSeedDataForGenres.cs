using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FilmManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDataForGenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("1a94fecf-8548-4d2e-ab58-d1076510a32a"), new DateTime(2024, 7, 22, 16, 3, 48, 391, DateTimeKind.Utc).AddTicks(6210), null, "Fantastik filmler, sihir, mitoloji ve doğaüstü olaylar içeren fantastik evrenlerde geçer.", "Fantastik", null },
                    { new Guid("8bdb6954-aef1-4fa2-83b8-757bc8ece691"), new DateTime(2024, 7, 22, 16, 3, 48, 391, DateTimeKind.Utc).AddTicks(6141), null, "Dram filmleri, insan doğasını ve kişisel ilişkileri derinlemesine ele alır.", "Dram", null },
                    { new Guid("9500e965-a73e-47e0-a34e-5a1be2f28e59"), new DateTime(2024, 7, 22, 16, 3, 48, 391, DateTimeKind.Utc).AddTicks(6131), null, "Aksiyon filmleri, hızlı tempolu sahneleri ve sürekli hareket içeren maceralar sunar.", "Aksiyon", null },
                    { new Guid("cf013735-7f72-404f-8907-e810baac857b"), new DateTime(2024, 7, 22, 16, 3, 48, 391, DateTimeKind.Utc).AddTicks(6143), null, "Bilim kurgu filmleri, teknolojinin ve bilimin sınırlarını zorlayan, gelecekte geçen hikayeler sunar.", "Bilim Kurgu", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("1a94fecf-8548-4d2e-ab58-d1076510a32a"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("8bdb6954-aef1-4fa2-83b8-757bc8ece691"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("9500e965-a73e-47e0-a34e-5a1be2f28e59"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cf013735-7f72-404f-8907-e810baac857b"));
        }
    }
}
