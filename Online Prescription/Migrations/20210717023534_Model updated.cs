using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_Prescription.Migrations
{
    public partial class Modelupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Doctors_DoctorDId",
                table: "Prescriptions");

            //migrationBuilder.DropTable(
            //    name: "MedicinePrescription");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_DoctorDId",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "DoctorDId",
                table: "Prescriptions");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Prescriptions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Prescriptions");

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Prescriptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorDId",
                table: "Prescriptions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MedicinePrescription",
                columns: table => new
                {
                    MedicinesMId = table.Column<int>(type: "int", nullable: false),
                    PrescriptionsPId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicinePrescription", x => new { x.MedicinesMId, x.PrescriptionsPId });
                    table.ForeignKey(
                        name: "FK_MedicinePrescription_Medicines_MedicinesMId",
                        column: x => x.MedicinesMId,
                        principalTable: "Medicines",
                        principalColumn: "MId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicinePrescription_Prescriptions_PrescriptionsPId",
                        column: x => x.PrescriptionsPId,
                        principalTable: "Prescriptions",
                        principalColumn: "PId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_DoctorDId",
                table: "Prescriptions",
                column: "DoctorDId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicinePrescription_PrescriptionsPId",
                table: "MedicinePrescription",
                column: "PrescriptionsPId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Doctors_DoctorDId",
                table: "Prescriptions",
                column: "DoctorDId",
                principalTable: "Doctors",
                principalColumn: "DId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
