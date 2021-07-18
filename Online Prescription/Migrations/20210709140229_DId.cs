using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_Prescription.Migrations
{
    public partial class DId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Doctors",
                newName: "DId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DId",
                table: "Doctors",
                newName: "Id");
        }
    }
}
