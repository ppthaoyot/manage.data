using Microsoft.EntityFrameworkCore.Migrations;

namespace ReadExcelFiles.Migrations
{
    public partial class DB03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Motors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyType = table.Column<string>(nullable: true),
                    AppId = table.Column<string>(nullable: true),
                    PolicyNumber = table.Column<string>(nullable: true),
                    ProductGroupDetail = table.Column<string>(nullable: true),
                    ProductDetail = table.Column<string>(nullable: true),
                    ProductTypeDetail = table.Column<string>(nullable: true),
                    Premium = table.Column<string>(nullable: true),
                    MotorApplicationClaimTypeDetail = table.Column<string>(nullable: true),
                    PolicyStartDate = table.Column<string>(nullable: true),
                    CoveragePeriodStart = table.Column<string>(nullable: true),
                    CoveragePeriodEnd = table.Column<string>(nullable: true),
                    InsuredTitle = table.Column<string>(nullable: true),
                    InsuredFirstName = table.Column<string>(nullable: true),
                    InsuredLastName = table.Column<string>(nullable: true),
                    InsuredPhone = table.Column<string>(nullable: true),
                    InsuredAddress = table.Column<string>(nullable: true),
                    InsuredStreetNo = table.Column<string>(nullable: true),
                    InsuredSubdistrict = table.Column<string>(nullable: true),
                    InsuredDistrict = table.Column<string>(nullable: true),
                    InsuredProvince = table.Column<string>(nullable: true),
                    InsuredPostalCode = table.Column<string>(nullable: true),
                    InsuredIdentityCard = table.Column<string>(nullable: true),
                    InsuredPassport = table.Column<string>(nullable: true),
                    InsuredWorkAddressProvinceID = table.Column<string>(nullable: true),
                    InsuredWorkAddressDistrictID = table.Column<string>(nullable: true),
                    InsuredWorkAddressSubDistrictID = table.Column<string>(nullable: true),
                    PayerTitle = table.Column<string>(nullable: true),
                    PayerFirstName = table.Column<string>(nullable: true),
                    PayerLastName = table.Column<string>(nullable: true),
                    PayerPhoneNo = table.Column<string>(nullable: true),
                    PayerBuildingName = table.Column<string>(nullable: true),
                    PayerAddress = table.Column<string>(nullable: true),
                    PayerStreetNo = table.Column<string>(nullable: true),
                    PayerSubdistrict = table.Column<string>(nullable: true),
                    PayerDistrict = table.Column<string>(nullable: true),
                    PayerProvince = table.Column<string>(nullable: true),
                    PayerPostalCode = table.Column<string>(nullable: true),
                    PayerBankAccount = table.Column<string>(nullable: true),
                    PayerBankName = table.Column<string>(nullable: true),
                    PayerIdentityCard = table.Column<string>(nullable: true),
                    PayerPassport = table.Column<string>(nullable: true),
                    PayerWorkAddressProvinceID = table.Column<string>(nullable: true),
                    PayerWorkAddressProvinceDetail = table.Column<string>(nullable: true),
                    PayerWorkAddressDistrictID = table.Column<string>(nullable: true),
                    PayerWorkAddressDistrictDetail = table.Column<string>(nullable: true),
                    PayerWorkAddressSubDistrictID = table.Column<string>(nullable: true),
                    PayerWorkAddressSubDistrictDetail = table.Column<string>(nullable: true),
                    MotorApplicationStatusDetail = table.Column<string>(nullable: true),
                    PeriodTypeDetail = table.Column<string>(nullable: true),
                    CountingPaidNumber = table.Column<string>(nullable: true),
                    PayMethodTypeDetail = table.Column<string>(nullable: true),
                    PayerBankDetail = table.Column<string>(nullable: true),
                    PersonBankAccountNo = table.Column<string>(nullable: true),
                    VehicleModelDetail = table.Column<string>(nullable: true),
                    VehicleBrandDetail = table.Column<string>(nullable: true),
                    VehicleRegistrationDetail = table.Column<string>(nullable: true),
                    VehicleRegistrationNumber = table.Column<string>(nullable: true),
                    VehicleRegistrationProvince = table.Column<string>(nullable: true),
                    VehicleYear = table.Column<string>(nullable: true),
                    VehicleChassisNumber = table.Column<string>(nullable: true),
                    SumInsured = table.Column<string>(nullable: true),
                    VehicleSeat = table.Column<string>(nullable: true),
                    VehicleWeight = table.Column<string>(nullable: true),
                    VehicleCC = table.Column<string>(nullable: true),
                    SaleID = table.Column<string>(nullable: true),
                    CarOwnerID = table.Column<string>(nullable: true),
                    Branch = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<string>(nullable: true),
                    PreviousPolicyNumber = table.Column<string>(nullable: true),
                    PolicyIssuedDate = table.Column<string>(nullable: true),
                    PolicyCreatedDate = table.Column<string>(nullable: true),
                    CancelledByEmployeeCode = table.Column<string>(nullable: true),
                    CancelledDate = table.Column<string>(nullable: true),
                    CancelledReason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motors", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Motors");
        }
    }
}
