using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MCG.Profile.API.Migrations
{
    /// <inheritdoc />
    public partial class _03242025PAtient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "PatientID",
                keyValue: 1000,
                column: "DateCreated",
                value: new DateTime(2025, 3, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "PatientID",
                keyValue: 1001,
                column: "DateCreated",
                value: new DateTime(2025, 3, 24, 0, 0, 0, 0, DateTimeKind.Local));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "PatientID",
                keyValue: 1000,
                column: "DateCreated",
                value: new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "PatientID",
                keyValue: 1001,
                column: "DateCreated",
                value: new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
