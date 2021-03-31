using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadExcelFiles.Models
{
    [Table("Endorsement")]
    public class Endorsement
    {
        [Key]
        public int Id { get; set; }
        public string RefNumber { get; set; }
        public string PolicyNumber { get; set; }
        public string ProductDetail { get; set; }
        public string StartCover { get; set; }
        public string EndCover { get; set; }
        public string CustName { get; set; }
        public string ModelType { get; set; }
        public string PlateProvince { get; set; }
        public string VehicleChassisNumber { get; set; }
        public string VehicleEngineNumber { get; set; }
        public string EndosementType { get; set; }
        public string ChangeDetails { get; set; }
        public string Remark { get; set; }
        public string Status { get; set; }
        public string AgentID { get; set; }
        public string Branch { get; set; }
        public string Approver { get; set; }
    }
}
