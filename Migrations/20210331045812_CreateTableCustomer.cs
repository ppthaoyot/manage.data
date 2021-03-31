using Microsoft.EntityFrameworkCore.Migrations;

namespace ReadExcelFiles.Migrations
{
    public partial class CreateTableCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CollectionCustomer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Insurer = table.Column<string>(nullable: true),
                    Product = table.Column<string>(nullable: true),
                    Plan = table.Column<string>(nullable: true),
                    Agent = table.Column<string>(nullable: true),
                    Branch = table.Column<string>(nullable: true),
                    PayerName = table.Column<string>(nullable: true),
                    PayerID = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    AddressType = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    Subdistrict = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    Insuredname = table.Column<string>(nullable: true),
                    QuotationNo = table.Column<string>(nullable: true),
                    PolicyNo = table.Column<string>(nullable: true),
                    PolicyIssueDate = table.Column<string>(nullable: true),
                    BillingDate = table.Column<string>(nullable: true),
                    CollectionDate = table.Column<string>(nullable: true),
                    CoverageDateFrom = table.Column<string>(nullable: true),
                    CoverageDateTo = table.Column<string>(nullable: true),
                    PremiumType = table.Column<string>(nullable: true),
                    PayMode = table.Column<string>(nullable: true),
                    PaymentStatus = table.Column<string>(nullable: true),
                    FailReasons = table.Column<string>(nullable: true),
                    GrossPremium = table.Column<string>(nullable: true),
                    VAT = table.Column<string>(nullable: true),
                    StampDuty = table.Column<string>(nullable: true),
                    TotalAmount = table.Column<string>(nullable: true),
                    BankHolderName = table.Column<string>(nullable: true),
                    BankName = table.Column<string>(nullable: true),
                    BankNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionCustomer", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectionCustomer");
        }
    }
}
