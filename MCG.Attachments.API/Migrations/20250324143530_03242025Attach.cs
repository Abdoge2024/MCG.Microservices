using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MCG.Attachments.API.Migrations
{
    /// <inheritdoc />
    public partial class _03242025Attach : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PatientAttachments",
                keyColumn: "AttachmentID",
                keyValue: 1,
                column: "DateUploaded",
                value: new DateTime(2025, 3, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "PatientAttachments",
                keyColumn: "AttachmentID",
                keyValue: 2,
                column: "DateUploaded",
                value: new DateTime(2025, 3, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "PatientAttachments",
                keyColumn: "AttachmentID",
                keyValue: 3,
                column: "DateUploaded",
                value: new DateTime(2025, 3, 24, 0, 0, 0, 0, DateTimeKind.Local));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PatientAttachments",
                keyColumn: "AttachmentID",
                keyValue: 1,
                column: "DateUploaded",
                value: new DateTime(2025, 3, 21, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "PatientAttachments",
                keyColumn: "AttachmentID",
                keyValue: 2,
                column: "DateUploaded",
                value: new DateTime(2025, 3, 21, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "PatientAttachments",
                keyColumn: "AttachmentID",
                keyValue: 3,
                column: "DateUploaded",
                value: new DateTime(2025, 3, 21, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
