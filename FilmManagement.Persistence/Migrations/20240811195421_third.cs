using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FilmManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("6850f349-a21e-4c9d-9c2d-36ed68c228fa"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("ccc8b3cd-7652-463b-bf63-cbe9090d4610"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("e4c7ae8b-c64d-44d3-943a-92d3bf01b8bc"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f740f912-714e-4cc6-aefb-57c92567bd58"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "IsActive", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("6850f349-a21e-4c9d-9c2d-36ed68c228fa"), new DateTime(2024, 8, 11, 19, 51, 14, 585, DateTimeKind.Utc).AddTicks(768), null, "Aksiyon filmleri, hızlı tempolu sahneleri ve sürekli hareket içeren maceralar sunar.", true, "Aksiyon", null },
                    { new Guid("ccc8b3cd-7652-463b-bf63-cbe9090d4610"), new DateTime(2024, 8, 11, 19, 51, 14, 585, DateTimeKind.Utc).AddTicks(800), null, "Fantastik filmler, sihir, mitoloji ve doğaüstü olaylar içeren fantastik evrenlerde geçer.", true, "Fantastik", null },
                    { new Guid("e4c7ae8b-c64d-44d3-943a-92d3bf01b8bc"), new DateTime(2024, 8, 11, 19, 51, 14, 585, DateTimeKind.Utc).AddTicks(778), null, "Bilim kurgu filmleri, teknolojinin ve bilimin sınırlarını zorlayan, gelecekte geçen hikayeler sunar.", true, "Bilim Kurgu", null },
                    { new Guid("f740f912-714e-4cc6-aefb-57c92567bd58"), new DateTime(2024, 8, 11, 19, 51, 14, 585, DateTimeKind.Utc).AddTicks(776), null, "Dram filmleri, insan doğasını ve kişisel ilişkileri derinlemesine ele alır.", true, "Dram", null }
                });
        }
    }
}
