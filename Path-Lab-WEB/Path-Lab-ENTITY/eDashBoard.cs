using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_Lab_ENTITY
{
    public class eDashBoard
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? TransactionDate { get; set; }
        public Decimal? TotalPayAmount { get; set; }
        public int? TotalAppointment { get; set; }
        public int? TotalTestBooking { get; set; }


        public int? MonthlyDue { get; set; }
        public int? MonthlyPay { get; set; }
        public int? YearlyDue { get; set; }
        public int? YearlyPay { get; set; }
        public int? YearlyBookingAppointment { get; set; }
        public int? YearlyCancelledAppointment { get; set; }
        public int? MonthlyPendingAppointment { get; set; }
        public int? MonthlyCancelledAppointment { get; set; }
    }
}
