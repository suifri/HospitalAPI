using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalAPI.Migrations
{
    /// <inheritdoc />
    public partial class DeleteNurseAndLabs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabScreening");

            migrationBuilder.DropTable(
                name: "NursePatient");

            migrationBuilder.DropTable(
                name: "Nurses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LabScreening",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Patient_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Guid_ = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestCost = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabScreening", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabScreening_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabScreening_Patients_Patient_Id",
                        column: x => x.Patient_Id,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nurses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nurses_Staff__StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NursePatient",
                columns: table => new
                {
                    NursesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NursePatient", x => new { x.NursesId, x.PatientsId });
                    table.ForeignKey(
                        name: "FK_NursePatient_Nurses_NursesId",
                        column: x => x.NursesId,
                        principalTable: "Nurses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NursePatient_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabScreening_DoctorId",
                table: "LabScreening",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_LabScreening_Patient_Id",
                table: "LabScreening",
                column: "Patient_Id");

            migrationBuilder.CreateIndex(
                name: "IX_NursePatient_PatientsId",
                table: "NursePatient",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_Nurses_StaffId",
                table: "Nurses",
                column: "StaffId",
                unique: true);
        }
    }
}
