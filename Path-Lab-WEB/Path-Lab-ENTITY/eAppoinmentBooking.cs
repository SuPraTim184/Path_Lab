using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_Lab_ENTITY
{
    public class eAppoinmentBooking
    {
        public string AppointmentBookingID { get; set; }
        public string Specialization { get; set; }
        public int? DoctorId { get; set; }
        public string? DoctorName { get; set; }
        public string? Fees { get; set; }
        public DateTime? BookingDate { get; set; }
        public string? UserID { get; set; }
        public string? PatientId { get; set; }
        public string? PatientName { get; set; }
        public string? PatientGender { get; set; }
        public DateTime? PatientDOB { get; set; }
        public string? PaymentType { get; set; }
        public bool? IsCanceled { get; set; }
        public bool? IsActive { get; set; }
        public string? BookingID { get; set; }
        public string? FullName { get; set; }
        public DateTime? DateEntered { get; set; }
        public bool? Iscancel { get; set; }
        public bool? SuccessfulAppointment { get; set; }
        public string? PaymentDue { get; set; }
        public string? Reason { get; set; }
        public string? Status { get; set; }
        public decimal? DueAmount { get; set; }

        public decimal? TotalPayment { get; set; }
        public decimal? PayAmount { get; set; }
        public string? EntityID { get; set; }
        public string? EntityTypeID { get; set; }



        public string? PatientHeight { get; set; }
        public string? PatientWeight { get; set; }
        public string? PatientBPHigh { get; set; }
        public string? PatientBPLow { get; set; }
        public string? Description { get; set; }
        public string? PatientID { get; set; }
        public List<eMedicine>? MedicineList { get; set; }

        public int? TodayAppointment { get; set; }
        public int? TodayAppointmentCancel { get; set; }
        public int? ThisMonthAppointment { get; set; }
        public int? ThisMonthAppointmentCancel { get; set; }
        public string? AppointmentDate { get; set; }
        public int? AppointmentCount { get; set; }

    }

    public class ePatient
    {
        public string? PatientId { get; set; }
        public string? PatientName { get; set; }
        public string? PatientGender { get; set; }
        public DateTime? PatientDOB { get; set; }
        public int? PatientAge { get; set; }
        public bool? IsActive { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }

    }
    
    public class eAppointmentDetails
    {
        public string? PatientHeight { get; set; }
        public string? PatientWeight { get; set; }
        public string? PatientBPHigh { get; set; }
        public string? PatientBPLow { get; set; }
        public string? Description { get; set; }
        public string? AppointmentBookingID { get; set; }
        public string? BookingID { get; set; }
        public string? PatientID { get; set; }
        public bool? SuccessfulAppointment { get; set; }

        public List<eMedicine>? MedicineList { get; set; }
        public string? pstrXML { get; set; }

        public string? PatientName { get; set; }
        public DateTime? PatientDOB { get; set; }
    }

    public class eMedicine
    {
        public int? PrescriptionMedicineID { get; set; }
        public string? AppointmentBookingID { get; set; }
        public string? BookingID { get; set; }
        public string? MedicineName { get; set; }
        public string? MedicineUsing { get; set; }
        public string? PetientID { get; set; }

    }


    public class ePrescriptionDetails
    {
        public int? PrescriptionID { get; set; }
        public string? PetientID { get; set; }
        public string? AppointmentBookingID { get; set; }
        public string? BookingID { get; set; }
        public string? PatientHeight { get; set; }
        public string? PatientWeight { get; set; }
        public string? PatientBPHigh { get; set; }
        public string? PatientBPLow { get; set; }
        public string? Description { get; set; }

    }


}
