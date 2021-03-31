using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReadExcelFiles.Migrations
{
    public partial class CreateTableAgent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CollectionAgent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentCode = table.Column<string>(nullable: true),
                    AgentName = table.Column<string>(nullable: true),
                    BranchTeam = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Bank = table.Column<string>(nullable: true),
                    BankAccountNo = table.Column<string>(nullable: true),
                    StatementID = table.Column<string>(nullable: true),
                    StatementFrom = table.Column<string>(nullable: true),
                    StatementTo = table.Column<string>(nullable: true),
                    BillingDate = table.Column<DateTime>(nullable: false),
                    CollectionDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    PayMode = table.Column<string>(nullable: true),
                    FailureReason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionAgent", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectionAgent");
        }
    }
}
