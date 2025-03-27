using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_Lab_ENTITY
{
    public class eTest
    {
        public int? TestId { get; set; }
        public string Name { get; set; }
        public string TestTime { get; set; }
        public string LabName { get; set; }
        public decimal? TestPrice { get; set; }
        public decimal? OtherTestPrice { get; set; }
        public DateTime? DateEntered { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool? IsActive { get; set; }


        public string? ReportHTML { get; set; }
        public int? TestReportSampleID { get; set; }
        
    }
}
