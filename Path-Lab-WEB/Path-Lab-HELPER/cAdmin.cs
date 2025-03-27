using Path_Lab_DL;
using Path_Lab_ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_Lab_HELPER
{
    public class cAdmin
    {
        public static List<eLupUserTypeTable> ManageLupUserType(eLupUserTypeTable BD)
        {
            List<eLupUserTypeTable> ListOut = new List<eLupUserTypeTable>();
            dlAdmin obj = new dlAdmin();
            obj.ManageLupUserType(BD, out ListOut);
            return ListOut;
        }
        public static List<ePaymentDetails> ManagePaymentDetails(ePaymentDetails BD)
        {
            List<ePaymentDetails> ListOut = new List<ePaymentDetails>();
            dlAdmin obj = new dlAdmin();
            obj.ManagePaymentDetails(BD, out ListOut);
            return ListOut;
        }
        public static List<ePaymentTransactionDetails> ManagePaymentTransactionDetails(ePaymentTransactionDetails BD)
        {
            List<ePaymentTransactionDetails> ListOut = new List<ePaymentTransactionDetails>();
            dlAdmin obj = new dlAdmin();
            obj.ManagePaymentTransactionDetails(BD, out ListOut);
            return ListOut;
        }

        public static List<eEmployeePunchDetails> ManageeEmployeePunchDetails(eEmployeePunchDetails RD)
        {
            List<eEmployeePunchDetails> ListOut = new List<eEmployeePunchDetails>();
            dlAdmin obj = new dlAdmin();
            obj.CDManageEmployeePunchDetails(RD, out ListOut);
            return ListOut;
        }

        public static Int32? AddEditEmployeePunchDetails(eEmployeePunchDetails RD)
        {
            Int32? retval;
            dlAdmin obj = new dlAdmin();
            obj.CDAddEditEmployeePunchDetails(RD, out retval);
            return retval;
        }

        public static string UpdateEmployeePunchDetails(eEmployeePunchDetails RD)
        {
            string retval;
            dlAdmin obj = new dlAdmin();
            obj.CDUpdateEmployeePunchDetails(RD, out retval);
            return retval;
        }

        public static List<eEmployeePunchDetails> ManageEmployeePresent(eEmployeePunchDetails RD)
        {
            List<eEmployeePunchDetails> ListOut = new List<eEmployeePunchDetails>();
            dlAdmin obj = new dlAdmin();
            obj.ManageEmployeePresent(RD, out ListOut);
            return ListOut;
        }

        public static List<eTestBookingCancel> ManageCancelTestBooking(eTestBookingCancel BD)
        {
            List<eTestBookingCancel> ListOut = new List<eTestBookingCancel>();
            dlAdmin obj = new dlAdmin();
            obj.ManageCancelTestBooking(BD, out ListOut);
            return ListOut;
        }
        
        public static List<eAppointmentCancel> ManageCancelAppointmentBooking(eAppointmentCancel BD)
        {
            List<eAppointmentCancel> ListOut = new List<eAppointmentCancel>();
            dlAdmin obj = new dlAdmin();
            obj.ManageCancelAppointmentBooking(BD, out ListOut);
            return ListOut;
        }
        
        public static List<eAppoinmentBooking> ManageDashBoardForDoctor(eAppoinmentBooking BD)
        {
            List<eAppoinmentBooking> ListOut = new List<eAppoinmentBooking>();
            dlAdmin obj = new dlAdmin();
            obj.ManageDashBoardForDoctor(BD, out ListOut);
            return ListOut;
        }
        
        public static List<eAppoinmentBooking> Manage7DaysAppointment(eAppoinmentBooking BD)
        {
            List<eAppoinmentBooking> ListOut = new List<eAppoinmentBooking>();
            dlAdmin obj = new dlAdmin();
            obj.Manage7DaysAppointment(BD, out ListOut);
            return ListOut;
        }
        public static List<eDashBoard> GetDataForCalender(eDashBoard BD)
        {
            List<eDashBoard> ListOut = new List<eDashBoard>();
            dlAdmin obj = new dlAdmin();
            obj.GetDataForCalender(BD, out ListOut);
            return ListOut;
        }
        public static List<eTestBooking> ManageForTestChart(eTestBooking BD)
        {
            List<eTestBooking> ListOut = new List<eTestBooking>();
            dlAdmin obj = new dlAdmin();
            obj.ManageForTestChart(BD, out ListOut);
            return ListOut;
        }
        public static List<eTestBooking> ManageForAppointmentChart(eTestBooking BD)
        {
            List<eTestBooking> ListOut = new List<eTestBooking>();
            dlAdmin obj = new dlAdmin();
            obj.ManageForAppointmentChart(BD, out ListOut);
            return ListOut;
        }

         public static List<eDashBoard> DashBoardDetails(eDashBoard BD)
        {
            List<eDashBoard> ListOut = new List<eDashBoard>();
            dlAdmin obj = new dlAdmin();
            obj.DashBoardDetails(BD, out ListOut);
            return ListOut;
        }


    }
}
