using Path_Lab_DL;
using Path_Lab_ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_Lab_HELPER
{
    public class cAppointmentBooking
    {
        public static string AddEditAppointmentBooking(eAppoinmentBooking AB)
        {
            string vRetId = String.Empty;
            dlAppointmentBooking obj = new dlAppointmentBooking();
            obj.AddEditAppointmentBooking(AB, out vRetId);
            return vRetId;
        }
        public static string AddEditTestReport(eTestBooking AB)
        {
            string vRetId = String.Empty;
            dlAppointmentBooking obj = new dlAppointmentBooking();
            obj.AddEditTestReport(AB, out vRetId);
            return vRetId;
        }
        
        public static string AddAppointmentCancel(eAppoinmentBooking AB)
        {
            string vRetId = String.Empty;
            dlAppointmentBooking obj = new dlAppointmentBooking();
            obj.AddAppointmentCancel(AB, out vRetId);
            return vRetId;
        }
        
        public static string AddTestCancel(eTestBooking AB)
        {
            string vRetId = String.Empty;
            dlAppointmentBooking obj = new dlAppointmentBooking();
            obj.AddTestCancel(AB, out vRetId);
            return vRetId;
        }
        
        public static string AddEditAppointmentBookingByEmployee(eAppoinmentBooking AB)
        {
            string vRetId = String.Empty;
            dlAppointmentBooking obj = new dlAppointmentBooking();
            obj.AddEditAppointmentBookingByEmployee(AB, out vRetId);
            return vRetId;
        }

        public static List<eAppoinmentBooking> ManageAppointmentBooking(eAppoinmentBooking BD)
        {
            List<eAppoinmentBooking> ListOut = new List<eAppoinmentBooking>();
            dlAppointmentBooking obj = new dlAppointmentBooking();
            obj.ManageAppointmentBooking(BD, out ListOut);
            return ListOut;
        }
        
        public static List<eAppoinmentBooking> ManageAppointmentBookingForPrescription(eAppoinmentBooking BD)
        {
            List<eAppoinmentBooking> ListOut = new List<eAppoinmentBooking>();
            dlAppointmentBooking obj = new dlAppointmentBooking();
            obj.ManageAppointmentBookingForPrescription(BD, out ListOut);
            return ListOut;
        }
        
        public static List<eAppoinmentBooking> ManageAppointmentBookingByID(eAppoinmentBooking BD)
        {
            List<eAppoinmentBooking> ListOut = new List<eAppoinmentBooking>();
            dlAppointmentBooking obj = new dlAppointmentBooking();
            obj.ManageAppointmentBookingByID(BD, out ListOut);
            return ListOut;
        }
        
        public static List<ePrescriptionDetails> ManagePrescriptionDetails(ePrescriptionDetails BD)
        {
            List<ePrescriptionDetails> ListOut = new List<ePrescriptionDetails>();
            dlAppointmentBooking obj = new dlAppointmentBooking();
            obj.ManagePrescriptionDetails(BD, out ListOut);
            return ListOut;
        }
        
        public static List<eMedicine> ManagePrescriptionMedicine(eMedicine BD)
        {
            List<eMedicine> ListOut = new List<eMedicine>();
            dlAppointmentBooking obj = new dlAppointmentBooking();
            obj.ManagePrescriptionMedicine(BD, out ListOut);
            return ListOut;
        }


        public static string AddEditTestBooking(eTestBooking AB)
        {
            string vRetId = String.Empty;
            dlAppointmentBooking obj = new dlAppointmentBooking();
            obj.AddEditTestBooking(AB, out vRetId);
            return vRetId;
        }
        
        public static string AddEditTestBookingByEmployee(eTestBooking AB)
        {
            string vRetId = String.Empty;
            dlAppointmentBooking obj = new dlAppointmentBooking();
            obj.AddEditTestBookingByEmployee(AB, out vRetId);
            return vRetId;
        }
        
        public static string AddEditPrescriptionDetails(eAppointmentDetails AB)
        {
            string vRetId = String.Empty;
            dlAppointmentBooking obj = new dlAppointmentBooking();
            obj.AddEditPrescriptionDetails(AB, out vRetId);
            return vRetId;
        }


        public static List<eTestBooking> ManageTestBooking(eTestBooking BD)
        {
            List<eTestBooking> ListOut = new List<eTestBooking>();
            dlAppointmentBooking obj = new dlAppointmentBooking();
            obj.ManageTestBooking(BD, out ListOut);
            return ListOut;
        }
        
        public static List<eTestBooking> ManageTestBookingDetails(eTestBooking BD)
        {
            List<eTestBooking> ListOut = new List<eTestBooking>();
            dlAppointmentBooking obj = new dlAppointmentBooking();
            obj.ManageTestBookingDetails(BD, out ListOut);
            return ListOut;
        }
        
        public static List<eTestBooking> ManageTestReport(eTestBooking BD)
        {
            List<eTestBooking> ListOut = new List<eTestBooking>();
            dlAppointmentBooking obj = new dlAppointmentBooking();
            obj.ManageTestReport(BD, out ListOut);
            return ListOut;
        }

        public static string AddPaymentTransactionDeatilsForTest(eTestBooking AB)
        {
            string vRetId = String.Empty;
            dlAppointmentBooking obj = new dlAppointmentBooking();
            obj.AddPaymentTransactionDeatilsForTest(AB, out vRetId);
            return vRetId;
        }
        
        public static string AddPaymentTransactionDeatilsForAppointment(eAppoinmentBooking AB)
        {
            string vRetId = String.Empty;
            dlAppointmentBooking obj = new dlAppointmentBooking();
            obj.AddPaymentTransactionDeatilsForAppointment(AB, out vRetId);
            return vRetId;
        }


    }
}
