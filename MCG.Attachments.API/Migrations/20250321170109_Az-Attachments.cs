using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MCG.Attachments.API.Migrations
{
    /// <inheritdoc />
    public partial class AzAttachments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentsType",
                columns: table => new
                {
                    DocumentKey = table.Column<int>(type: "int", nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentsType", x => x.DocumentKey);
                });

            migrationBuilder.CreateTable(
                name: "FileTypes",
                columns: table => new
                {
                    FileKey = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileTypes", x => x.FileKey);
                });

            migrationBuilder.CreateTable(
                name: "PatientAttachments",
                columns: table => new
                {
                    AttachmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileType = table.Column<int>(type: "int", nullable: false),
                    DocType = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateUploaded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAttachments", x => x.AttachmentID);
                });

            migrationBuilder.InsertData(
                table: "DocumentsType",
                columns: new[] { "DocumentKey", "DocumentName" },
                values: new object[] { 0, "MRI" });

            migrationBuilder.InsertData(
                table: "FileTypes",
                columns: new[] { "FileKey", "FileName" },
                values: new object[] { 0, "PDF" });

            migrationBuilder.InsertData(
                table: "PatientAttachments",
                columns: new[] { "AttachmentID", "CreatedBy", "DateUploaded", "DocType", "FileName", "FilePath", "FileType", "PatientID" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 3, 21, 0, 0, 0, 0, DateTimeKind.Local), 0, "MRI_03082025_1048.PDF", "E:\\MCG\\API\\MCG.API\\Files", 0, 1000 },
                    { 2, 1, new DateTime(2025, 3, 21, 0, 0, 0, 0, DateTimeKind.Local), 1, "CAT_03082025_1040.PDF", "E:\\MCG\\API\\MCG.API\\Files", 0, 1001 },
                    { 3, 1, new DateTime(2025, 3, 21, 0, 0, 0, 0, DateTimeKind.Local), 1, "CAT_03082025_1040.PDF", "E:\\MCG\\API\\MCG.API\\Files", 2, 1001 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentsType");

            migrationBuilder.DropTable(
                name: "FileTypes");

            migrationBuilder.DropTable(
                name: "PatientAttachments");
        }
    }
}
