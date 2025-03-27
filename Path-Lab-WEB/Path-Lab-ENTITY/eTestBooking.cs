using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_Lab_ENTITY
{
    public class eTestBooking
    {
        public string? TestBookingId { get; set; }
        public int? TestId { get; set; }
        public DateTime? BookingDate { get; set; }
        public DateTime? TestBookingDate { get; set; }
        public Decimal? TestPrice { get; set; }
        public string? BookingId { get; set; }
        public string? BookingIDNew { get; set; }
        public DateTime? DateEntered { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool? IsActive { get; set; }
        public string? UserID { get; set; }
        public string? UserName { get; set; }
        public decimal? Fees { get; set; }
        public string? PaymentType { get; set; }
        public bool? IsCanceled { get; set; }
        public List<eTest>? TestList { get; set; }
        public string? pstrXML { get; set; }
        public string? BookingID { get; set; }
        public string? PaymentDue { get; set; }
        public string? Reason { get; set; }
        public int? TestBookingDetailsID { get; set; }
        public string? TestName { get; set; }
        public decimal? TotalFees { get; set; }
        public decimal? TotalPayment { get; set; }
        public decimal? PayAmount { get; set; }
        public string? EntityID { get; set; }
        public string? EntityTypeID { get; set; }
        public string? PrimaryPhone { get; set; }



        public string? PatientId { get; set; }
        public string? PatientName { get; set; }
        public string? PatientGender { get; set; }
        public DateTime? PatientDOB { get; set; }
        public int? PatientAge { get; set; }
        public string? Status { get; set; }
        public decimal? DueAmount { get; set; }





        public string? ReportHTML { get; set; }
        public string? TestReportHTML { get; set; }
        public int? TestReportID { get; set; }



        public string? period { get; set; }
        public string? Name { get; set; }
        public int? TotalTest { get; set; }
        
        

    }
}
