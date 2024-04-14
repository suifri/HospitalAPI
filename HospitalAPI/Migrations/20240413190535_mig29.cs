using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalAPI.Migrations
{
    /// <inheritdoc />
    public partial class mig29 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Room_Room_Id",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Patients_Room_Id",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "Room_Id",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Coverage",
                table: "Insurances");

            migrationBuilder.DropColumn(
                name: "Plan",
                table: "Insurances");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Room",
                newName: "IdTest");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "IdTest");

            migrationBuilder.CreateTable(
                name: "RoomPatients",
                columns: table => new
                {
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomPatients", x => new { x.PatientId, x.RoomId });
                    table.ForeignKey(
                        name: "FK_RoomPatients_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomPatients_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "IdTest",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomPatients_PatientId",
                table: "RoomPatients",
                column: "PatientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomPatients_RoomId",
                table: "RoomPatients",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomPatients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.RenameColumn(
                name: "IdTest",
                table: "Room",
                newName: "PatientId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Room",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Room_Id",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Coverage",
                table: "Insurances",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Plan",
                table: "Insurances",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Room_Id",
                table: "Patients",
                column: "Room_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Room_Room_Id",
                table: "Patients",
                column: "Room_Id",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
