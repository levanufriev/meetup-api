using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MeetupApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Description", "Place", "Speaker", "Theme" },
                values: new object[,]
                {
                    { new Guid("093deb67-be72-412c-b6a2-0a797e56a3f5"), new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "555", "5", "5", "5" },
                    { new Guid("1901f789-4cb8-4bf9-b72a-ec1787592098"), new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "444", "4", "4", "4" },
                    { new Guid("5a6fe7c4-6e36-4064-b7ca-bc5cbceefc74"), new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "333", "3", "3", "3" },
                    { new Guid("b68f79c0-1147-4402-8160-2f28af499fb8"), new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "111", "1", "1", "1" },
                    { new Guid("d62bb844-7c8c-49a2-af47-7792c8c00515"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "222", "2", "2", "2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("093deb67-be72-412c-b6a2-0a797e56a3f5"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("1901f789-4cb8-4bf9-b72a-ec1787592098"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("5a6fe7c4-6e36-4064-b7ca-bc5cbceefc74"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("b68f79c0-1147-4402-8160-2f28af499fb8"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("d62bb844-7c8c-49a2-af47-7792c8c00515"));
        }
    }
}
