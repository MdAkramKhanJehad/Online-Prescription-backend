using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_Prescription.Migrations
{
    public partial class Medicineclassadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Doctors_DoctorDId",
                table: "Prescription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prescription",
                table: "Prescription");

            migrationBuilder.RenameTable(
                name: "Prescription",
                newName: "Prescriptions");

            migrationBuilder.RenameIndex(
                name: "IX_Prescription_DoctorDId",
                table: "Prescriptions",
                newName: "IX_Prescriptions_DoctorDId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prescriptions",
                table: "Prescriptions",
                column: "PId");

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    MId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Indication = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Usage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instruction = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.MId);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Doctors_DoctorDId",
                table: "Prescriptions");

            migrationBuilder.DropTable(
                name: "MedicinePrescription");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prescriptions",
                table: "Prescriptions");

            migrationBuilder.RenameTable(
                name: "Prescriptions",
                newName: "Prescription");

            migrationBuilder.RenameIndex(
                name: "IX_Prescriptions_DoctorDId",
                table: "Prescription",
                newName: "IX_Prescription_DoctorDId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prescription",
                table: "Prescription",
                column: "PId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Doctors_DoctorDId",
                table: "Prescription",
                column: "DoctorDId",
                principalTable: "Doctors",
                principalColumn: "DId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
