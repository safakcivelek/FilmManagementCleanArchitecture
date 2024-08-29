using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FilmManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changedFimIdToFilmId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FimId",
                table: "Purchases");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Directors",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Actors",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "IsActive", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0c1fec87-f992-4013-86aa-9446f0d87a56"), new DateTime(2024, 8, 29, 20, 1, 5, 282, DateTimeKind.Utc).AddTicks(3747), null, "Aksiyon filmleri, hızlı tempolu sahneleri ve sürekli hareket içeren maceralar sunar.", true, "Aksiyon", null },
                    { new Guid("41d479bc-0e03-4149-9a71-b6f971f3bd34"), new DateTime(2024, 8, 29, 20, 1, 5, 282, DateTimeKind.Utc).AddTicks(3760), null, "Fantastik filmler, sihir, mitoloji ve doğaüstü olaylar içeren fantastik evrenlerde geçer.", true, "Fantastik", null },
                    { new Guid("9305dfa0-a483-42d8-9675-23d76dcdd96d"), new DateTime(2024, 8, 29, 20, 1, 5, 282, DateTimeKind.Utc).AddTicks(3758), null, "Bilim kurgu filmleri, teknolojinin ve bilimin sınırlarını zorlayan, gelecekte geçen hikayeler sunar.", true, "Bilim Kurgu", null },
                    { new Guid("ec283ec3-d685-472a-87f6-5b26aea2ec9f"), new DateTime(2024, 8, 29, 20, 1, 5, 282, DateTimeKind.Utc).AddTicks(3755), null, "Dram filmleri, insan doğasını ve kişisel ilişkileri derinlemesine ele alır.", true, "Dram", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("0c1fec87-f992-4013-86aa-9446f0d87a56"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("41d479bc-0e03-4149-9a71-b6f971f3bd34"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("9305dfa0-a483-42d8-9675-23d76dcdd96d"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("ec283ec3-d685-472a-87f6-5b26aea2ec9f"));

            migrationBuilder.AddColumn<Guid>(
                name: "FimId",
                table: "Purchases",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Directors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

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
    }
}
