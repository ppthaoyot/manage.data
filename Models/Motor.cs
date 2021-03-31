using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadExcelFiles.Models
{
    [Table("Motors")]
    public class Motor
    {
        [Key]
        public int Id { get; set; }
        public string PolicyType { get; set; }
        public string AppId { get; set; }
        public string PolicyNumber { get; set; }
        public string ProductGroupDetail { get; set; }
        public string ProductDetail { get; set; }
        public string ProductTypeDetail { get; set; }
        public string Premium { get; set; }
        public string MotorApplicationClaimTypeDetail { get; set; }
        public string PolicyStartDate { get; set; }
        public string CoveragePeriodStart { get; set; }
        public string CoveragePeriodEnd { get; set; }
        public string InsuredTitle { get; set; }
        public string InsuredFirstName { get; set; }
        public string InsuredLastName { get; set; }
        public string InsuredPhone { get; set; }
        public string InsuredAddress { get; set; }
        public string InsuredStreetNo { get; set; }
        public string InsuredSubdistrict { get; set; }
        public string InsuredDistrict { get; set; }
        public string InsuredProvince { get; set; }
        public string InsuredPostalCode { get; set; }
        public string InsuredIdentityCard { get; set; }
        public string InsuredPassport { get; set; }
        public string InsuredWorkAddressProvinceID { get; set; }
        public string InsuredWorkAddressDistrictID { get; set; }
        public string InsuredWorkAddressSubDistrictID { get; set; }
        public string PayerTitle { get; set; }
        public string PayerFirstName { get; set; }
        public string PayerLastName { get; set; }
        public string PayerPhoneNo { get; set; }
        public string PayerBuildingName { get; set; }
        public string PayerAddress { get; set; }
        public string PayerStreetNo { get; set; }
        public string PayerSubdistrict { get; set; }
        public string PayerDistrict { get; set; }
        public string PayerProvince { get; set; }
        public string PayerPostalCode { get; set; }
        public string PayerBankAccount { get; set; }
        public string PayerBankName { get; set; }
        public string PayerIdentityCard { get; set; }
        public string PayerPassport { get; set; }
        public string PayerWorkAddressProvinceID { get; set; }
        public string PayerWorkAddressProvinceDetail { get; set; }
        public string PayerWorkAddressDistrictID { get; set; }
        public string PayerWorkAddressDistrictDetail { get; set; }
        public string PayerWorkAddressSubDistrictID { get; set; }
        public string PayerWorkAddressSubDistrictDetail { get; set; }
        public string MotorApplicationStatusDetail { get; set; }
        public string PeriodTypeDetail { get; set; }
        public string CountingPaidNumber { get; set; }
        public string PayMethodTypeDetail { get; set; }
        public string PayerBankDetail { get; set; }
        public string PersonBankAccountNo { get; set; }
        public string VehicleModelDetail { get; set; }
        public string VehicleBrandDetail { get; set; }
        public string VehicleRegistrationDetail { get; set; }
        public string VehicleRegistrationNumber { get; set; }
        public string VehicleRegistrationProvince { get; set; }
        public string VehicleYear { get; set; }
        public string VehicleChassisNumber { get; set; }
        public string SumInsured { get; set; }
        public string VehicleSeat { get; set; }
        public string VehicleWeight { get; set; }
        public string VehicleCC { get; set; }
        public string SaleID { get; set; }
        public string CarOwnerID { get; set; }
        public string Branch { get; set; }
        public string CreatedDate { get; set; }
        public string PreviousPolicyNumber { get; set; }
        public string PolicyIssuedDate { get; set; }
        public string PolicyCreatedDate { get; set; }
        public string CancelledByEmployeeCode { get; set; }
        public string CancelledDate { get; set; }
        public string CancelledReason { get; set; }
        public DateTime StartDateConvert { get; set; }
        public DateTime EndDateConvert { get; set; }

    }
}