using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FilmManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRoleIdFromFilmRatings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("36a96203-da6d-46a2-a914-9c7459ddebbc"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("630d44fd-b1fd-4eb9-9fd9-b1fed0f14ebc"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("a70980fa-c6c1-4663-af87-24b095f670f3"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("c3a5b8c0-dd7a-4a63-962f-ab9b33fe14ed"));

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "FilmRatings");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "FilmRatings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "IsActive", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("36a96203-da6d-46a2-a914-9c7459ddebbc"), new DateTime(2024, 8, 11, 19, 54, 21, 350, DateTimeKind.Utc).AddTicks(3751), null, "Bilim kurgu filmleri, teknolojinin ve bilimin sınırlarını zorlayan, gelecekte geçen hikayeler sunar.", true, "Bilim Kurgu", null },
                    { new Guid("630d44fd-b1fd-4eb9-9fd9-b1fed0f14ebc"), new DateTime(2024, 8, 11, 19, 54, 21, 350, DateTimeKind.Utc).AddTicks(3749), null, "Dram filmleri, insan doğasını ve kişisel ilişkileri derinlemesine ele alır.", true, "Dram", null },
                    { new Guid("a70980fa-c6c1-4663-af87-24b095f670f3"), new DateTime(2024, 8, 11, 19, 54, 21, 350, DateTimeKind.Utc).AddTicks(3753), null, "Fantastik filmler, sihir, mitoloji ve doğaüstü olaylar içeren fantastik evrenlerde geçer.", true, "Fantastik", null },
                    { new Guid("c3a5b8c0-dd7a-4a63-962f-ab9b33fe14ed"), new DateTime(2024, 8, 11, 19, 54, 21, 350, DateTimeKind.Utc).AddTicks(3741), null, "Aksiyon filmleri, hızlı tempolu sahneleri ve sürekli hareket içeren maceralar sunar.", true, "Aksiyon", null }
                });
        }
    }
}
