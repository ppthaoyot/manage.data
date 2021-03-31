using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadExcelFiles.Models
{
    public class DBMotorUpdate
    {
        [Key]
        public int Id { get; set; }
        public string CoveragePeriodStart { get; set; }
        public string CoveragePeriodEnd { get; set; }
        public DateTime StartDateConvert { get; set; }
        public DateTime EndDateConvert { get; set; }
        public DateTime LatestUpdate { get; set; }

    }
}