using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MSG.MedicalHistory.API.Migrations
{
    /// <inheritdoc />
    public partial class MedicalHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MCGDoctorsList",
                columns: table => new
                {
                    DoctorsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MCGDoctorsList", x => x.DoctorsID);
                });

            migrationBuilder.CreateTable(
                name: "PatientMedicalHistory",
                columns: table => new
                {
                    MedicalHistoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Treatment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMedicalHistory", x => x.MedicalHistoryID);
                });

            migrationBuilder.InsertData(
                table: "MCGDoctorsList",
                columns: new[] { "DoctorsID", "CreatedBy", "DateCreated", "DoctorsName" },
                values: new object[] { 1, 1, new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Local), "Xlander, Xandr" });

            migrationBuilder.InsertData(
                table: "PatientMedicalHistory",
                columns: new[] { "MedicalHistoryID", "CreatedBy", "DateCreated", "Diagnosis", "DoctorId", "Notes", "PatientID", "Treatment", "VisitDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Local), "this patient has the flu.", 1, "we will check on them later", 1000, "Gave them antibiotics", new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, 1, new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Local), "Patient Has a rash on his feet, red spots.", 1, "we will check on them later", 1000, "Gave them antibiotics", new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Local) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MCGDoctorsList");

            migrationBuilder.DropTable(
                name: "PatientMedicalHistory");
        }
    }
}
