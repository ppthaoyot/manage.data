using Microsoft.EntityFrameworkCore.Migrations;

namespace ReadExcelFiles.Migrations
{
    public partial class Create01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endorsement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefNumber = table.Column<string>(nullable: true),
                    PolicyNumber = table.Column<string>(nullable: true),
                    ProductDetail = table.Column<string>(nullable: true),
                    StartCover = table.Column<string>(nullable: true),
                    EndCover = table.Column<string>(nullable: true),
                    CustName = table.Column<string>(nullable: true),
                    ModelType = table.Column<string>(nullable: true),
                    PlateProvince = table.Column<string>(nullable: true),
                    VehicleChassisNumber = table.Column<string>(nullable: true),
                    VehicleEngineNumber = table.Column<string>(nullable: true),
                    EndosementType = table.Column<string>(nullable: true),
                    ChangeDetails = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    AgentID = table.Column<string>(nullable: true),
                    Branch = table.Column<string>(nullable: true),
                    Approver = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endorsement", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endorsement");
        }
    }
}
