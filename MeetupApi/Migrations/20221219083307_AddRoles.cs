using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MeetupApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("000412f0-f68c-43af-8b42-ff2c51848b97"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("223c8dfe-8774-4eac-9eb9-2d0bd296517c"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("528067bf-1ba4-434d-bcf4-fbf9baef9f20"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("5d5b230a-767b-40de-b7e9-849f3904536b"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("8a90853e-e71d-4505-b0a3-61bdaa484d92"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d113beb-eba5-442e-9be7-cc310624dcdd", "095a032d-1ce8-4902-bc3c-8776c8bd8a01", "user", "USER" },
                    { "46c878be-470a-4eef-861c-864bf5e9cee9", "4ba1609b-30f4-4c4d-ae22-bf26c74f1326", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Description", "Place", "Speaker", "Theme" },
                values: new object[,]
                {
                    { new Guid("37ea20f6-3520-468f-a2a1-6ff7d1638784"), new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "111", "1", "1", "1" },
                    { new Guid("69987764-e354-4f73-8ab5-8104781940d7"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "222", "2", "2", "2" },
                    { new Guid("bafaf648-07eb-40fd-8dba-dbebd8fc817d"), new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "555", "5", "5", "5" },
                    { new Guid("d84351db-293a-438d-8182-f6272ecaa688"), new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "333", "3", "3", "3" },
                    { new Guid("efc6dbee-80db-446b-b16a-e318d8faada6"), new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "444", "4", "4", "4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d113beb-eba5-442e-9be7-cc310624dcdd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46c878be-470a-4eef-861c-864bf5e9cee9");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("37ea20f6-3520-468f-a2a1-6ff7d1638784"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("69987764-e354-4f73-8ab5-8104781940d7"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("bafaf648-07eb-40fd-8dba-dbebd8fc817d"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("d84351db-293a-438d-8182-f6272ecaa688"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("efc6dbee-80db-446b-b16a-e318d8faada6"));

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Description", "Place", "Speaker", "Theme" },
                values: new object[,]
                {
                    { new Guid("000412f0-f68c-43af-8b42-ff2c51848b97"), new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "444", "4", "4", "4" },
                    { new Guid("223c8dfe-8774-4eac-9eb9-2d0bd296517c"), new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "111", "1", "1", "1" },
                    { new Guid("528067bf-1ba4-434d-bcf4-fbf9baef9f20"), new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "333", "3", "3", "3" },
                    { new Guid("5d5b230a-767b-40de-b7e9-849f3904536b"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "222", "2", "2", "2" },
                    { new Guid("8a90853e-e71d-4505-b0a3-61bdaa484d92"), new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "555", "5", "5", "5" }
                });
        }
    }
}
