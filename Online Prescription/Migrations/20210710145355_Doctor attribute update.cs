using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_Prescription.Migrations
{
    public partial class Doctorattributeupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Doctors_DoctorDId",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_DoctorDId",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "DoctorDId",
                table: "Prescriptions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorDId",
                table: "Prescriptions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_DoctorDId",
                table: "Prescriptions",
                column: "DoctorDId");

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
