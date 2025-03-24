using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSG.MedicalHistory.API.Migrations
{
    /// <inheritdoc />
    public partial class _03242025medical : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MCGDoctorsList",
                keyColumn: "DoctorsID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 3, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "PatientMedicalHistory",
                keyColumn: "MedicalHistoryID",
                keyValue: 1,
                columns: new[] { "DateCreated", "VisitDate" },
                values: new object[] { new DateTime(2025, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 3, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PatientMedicalHistory",
                keyColumn: "MedicalHistoryID",
                keyValue: 2,
                columns: new[] { "DateCreated", "VisitDate" },
                values: new object[] { new DateTime(2025, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 3, 24, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MCGDoctorsList",
                keyColumn: "DoctorsID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "PatientMedicalHistory",
                keyColumn: "MedicalHistoryID",
                keyValue: 1,
                columns: new[] { "DateCreated", "VisitDate" },
                values: new object[] { new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PatientMedicalHistory",
                keyColumn: "MedicalHistoryID",
                keyValue: 2,
                columns: new[] { "DateCreated", "VisitDate" },
                values: new object[] { new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
