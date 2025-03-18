using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MCG.Profile.API.Migrations
{
    /// <inheritdoc />
    public partial class Azure_bd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    PatientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatFirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PatMiddleName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    PatLastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PatDateOfBirth = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PatEmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PatPhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PatGender = table.Column<int>(type: "int", nullable: false),
                    PatAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PatCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PatState = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PatZipCode = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    PatEmergencyContact = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PatEmergencyContactPhone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PatEmergencyContactEmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.PatientID);
                });

            migrationBuilder.CreateTable(
                name: "PatientHistory",
                columns: table => new
                {
                    HistoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    PatFirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PatMiddleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PatLastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PatDateOfBirth = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PatEmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PatPhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PatGender = table.Column<int>(type: "int", nullable: false),
                    PatAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PatCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PatState = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PatZipCode = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    PatEmergencyContact = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PatEmergencyContactPhone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PatEmergencyContactEmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientHistory", x => x.HistoryID);
                    table.ForeignKey(
                        name: "FK_PatientHistory_Patient_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "PatientID", "DateCreated", "PatAddress", "PatCity", "PatDateOfBirth", "PatEmail", "PatEmergencyContact", "PatEmergencyContactEmail", "PatEmergencyContactPhone", "PatFirstName", "PatGender", "PatLastName", "PatMiddleName", "PatPhoneNumber", "PatState", "PatZipCode", "UpdatedDate" },
                values: new object[,]
                {
                    { 1000, new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Local), "6110 Sturbridge lane", "Cumming", "06/07/1935", "ghabdo@att.net", "Janet", "jnet@net.com", "2162251525", "Georges", 0, "Whiteman", "H", "2162251525", "Georgia", 30040, null },
                    { 1001, new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Local), "6110 Sturbridge lane", "Alpahretta", "06/07/1935", "jacko@att.net", "Ghazi", "Jackt@net.com", "2162251525", "Jack", 0, "Sheriff", "M", "2162251525", "Georgia", 30040, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientHistory_PatientID",
                table: "PatientHistory",
                column: "PatientID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientHistory");

            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}
