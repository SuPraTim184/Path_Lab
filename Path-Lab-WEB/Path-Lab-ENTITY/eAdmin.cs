using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_Lab_ENTITY
{
    public class eEmployeePunchDetails
    {
        public int? EmployeePunchDetailsId { get; set; }
        public string EmployeeId { get; set; }
        public DateTime? punchInTime { get; set; }
        public DateTime? PunchoutTime { get; set; }
        public string ClientIP { get; set; }
        public string LoginCountry { get; set; }
        public string LoginDevice { get; set; }
        public string ActorID { get; set; }
        public bool? IsLoginSuccess { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByName { get; set; }
        public string Attendance { get; set; }
        public string AttendanceStatus { get; set; }
        public string EmployeeName { get; set; }
        public string ImagePath { get; set; }

        public Int32? time_diff { get; set; }

        public string LoginDeviceOs { get; set; }
        public string ClientIPV6 { get; set; }
        public string ClientMac { get; set; }
        public string LoginDeviceType { get; set; }
        public string LoginDeviceName { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }

    public class eTestBookingCancel
    {
        public string? TestBookingID { get; set; }
        public string? BookingID { get; set; }
        public string? Reason { get; set; }
        public DateTime? TestCancelDate { get; set; }
        public string? UserID { get; set; }
        public string? FullName { get; set; }
        public string? PrimaryEmail { get; set; }
        public string? PrimaryPhone { get; set; }
        public string? PatientID { get; set; }
        public string? PatientName { get; set; }
        public string? Gender { get; set; }
        public DateTime? BookingDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? FromDate { get; set; }
    }
    public class eAppointmentCancel
    {
        public string? AppointmentBookingID { get; set; }
        public string? BookingID { get; set; }
        public string? Reason { get; set; }
        public DateTime? AppointmentCancelDate { get; set; }
        public string? UserID { get; set; }
        public string? FullName { get; set; }
        public string? PrimaryEmail { get; set; }
        public string? PrimaryPhone { get; set; }
        public string? PatientID { get; set; }
        public string? PatientName { get; set; }
        public string? Gender { get; set; }
        public DateTime? BookingDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? FromDate { get; set; }
    }
}
