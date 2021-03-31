using Microsoft.EntityFrameworkCore.Migrations;

namespace ReadExcelFiles.Migrations
{
    public partial class ModifiedDBMotor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SaleName",
                table: "DBMotor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SaleName",
                table: "DBMotor");
        }
    }
}
