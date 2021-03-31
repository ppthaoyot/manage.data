using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadExcelFiles.Models
{

    [Table("CollectionAgent")]
    public class Agent
    {
        [Key]
        public int Id { get; set; }
        public string AgentCode { get; set; }
        public string AgentName { get; set; }
        public string BranchTeam { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Bank { get; set; }
        public string BankAccountNo { get; set; }
        public string StatementID { get; set; }
        public string StatementFrom { get; set; }
        public string StatementTo { get; set; }
        public DateTime BillingDate { get; set; }
        public DateTime CollectionDate { get; set; }
        public Double Amount { get; set; }
        public string PayMode { get; set; }
        public string FailureReason { get; set; }
    }
}
