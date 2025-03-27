using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_Lab_ENTITY
{
    public class ePaymentDetails
    {
        public int? PaymentID { get; set; }
        public string? EntityID { get; set; }
        public string? EntityTypeID { get; set; }
        public string? PayType { get; set; }
        public decimal? PaymentAmount { get; set; }
        public decimal? DueAmount { get; set; }
        public decimal? PayAmount { get; set; }
        public int? Discount { get; set; }
        public decimal? DiscountAmount { get; set; }
        public DateTime? DateEntered { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? FromDate { get; set; }
        public bool? IsActive { get; set; }
        

    }
    public class ePaymentTransactionDetails
    {
        public int? PaymentTransactionID { get; set; }
        public string? EntityID { get; set; }
        public string? EntityTypeID { get; set; }
        public decimal? PayAmount { get; set; }
        public DateTime? DateEntered { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? FromDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
