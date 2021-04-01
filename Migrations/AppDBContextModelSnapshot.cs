﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReadExcelFiles.Data;

namespace ReadExcelFiles.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReadExcelFiles.Models.Agent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AgentCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AgentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("Bank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankAccountNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BillingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BranchTeam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CollectionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CollectionStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FailureReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayMode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatementFrom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatementID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatementTo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CollectionAgent");
                });

            modelBuilder.Entity("ReadExcelFiles.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Agent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankHolderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BillingDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Branch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CollectionDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverageDateFrom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverageDateTo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FailReasons")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GrossPremium")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Insuredname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Insurer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayMode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Plan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PolicyIssueDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PolicyNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PremiumType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Product")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuotationNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StampDuty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subdistrict")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TotalAmount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VAT")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CollectionCustomer");
                });

            modelBuilder.Entity("ReadExcelFiles.Models.DBMotor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Branch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CancelledByEmployeeCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CancelledDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CancelledReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarOwnerID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountingPaidNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoveragePeriodEnd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoveragePeriodStart")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDateConvert")
                        .HasColumnType("datetime2");

                    b.Property<string>("InsuredAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuredDistrict")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuredFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuredIdentityCard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuredLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuredPassport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuredPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuredPostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuredProvince")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuredStreetNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuredSubdistrict")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuredTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuredWorkAddressDistrictID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuredWorkAddressProvinceID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuredWorkAddressSubDistrictID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LatestUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MotorApplicationClaimTypeDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotorApplicationStatusDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayMethodTypeDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerBankAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerBankDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerBankName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerBuildingName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerDistrict")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerIdentityCard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerPassport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerPhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerPostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerProvince")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerStreetNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerSubdistrict")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerWorkAddressDistrictDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerWorkAddressDistrictID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerWorkAddressProvinceDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerWorkAddressProvinceID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerWorkAddressSubDistrictDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerWorkAddressSubDistrictID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PeriodTypeDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonBankAccountNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PolicyCreatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PolicyIssuedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PolicyNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PolicyStartDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PolicyType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Premium")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreviousPolicyNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductGroupDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductTypeDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SaleID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SaleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDateConvert")
                        .HasColumnType("datetime2");

                    b.Property<string>("SumInsured")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleBrandDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleCC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleChassisNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleModelDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleRegistrationDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleRegistrationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleRegistrationProvince")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleSeat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleWeight")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleYear")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DBMotor");
                });

            modelBuilder.Entity("ReadExcelFiles.Models.Endorsement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AgentID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Approver")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Branch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChangeDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EndCover")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EndosementType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModelType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlateProvince")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PolicyNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartCover")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleChassisNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleEngineNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Endorsement");
                });

            modelBuilder.Entity("ReadExcelFiles.Models.Motor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Branch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CancelledByEmployeeCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CancelledDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CancelledReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarOwnerID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountingPaidNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoveragePeriodEnd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoveragePeriodStart")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDateConvert")
                        .HasColumnType("datetime2");

                    b.Property<string>("InsuredAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuredDistrict")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuredFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuredIdentityCard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuredLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuredPassport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuredPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuredPostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuredProvince")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuredStreetNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuredSubdistrict")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuredTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuredWorkAddressDistrictID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuredWorkAddressProvinceID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuredWorkAddressSubDistrictID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotorApplicationClaimTypeDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotorApplicationStatusDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayMethodTypeDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerBankAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerBankDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerBankName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerBuildingName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerDistrict")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerIdentityCard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerPassport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerPhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerPostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerProvince")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerStreetNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerSubdistrict")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerWorkAddressDistrictDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerWorkAddressDistrictID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerWorkAddressProvinceDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerWorkAddressProvinceID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerWorkAddressSubDistrictDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerWorkAddressSubDistrictID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PeriodTypeDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonBankAccountNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PolicyCreatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PolicyIssuedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PolicyNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PolicyStartDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PolicyType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Premium")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreviousPolicyNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductGroupDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductTypeDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SaleID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDateConvert")
                        .HasColumnType("datetime2");

                    b.Property<string>("SumInsured")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleBrandDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleCC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleChassisNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleModelDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleRegistrationDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleRegistrationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleRegistrationProvince")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleSeat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleWeight")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleYear")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Motors");
                });

            modelBuilder.Entity("ReadExcelFiles.Models.Premium", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Agent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankHolderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BillingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Branch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CollectionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CoverageDateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CoverageDateTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FailReasons")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GrossPremium")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Insuredname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Insurer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayMode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Plan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PolicyIssueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PolicyNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PremiumType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Product")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuotationNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StampDuty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subdistrict")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TotalAmount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VAT")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Premium");
                });
#pragma warning restore 612, 618
        }
    }
}
