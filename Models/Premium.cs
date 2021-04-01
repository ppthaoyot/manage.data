using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadExcelFiles.Models
{
    [Table("Premium")]
    public class Premium
    {
        [Key]
        public int Id { get; set; }
        public string Insurer { get; set; }
        public string Product { get; set; }
        public string Plan { get; set; }
        public string Agent { get; set; }
        public string Branch { get; set; }
        public string PayerName { get; set; }
        public string PayerID { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string AddressType { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Subdistrict { get; set; }
        public string StreetAddress { get; set; }
        public string Insuredname { get; set; }
        public string QuotationNo { get; set; }
        public string PolicyNo { get; set; }
        public DateTime? PolicyIssueDate { get; set; }
        public DateTime BillingDate { get; set; }
        public DateTime CollectionDate { get; set; }
        public DateTime CoverageDateFrom { get; set; }
        public DateTime CoverageDateTo { get; set; }
        public string PremiumType { get; set; }
        public string PayMode { get; set; }
        public string PaymentStatus { get; set; }
        public string FailReasons { get; set; }
        public string GrossPremium { get; set; }
        public string VAT { get; set; }
        public string StampDuty { get; set; }
        public string TotalAmount { get; set; }
        public string BankHolderName { get; set; }
        public string BankName { get; set; }
        public string BankNumber { get; set; }
    }
}