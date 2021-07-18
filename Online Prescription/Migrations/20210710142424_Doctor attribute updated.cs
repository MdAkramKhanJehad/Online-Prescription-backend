using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_Prescription.Migrations
{
    public partial class Doctorattributeupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Education",
                table: "Doctors",
                newName: "Qualification");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Qualification",
                table: "Doctors",
                newName: "Education");
        }
    }
}
