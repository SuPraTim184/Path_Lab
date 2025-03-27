using Path_Lab_DS;
using Path_Lab_ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_Lab_DL
{
    public class dlAdmin
    {
        public void ManageLupUserType(eLupUserTypeTable RD, out List<eLupUserTypeTable> ListOut)
        {
            try
            {

                DBAccess objDbAccess = new DBAccess();
                string SP = "ManageLupUserType";
                SqlParameter[] spc = new SqlParameter[4];

                spc[0] = new SqlParameter("@LupUserTypeID", RD.LupUserTypeId);
                spc[1] = new SqlParameter("@UserTypeID", RD.UserTypeId);
                spc[2] = new SqlParameter("@UserTypeName", RD.UserTypeName);
                spc[3] = new SqlParameter("@IsActive", RD.IsActive);

                DataSet ds = objDbAccess.getDataSet(SP, spc);
                ListOut = (from r in ds.Tables[0].AsEnumerable()

                           select new eLupUserTypeTable
                           {
                               LupUserTypeId = r.Field<Int32?>("LupUserTypeID"),
                               UserTypeId = r.Field<Int32?>("UserTypeID"),
                               UserTypeName = r.Field<string?>("UserTypeName"),
                               IsActive = r.Field<bool?>("IsActive"),
                               
                           }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ManagePaymentDetails(ePaymentDetails RD, out List<ePaymentDetails> ListOut)
        {
            try
            {

                DBAccess objDbAccess = new DBAccess();
                string SP = "ManagePaymentDetails";
                SqlParameter[] spc = new SqlParameter[4];

                spc[0] = new SqlParameter("@EntityTypeID", RD.EntityTypeID);
                spc[1] = new SqlParameter("@ToDate", RD.ToDate);
                spc[2] = new SqlParameter("@FromDate", RD.FromDate);
                spc[3] = new SqlParameter("@PayType", RD.PayType);

                DataSet ds = objDbAccess.getDataSet(SP, spc);
                ListOut = (from r in ds.Tables[0].AsEnumerable()

                           select new ePaymentDetails
                           {
                               PaymentID = r.Field<Int32?>("PaymentID"),
                               EntityID = r.Field<string?>("EntityID"),
                               EntityTypeID = r.Field<string?>("EntityTypeID"),
                               PayType = r.Field<string?>("PayType"),
                               PaymentAmount = r.Field<decimal?>("PaymentAmount"),
                               DueAmount = r.Field<decimal?>("DueAmount"),
                               PayAmount = r.Field<decimal?>("PayAmount"),
                               Discount = r.Field<Int32?>("Discount"),
                               DiscountAmount = r.Field<decimal?>("DiscountAmount"),
                               DateEntered = r.Field<DateTime?>("DateEntered"),                               
                               IsActive = r.Field<bool?>("IsActive"),
                               
                           }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public void ManagePaymentTransactionDetails(ePaymentTransactionDetails RD, out List<ePaymentTransactionDetails> ListOut)
        {
            try
            {

                DBAccess objDbAccess = new DBAccess();
                string SP = "ManagePaymentTransactionDetails";
                SqlParameter[] spc = new SqlParameter[2];
                                
                spc[0] = new SqlParameter("@ToDate", RD.ToDate);
                spc[1] = new SqlParameter("@FromDate", RD.FromDate);
                
                DataSet ds = objDbAccess.getDataSet(SP, spc);
                ListOut = (from r in ds.Tables[0].AsEnumerable()
                           select new ePaymentTransactionDetails
                           {
                               PaymentTransactionID = r.Field<int?>("PaymentTransactionID"),
                               EntityID = r.Field<string?>("EntityID"),
                               EntityTypeID = r.Field<string?>("EntityTypeID"),                               
                               PayAmount = r.Field<decimal?>("PayAmount"),
                               DateEntered = r.Field<DateTime?>("DateEntered"),                               
                               IsActive = r.Field<bool?>("IsActive"),                               
                           }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CDManageEmployeePunchDetails(eEmployeePunchDetails CD, out List<eEmployeePunchDetails> ListOut)
        {
            try
            {

                DBAccess objDbAccess = new DBAccess();
                string SP = "ManageEmployeePunchDetails";

                SqlParameter[] spc = new SqlParameter[7];
                spc[0] = new SqlParameter("@EmployeePunchDetailsId", CD.EmployeePunchDetailsId);
                spc[1] = new SqlParameter("@EmployeeId", CD.EmployeeId);
                spc[2] = new SqlParameter("@punchInTime", CD.punchInTime);
                spc[3] = new SqlParameter("@PunchoutTime", CD.PunchoutTime);
                spc[4] = new SqlParameter("@ClientIP", CD.ClientIP);
                spc[5] = new SqlParameter("@LoginDevice", CD.LoginDevice);
                spc[6] = new SqlParameter("@IsLoginSuccess", CD.IsLoginSuccess);

                DataSet ds = objDbAccess.getDataSet(SP, spc);
                ListOut = (from r in ds.Tables[0].AsEnumerable()

                           select new eEmployeePunchDetails
                           {
                               EmployeePunchDetailsId = r.Field<int?>("EmployeePunchDetailsId"),
                               EmployeeId = r.Field<string>("EmployeeId"),
                               punchInTime = r.Field<DateTime?>("punchInTime"),
                               PunchoutTime = r.Field<DateTime?>("PunchoutTime"),
                               ClientIP = r.Field<string>("ClientIP"),                               
                               LoginDevice = r.Field<string>("LoginDevice"),
                               IsLoginSuccess = r.Field<bool?>("IsLoginSuccess"),                               
                               time_diff = r.Field<Int32?>("time_diff"),
                           }).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public void CDAddEditEmployeePunchDetails(eEmployeePunchDetails lst, out Int32? oRetId)
        {
            try
            {
                DataSet ds = null;

                DBAccess objDbAccess = new DBAccess();
                string SP = "AddEditEmployeePunchDetails";
                SqlParameter[] spc = new SqlParameter[11];
                spc[0] = new SqlParameter("@EmployeePunchDetailsId", lst.EmployeePunchDetailsId);
                spc[1] = new SqlParameter("@EmployeeId", lst.EmployeeId);
                spc[2] = new SqlParameter("@ClientIP", lst.ClientIP);
                spc[3] = new SqlParameter("@LoginDevice", lst.LoginDevice);
                spc[4] = new SqlParameter("@IsLoginSuccess", lst.IsLoginSuccess);
                spc[5] = new SqlParameter("@ActorID", lst.ActorID);
                spc[6] = new SqlParameter("@IsActive", lst.IsActive);
                spc[7] = new SqlParameter("@ClientIPV6", lst.ClientIPV6);
                spc[8] = new SqlParameter("@ClientMac", lst.ClientMac);
                spc[9] = new SqlParameter("@LoginDeviceName", lst.LoginDeviceName);
                spc[10] = new SqlParameter("@LoginDeviceOs", lst.LoginDeviceOs);

                ds = objDbAccess.getDataSet(SP, spc);
                oRetId = Convert.ToInt32(ds.Tables[0].Rows[0]["EmployeePunchDetailsId"].ToString());

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void CDUpdateEmployeePunchDetails(eEmployeePunchDetails lst, out string oRetId)
        {
            try
            {
                DataSet ds = null;

                DBAccess objDbAccess = new DBAccess();
                string SP = "UpdateEmployeePunchDetails";
                SqlParameter[] spc = new SqlParameter[3];

                spc[0] = new SqlParameter("@EmployeeId", lst.EmployeeId);
                spc[1] = new SqlParameter("@punchInTime", lst.punchInTime);
                spc[2] = new SqlParameter("@ActorID", lst.ActorID);


                ds = objDbAccess.getDataSet(SP, spc);
                oRetId = ds.Tables[0].Rows[0]["EmployeePunchDetailsId"].ToString();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ManageEmployeePresent(eEmployeePunchDetails CD, out List<eEmployeePunchDetails> ListOut)
        {
            try
            {

                DBAccess objDbAccess = new DBAccess();
                string SP = "GetEmployeeAttendanceStatus";

                SqlParameter[] spc = new SqlParameter[3];
                spc[0] = new SqlParameter("@EmployeeId", CD.EmployeeId);
                spc[1] = new SqlParameter("@EmployeeName", CD.EmployeeName);
                spc[2] = new SqlParameter("@punchInTime", CD.punchInTime);


                DataSet ds = objDbAccess.getDataSet(SP, spc);
                ListOut = (from r in ds.Tables[0].AsEnumerable()

                           select new eEmployeePunchDetails
                           {
                               //EmployeePunchDetailsId = r.Field<int?>("EmployeePunchDetailsId"),
                               //EmployeeId = r.Field<Int32?>("EmployeeId").ToString(),
                               EmployeeName = r.Field<string>("EmployeeName"),
                               punchInTime = r.Field<DateTime?>("punchInTime"),
                               PunchoutTime = r.Field<DateTime?>("PunchoutTime"),
                               AttendanceStatus = r.Field<string>("AttendanceStatus"),
                               ImagePath = r.Field<string>("ImagePath"),
                               time_diff = r.Field<Int32?>("time_diff"),
                           }).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ManageCancelTestBooking(eTestBookingCancel RD, out List<eTestBookingCancel> ListOut)
        {
            try
            {

                DBAccess objDbAccess = new DBAccess();
                string SP = "ManageCancelTestBooking";
                SqlParameter[] spc = new SqlParameter[2];

                spc[0] = new SqlParameter("@ToDate", RD.ToDate);
                spc[1] = new SqlParameter("@FromDate", RD.FromDate);

                DataSet ds = objDbAccess.getDataSet(SP, spc);
                ListOut = (from r in ds.Tables[0].AsEnumerable()
                           select new eTestBookingCancel
                           {
                               TestBookingID = r.Field<string?>("TestBookingID"),
                               BookingID = r.Field<string?>("BookingID"),
                               Reason = r.Field<string?>("Reason"),
                               TestCancelDate = r.Field<DateTime?>("TestCancelDate"),
                               UserID = r.Field<string?>("UserID"),
                               FullName = r.Field<string?>("FullName"),
                               PrimaryEmail = r.Field<string?>("PrimaryEmail"),
                               PrimaryPhone = r.Field<string?>("PrimaryPhone"),
                               PatientID = r.Field<string?>("PatientID"),
                               PatientName = r.Field<string?>("PatientName"),
                               Gender = r.Field<string?>("Gender"),
                               BookingDate = r.Field<DateTime?>("BookingDate"),
                           }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public void ManageCancelAppointmentBooking(eAppointmentCancel RD, out List<eAppointmentCancel> ListOut)
        {
            try
            {

                DBAccess objDbAccess = new DBAccess();
                string SP = "ManageCancelAppointmentBooking";
                SqlParameter[] spc = new SqlParameter[2];

                spc[0] = new SqlParameter("@ToDate", RD.ToDate);
                spc[1] = new SqlParameter("@FromDate", RD.FromDate);

                DataSet ds = objDbAccess.getDataSet(SP, spc);
                ListOut = (from r in ds.Tables[0].AsEnumerable()
                           select new eAppointmentCancel
                           {
                               AppointmentBookingID = r.Field<string?>("AppointmentBookingID"),
                               BookingID = r.Field<string?>("BookingID"),
                               Reason = r.Field<string?>("Reason"),
                               AppointmentCancelDate = r.Field<DateTime?>("AppointmentCancelDate"),
                               UserID = r.Field<string?>("UserID"),
                               FullName = r.Field<string?>("FullName"),
                               PrimaryEmail = r.Field<string?>("PrimaryEmail"),
                               PrimaryPhone = r.Field<string?>("PrimaryPhone"),
                               PatientID = r.Field<string?>("PatientID"),
                               PatientName = r.Field<string?>("PatientName"),
                               Gender = r.Field<string?>("Gender"),
                               BookingDate = r.Field<DateTime?>("BookingDate"),
                           }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public void ManageDashBoardForDoctor(eAppoinmentBooking RD, out List<eAppoinmentBooking> ListOut)
        {
            try
            {

                DBAccess objDbAccess = new DBAccess();
                string SP = "ManageDashBoardForDoctor";
                SqlParameter[] spc = new SqlParameter[0];
                

                DataSet ds = objDbAccess.getDataSet(SP, spc);
                ListOut = (from r in ds.Tables[0].AsEnumerable()
                           select new eAppoinmentBooking
                           {
                               TodayAppointment = r.Field<int?>("TodayAppointment"),
                               TodayAppointmentCancel = r.Field<int?>("TodayAppointmentCancel"),
                               ThisMonthAppointment = r.Field<int?>("ThisMonthAppointment"),
                               ThisMonthAppointmentCancel = r.Field<int?>("ThisMonthAppointmentCancel"),
                               
                           }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public void Manage7DaysAppointment(eAppoinmentBooking RD, out List<eAppoinmentBooking> ListOut)
        {
            try
            {

                DBAccess objDbAccess = new DBAccess();
                string SP = "Manage7DaysAppointment";
                SqlParameter[] spc = new SqlParameter[1];
                spc[0] = new SqlParameter("@ActorID", RD.DoctorId);

                DataSet ds = objDbAccess.getDataSet(SP, spc);
                ListOut = (from r in ds.Tables[0].AsEnumerable()
                           select new eAppoinmentBooking
                           {
                               AppointmentDate = r.Field<string?>("AppointmentDate"),
                               AppointmentCount = r.Field<int?>("AppointmentCount"),
                               
                           }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public void GetDataForCalender(eDashBoard RD, out List<eDashBoard> ListOut)
        {
            try
            {

                DBAccess objDbAccess = new DBAccess();
                string SP = "GetDataForCalender";
                SqlParameter[] spc = new SqlParameter[2];
                spc[0] = new SqlParameter("@StartDate", RD.StartDate);
                spc[1] = new SqlParameter("@EndDate", RD.EndDate);

                DataSet ds = objDbAccess.getDataSet(SP, spc);
                ListOut = (from r in ds.Tables[0].AsEnumerable()
                           select new eDashBoard
                           {
                               TransactionDate = r.Field<DateTime?>("TransactionDate"),
                               TotalPayAmount = r.Field<Decimal?>("TotalPayAmount"),
                               TotalAppointment = r.Field<int?>("TotalAppointment"),
                               TotalTestBooking = r.Field<int?>("TotalTestBooking"),                               
                           }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void ManageForTestChart(eTestBooking RD, out List<eTestBooking> ListOut)
        {
            try
            {

                DBAccess objDbAccess = new DBAccess();
                string SP = "ManageForTestChart";
                SqlParameter[] spc = new SqlParameter[1];
                spc[0] = new SqlParameter("@period", RD.period);

                DataSet ds = objDbAccess.getDataSet(SP, spc);
                ListOut = (from r in ds.Tables[0].AsEnumerable()
                           select new eTestBooking
                           {
                               Name = r.Field<string?>("Name"),
                               TotalTest = r.Field<int?>("TotalTest"),                               
                           }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void ManageForAppointmentChart(eTestBooking RD, out List<eTestBooking> ListOut)
        {
            try
            {

                DBAccess objDbAccess = new DBAccess();
                string SP = "ManageForAppointmentChart";
                SqlParameter[] spc = new SqlParameter[1];
                spc[0] = new SqlParameter("@period", RD.period);

                DataSet ds = objDbAccess.getDataSet(SP, spc);
                ListOut = (from r in ds.Tables[0].AsEnumerable()
                           select new eTestBooking
                           {
                               Name = r.Field<string?>("Name"),
                               TotalTest = r.Field<int?>("TotalTest"),                               
                           }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DashBoardDetails(eDashBoard RD, out List<eDashBoard> ListOut)
        {
            try
            {

                DBAccess objDbAccess = new DBAccess();
                string SP = "DashBoardDetails";
                //SqlParameter[] spc = new SqlParameter[1];
                //spc[0] = new SqlParameter("@period", RD.period);

                //DataSet ds = objDbAccess.getDataSet(SP, spc);
                DataSet ds = objDbAccess.getDataSet(SP);
                ListOut = (from r in ds.Tables[0].AsEnumerable()
                           select new eDashBoard
                           {
                               MonthlyDue = r.Field<int?>("MonthlyDue"),
                               MonthlyPay = r.Field<int?>("MonthlyPay"),
                               YearlyDue = r.Field<int?>("YearlyDue"),
                               YearlyPay = r.Field<int?>("YearlyPay"),
                               YearlyBookingAppointment = r.Field<int?>("YearlyBookingAppointment"),
                               YearlyCancelledAppointment = r.Field<int?>("YearlyCancelledAppointment"),
                               MonthlyPendingAppointment = r.Field<int?>("MonthlyPendingAppointment"),
                               MonthlyCancelledAppointment = r.Field<int?>("MonthlyCancelledAppointment"),                               
                           }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
