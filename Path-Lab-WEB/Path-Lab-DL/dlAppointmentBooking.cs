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
    public class dlAppointmentBooking
    {

        public void AddEditAppointmentBookingByEmployee(eAppoinmentBooking BD, out string oAppointmentBookingID)
        {
            try
            {
                DataSet ds = new DataSet();
                DBAccess objDbAccess = new DBAccess();

                string SP = "AddEditAppointmentBookingByEmployee";

                SqlParameter[] spc = new SqlParameter[13];

                spc[0] = new SqlParameter("@AppointmentBookingID", BD.AppointmentBookingID);
                spc[1] = new SqlParameter("@BookingDate", BD.BookingDate);
                spc[2] = new SqlParameter("@DoctorId", BD.DoctorId);
                spc[3] = new SqlParameter("@UserID", BD.UserID);
                spc[4] = new SqlParameter("@Fees", BD.Fees);
                spc[5] = new SqlParameter("@PatientId", BD.PatientId);
                spc[6] = new SqlParameter("@PaymentType", BD.PaymentType);
                spc[7] = new SqlParameter("@IsCanceled", BD.IsCanceled);
                spc[8] = new SqlParameter("@IsActive", BD.IsActive);
                spc[9] = new SqlParameter("@PatientGender", BD.PatientGender);
                spc[10] = new SqlParameter("@PatientName", BD.PatientName);
                spc[11] = new SqlParameter("@PatientDOB", BD.PatientDOB);
                spc[12] = new SqlParameter("@Status", BD.Status);

                ds = objDbAccess.getDataSet(SP, spc);

                //oFDAccountId = ds.Tables[0].Rows[0]["EmployeeId"].ToString();
                oAppointmentBookingID = objDbAccess.ExecuteNonQuerywithReturnID(SP, spc).ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void AddAppointmentCancel(eAppoinmentBooking BD, out string oAppointmentCancelID)
        {
            try
            {
                DataSet ds = new DataSet();
                DBAccess objDbAccess = new DBAccess();

                string SP = "AddAppointmentCancel";

                SqlParameter[] spc = new SqlParameter[5];

                spc[0] = new SqlParameter("@AppointmentBookingID", BD.AppointmentBookingID);
                spc[1] = new SqlParameter("@Reason", BD.Reason);
                spc[2] = new SqlParameter("@UserID", BD.UserID);
                spc[3] = new SqlParameter("@IsCanceled", BD.IsCanceled);
                spc[4] = new SqlParameter("@Status", BD.Status);

                ds = objDbAccess.getDataSet(SP, spc);

                oAppointmentCancelID = ds.Tables[0].Rows[0]["AppointmentBookingID"].ToString();
                //oFDAccountId = ds.Tables[0].Rows[0]["EmployeeId"].ToString();
                //oAppointmentBookingID = objDbAccess.ExecuteNonQuerywithReturnID(SP, spc).ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void AddTestCancel(eTestBooking BD, out string oTestCancelID)
        {
            try
            {
                DataSet ds = new DataSet();
                DBAccess objDbAccess = new DBAccess();

                string SP = "AddTestCancel";

                SqlParameter[] spc = new SqlParameter[5];

                spc[0] = new SqlParameter("@TestBookingID", BD.TestBookingId);
                spc[1] = new SqlParameter("@Reason", BD.Reason);
                spc[2] = new SqlParameter("@UserID", BD.UserID);
                spc[3] = new SqlParameter("@IsCanceled", BD.IsCanceled);
                spc[4] = new SqlParameter("@Status", BD.Status);

                ds = objDbAccess.getDataSet(SP, spc);

                oTestCancelID = ds.Tables[0].Rows[0]["TestBookingID"].ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void AddEditAppointmentBooking(eAppoinmentBooking BD, out string oAppointmentBookingID)
        {
            try
            {
                DataSet ds = new DataSet();
                DBAccess objDbAccess = new DBAccess();

                string SP = "AddEditAppointmentBooking";

                SqlParameter[] spc = new SqlParameter[10];

                spc[0] = new SqlParameter("@AppointmentBookingID", BD.AppointmentBookingID);
                spc[1] = new SqlParameter("@BookingDate", BD.BookingDate);
                spc[2] = new SqlParameter("@DoctorId", BD.DoctorId);
                spc[3] = new SqlParameter("@UserID", BD.UserID);
                spc[4] = new SqlParameter("@Fees", BD.Fees);
                spc[5] = new SqlParameter("@PatientId", BD.PatientId);
                spc[6] = new SqlParameter("@PaymentType", BD.PaymentType);
                spc[7] = new SqlParameter("@IsCanceled", BD.IsCanceled);
                spc[8] = new SqlParameter("@IsActive", BD.IsActive);
                spc[9] = new SqlParameter("@Status", BD.Status);

                ds = objDbAccess.getDataSet(SP, spc);

                oAppointmentBookingID = ds.Tables[0].Rows[0]["AppointmentBookingID"].ToString();
                //oFDAccountId = ds.Tables[0].Rows[0]["EmployeeId"].ToString();
                //oAppointmentBookingID = objDbAccess.ExecuteNonQuerywithReturnID(SP, spc).ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ManageAppointmentBookingByID(eAppoinmentBooking AB, out List<eAppoinmentBooking> ListOut)
        {
            try
            {

                DBAccess objDbAccess = new DBAccess();
                string SP = "ManageAppointmentBookingByID";
                SqlParameter[] spc = new SqlParameter[8];

                spc[0] = new SqlParameter("@AppointmentBookingID", AB.AppointmentBookingID);
                spc[1] = new SqlParameter("@BookingID", AB.BookingID);
                spc[2] = new SqlParameter("@BookingDate", AB.BookingDate);
                spc[3] = new SqlParameter("@PaymentType", AB.PaymentType);
                spc[4] = new SqlParameter("@PatientID", AB.PatientId);
                spc[5] = new SqlParameter("@IsCanceled", AB.IsCanceled);
                spc[6] = new SqlParameter("@UserID", AB.UserID);
                spc[7] = new SqlParameter("@DoctorId", AB.DoctorId);

                DataSet ds = objDbAccess.getDataSet(SP, spc);
                ListOut = (from r in ds.Tables[0].AsEnumerable()

                           select new eAppoinmentBooking
                           {
                               AppointmentBookingID = r.Field<string?>("AppointmentBookingID"),
                               BookingID = r.Field<string?>("BookingID"),
                               BookingDate = r.Field<DateTime?>("BookingDate"),
                               DoctorId = r.Field<int?>("DoctorId"),
                               DoctorName = r.Field<string?>("DoctorName"),
                               UserID = r.Field<string?>("UserID"),
                               Fees = r.Field<string?>("Fees"),
                               FullName = r.Field<string?>("FullName"),
                               PatientId = r.Field<string?>("PatientID"),
                               PatientName = r.Field<string?>("PatientName"),
                               PatientDOB = r.Field<DateTime>("DateOfBirth"),
                               PaymentType = r.Field<string?>("PaymentType"),
                               DateEntered = r.Field<DateTime?>("DateEntered"),
                               IsCanceled = r.Field<bool?>("IsCanceled"),
                               IsActive = r.Field<bool?>("IsActive"),
                               // = r.Field<bool?>("Iscancel"),
                               PaymentDue = r.Field<string?>("PaymentDue"),
                               SuccessfulAppointment = r.Field<bool?>("SuccessfulAppointment"),
                               Status = r.Field<string?>("Status"),
                               DueAmount = r.Field<decimal?>("DueAmount"),
                               TotalPayment = r.Field<decimal?>("TotalPayment")
                           }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ManageAppointmentBooking(eAppoinmentBooking AB, out List<eAppoinmentBooking> ListOut)
        {
            try
            {

                DBAccess objDbAccess = new DBAccess();
                string SP = "ManageAppointmentBooking";
                SqlParameter[] spc = new SqlParameter[8];

                spc[0] = new SqlParameter("@AppointmentBookingID", AB.AppointmentBookingID);
                spc[1] = new SqlParameter("@BookingID", AB.BookingID);
                spc[2] = new SqlParameter("@BookingDate", AB.BookingDate);
                spc[3] = new SqlParameter("@PaymentType", AB.PaymentType);
                spc[4] = new SqlParameter("@PatientID", AB.PatientId);
                spc[5] = new SqlParameter("@IsCanceled", AB.IsCanceled);
                spc[6] = new SqlParameter("@UserID", AB.UserID);
                spc[7] = new SqlParameter("@DoctorId", AB.DoctorId);

                DataSet ds = objDbAccess.getDataSet(SP, spc);
                ListOut = (from r in ds.Tables[0].AsEnumerable()

                           select new eAppoinmentBooking
                           {
                               AppointmentBookingID = r.Field<string?>("AppointmentBookingID"),
                               BookingID = r.Field<string?>("BookingID"),
                               BookingDate = r.Field<DateTime?>("BookingDate"),
                               DoctorId = r.Field<int?>("DoctorId"),
                               DoctorName = r.Field<string?>("DoctorName"),
                               UserID = r.Field<string?>("UserID"),
                               Fees = r.Field<string?>("Fees"),
                               FullName = r.Field<string?>("FullName"),
                               PatientId = r.Field<string?>("PatientID"),
                               PatientName = r.Field<string?>("PatientName"),
                               PatientDOB = r.Field<DateTime>("DateOfBirth"),
                               PaymentType = r.Field<string?>("PaymentType"),
                               DateEntered = r.Field<DateTime?>("DateEntered"),
                               IsCanceled = r.Field<bool?>("IsCanceled"),
                               IsActive = r.Field<bool?>("IsActive"),
                               // = r.Field<bool?>("Iscancel"),
                               PaymentDue = r.Field<string?>("PaymentDue"),
                               SuccessfulAppointment = r.Field<bool?>("SuccessfulAppointment"),
                               Status = r.Field<string?>("Status")
                           }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void ManageAppointmentBookingForPrescription(eAppoinmentBooking AB, out List<eAppoinmentBooking> ListOut)
        {
            try
            {

                DBAccess objDbAccess = new DBAccess();
                string SP = "ManageAppointmentBookingForPrescription";
                SqlParameter[] spc = new SqlParameter[8];

                spc[0] = new SqlParameter("@AppointmentBookingID", AB.AppointmentBookingID);
                spc[1] = new SqlParameter("@BookingID", AB.BookingID);
                spc[2] = new SqlParameter("@BookingDate", AB.BookingDate);
                spc[3] = new SqlParameter("@PaymentType", AB.PaymentType);
                spc[4] = new SqlParameter("@PatientID", AB.PatientId);
                spc[5] = new SqlParameter("@IsCanceled", AB.IsCanceled);
                spc[6] = new SqlParameter("@UserID", AB.UserID);
                spc[7] = new SqlParameter("@DoctorId", AB.DoctorId);

                DataSet ds = objDbAccess.getDataSet(SP, spc);
                ListOut = (from r in ds.Tables[0].AsEnumerable()

                           select new eAppoinmentBooking
                           {
                               AppointmentBookingID = r.Field<string?>("AppointmentBookingID"),
                               BookingID = r.Field<string?>("BookingID"),
                               BookingDate = r.Field<DateTime?>("BookingDate"),
                               DoctorId = r.Field<int?>("DoctorId"),
                               DoctorName = r.Field<string?>("DoctorName"),
                               UserID = r.Field<string?>("UserID"),
                               Fees = r.Field<string?>("Fees"),
                               FullName = r.Field<string?>("FullName"),
                               PatientId = r.Field<string?>("PatientID"),
                               PatientName = r.Field<string?>("PatientName"),
                               PatientDOB = r.Field<DateTime>("DateOfBirth"),
                               PaymentType = r.Field<string?>("PaymentType"),
                               DateEntered = r.Field<DateTime?>("DateEntered"),
                               IsCanceled = r.Field<bool?>("IsCanceled"),
                               IsActive = r.Field<bool?>("IsActive"),
                               // = r.Field<bool?>("Iscancel"),
                               PaymentDue = r.Field<string?>("PaymentDue"),
                               SuccessfulAppointment = r.Field<bool?>("SuccessfulAppointment"),
                               Status = r.Field<string?>("Status")
                           }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ManagePrescriptionMedicine(eMedicine AB, out List<eMedicine> ListOut)
        {
            try
            {

                DBAccess objDbAccess = new DBAccess();
                string SP = "ManagePrescriptionMedicine";
                SqlParameter[] spc = new SqlParameter[4];

                spc[0] = new SqlParameter("@PrescriptionMedicineID", AB.PrescriptionMedicineID);
                spc[1] = new SqlParameter("@PetientID", AB.PetientID);
                spc[2] = new SqlParameter("@AppointmentBookingID", AB.AppointmentBookingID);
                spc[3] = new SqlParameter("@BookingID", AB.BookingID);
                DataSet ds = objDbAccess.getDataSet(SP, spc);
                ListOut = (from r in ds.Tables[0].AsEnumerable()

                           select new eMedicine
                           {
                               PrescriptionMedicineID = r.Field<int?>("PrescriptionMedicineID"),
                               AppointmentBookingID = r.Field<string?>("AppointmentBookingID"),
                               BookingID = r.Field<string?>("BookingID"),
                               MedicineName = r.Field<string?>("MedicineName"),
                               MedicineUsing = r.Field<string?>("MedicineUsing"),
                               PetientID = r.Field<string?>("PetientID"),

                           }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ManagePrescriptionDetails(ePrescriptionDetails AB, out List<ePrescriptionDetails> ListOut)
        {
            try
            {

                DBAccess objDbAccess = new DBAccess();
                string SP = "ManagePrescriptionDetails";
                SqlParameter[] spc = new SqlParameter[4];

                spc[0] = new SqlParameter("@PrescriptionID", AB.PrescriptionID);
                spc[1] = new SqlParameter("@PetientID", AB.PetientID);
                spc[2] = new SqlParameter("@AppointmentBookingID", AB.AppointmentBookingID);
                spc[3] = new SqlParameter("@BookingID", AB.BookingID);
                DataSet ds = objDbAccess.getDataSet(SP, spc);
                ListOut = (from r in ds.Tables[0].AsEnumerable()

                           select new ePrescriptionDetails
                           {
                               PrescriptionID = r.Field<int?>("PrescriptionID"),
                               PetientID = r.Field<string?>("PetientID"),
                               AppointmentBookingID = r.Field<string?>("AppointmentBookingID"),
                               BookingID = r.Field<string?>("BookingID"),
                               Description = r.Field<string?>("Description"),
                               PatientHeight = r.Field<string?>("PatientHeight"),
                               PatientWeight = r.Field<string?>("PatientWeight"),
                               PatientBPHigh = r.Field<string?>("PatientBPHigh"),
                               PatientBPLow = r.Field<string?>("PatientBPLow"),


                           }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }




        public void AddEditTestBookingByEmployee(eTestBooking BD, out string oTestBookingID)
        {
            try
            {
                DataSet ds = new DataSet();
                DBAccess objDbAccess = new DBAccess();

                string SP = "AddEditTestBookingByEmployee";

                SqlParameter[] spc = new SqlParameter[10];

                spc[0] = new SqlParameter("@TestBookingId", BD.TestBookingId);
                spc[1] = new SqlParameter("@BookingDate", BD.BookingDate);
                spc[2] = new SqlParameter("@UserID", BD.UserID);
                spc[3] = new SqlParameter("@PatientId", BD.PatientId);
                spc[4] = new SqlParameter("@PaymentType", BD.PaymentType);
                spc[5] = new SqlParameter("@IsCanceled", BD.IsCanceled);
                spc[6] = new SqlParameter("@DataTableInXML", BD.pstrXML);
                spc[7] = new SqlParameter("@PatientName", BD.PatientName);
                spc[8] = new SqlParameter("@PatientGender", BD.PatientGender);
                spc[9] = new SqlParameter("@PatientDOB", BD.PatientDOB);

                ds = objDbAccess.getDataSet(SP, spc);

                oTestBookingID = ds.Tables[0].Rows[0]["TestBookingID"].ToString();
                //oTestBookingID = objDbAccess.ExecuteNonQuerywithReturnID(SP, spc).ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void AddEditTestBooking(eTestBooking BD, out string oTestBookingID)
        {
            try
            {
                DataSet ds = new DataSet();
                DBAccess objDbAccess = new DBAccess();

                string SP = "AddEditTestBooking";

                SqlParameter[] spc = new SqlParameter[7];

                spc[0] = new SqlParameter("@TestBookingId", BD.TestBookingId);
                spc[1] = new SqlParameter("@BookingDate", BD.BookingDate);
                spc[2] = new SqlParameter("@UserID", BD.UserID);
                spc[3] = new SqlParameter("@PatientId", BD.PatientId);
                spc[4] = new SqlParameter("@PaymentType", BD.PaymentType);
                spc[5] = new SqlParameter("@IsCanceled", BD.IsCanceled);
                spc[6] = new SqlParameter("@DataTableInXML", BD.pstrXML);

                ds = objDbAccess.getDataSet(SP, spc);

                oTestBookingID = ds.Tables[0].Rows[0]["TestBookingID"].ToString();
                //oTestBookingID = objDbAccess.ExecuteNonQuerywithReturnID(SP, spc).ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void AddPaymentTransactionDeatilsForAppointment(eAppoinmentBooking BD, out string oTestBookingID)
        {
            try
            {
                DataSet ds = new DataSet();
                DBAccess objDbAccess = new DBAccess();

                string SP = "AddPaymentTransactionDeatilsForAppointment";

                SqlParameter[] spc = new SqlParameter[3];

                spc[0] = new SqlParameter("@EntityID", BD.EntityID);
                spc[1] = new SqlParameter("@EntityTypeID", BD.EntityTypeID);
                spc[2] = new SqlParameter("@PayAmount", BD.PayAmount);

                ds = objDbAccess.getDataSet(SP, spc);

                oTestBookingID = ds.Tables[0].Rows[0]["TestBookingID"].ToString();
                //oTestBookingID = objDbAccess.ExecuteNonQuerywithReturnID(SP, spc).ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void AddPaymentTransactionDeatilsForTest(eTestBooking BD, out string oTestBookingID)
        {
            try
            {
                DataSet ds = new DataSet();
                DBAccess objDbAccess = new DBAccess();

                string SP = "AddPaymentTransactionDeatilsForTest";

                SqlParameter[] spc = new SqlParameter[3];

                spc[0] = new SqlParameter("@EntityID", BD.EntityID);
                spc[1] = new SqlParameter("@EntityTypeID", BD.EntityTypeID);
                spc[2] = new SqlParameter("@PayAmount", BD.PayAmount);

                ds = objDbAccess.getDataSet(SP, spc);

                oTestBookingID = ds.Tables[0].Rows[0]["TestBookingID"].ToString();
                //oTestBookingID = objDbAccess.ExecuteNonQuerywithReturnID(SP, spc).ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void AddEditPrescriptionDetails(eAppointmentDetails BD, out string oTestBookingID)
        {
            try
            {
                DataSet ds = new DataSet();
                DBAccess objDbAccess = new DBAccess();

                string SP = "AddEditPrescriptionDetails";

                SqlParameter[] spc = new SqlParameter[10];

                spc[0] = new SqlParameter("@BookingID", BD.BookingID);
                spc[1] = new SqlParameter("@AppointmentBookingID", BD.AppointmentBookingID);
                spc[2] = new SqlParameter("@PatientID", BD.PatientID);
                spc[3] = new SqlParameter("@SuccessfulAppointment", BD.SuccessfulAppointment);
                spc[4] = new SqlParameter("@PatientHeight", BD.PatientHeight);
                spc[5] = new SqlParameter("@PatientWeight", BD.PatientWeight);
                spc[6] = new SqlParameter("@PatientBPHigh", BD.PatientBPHigh);
                spc[7] = new SqlParameter("@PatientBPLow", BD.PatientBPLow);
                spc[8] = new SqlParameter("@Description", BD.Description);
                spc[9] = new SqlParameter("@DataTableInXML", BD.pstrXML);

                ds = objDbAccess.getDataSet(SP, spc);

                oTestBookingID = ds.Tables[0].Rows[0]["TestBookingID"].ToString();
                //oTestBookingID = objDbAccess.ExecuteNonQuerywithReturnID(SP, spc).ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ManageTestBooking(eTestBooking AB, out List<eTestBooking> ListOut)
        {
            try
            {

                DBAccess objDbAccess = new DBAccess();
                string SP = "ManageTestBooking";
                SqlParameter[] spc = new SqlParameter[7];

                spc[0] = new SqlParameter("@TestBookingID", AB.TestBookingId);
                spc[1] = new SqlParameter("@BookingID", AB.BookingID);
                spc[2] = new SqlParameter("@BookingDate", AB.BookingDate);
                spc[3] = new SqlParameter("@PaymentType", AB.PaymentType);
                spc[4] = new SqlParameter("@PatientID", AB.PatientId);
                spc[5] = new SqlParameter("@IsCanceled", AB.IsCanceled);
                spc[6] = new SqlParameter("@UserID", AB.UserID);

                DataSet ds = objDbAccess.getDataSet(SP, spc);
                ListOut = (from r in ds.Tables[0].AsEnumerable()

                           select new eTestBooking
                           {
                               TestBookingId = r.Field<string?>("TestBookingID"),
                               BookingID = r.Field<string?>("BookingID"),
                               BookingDate = r.Field<DateTime?>("BookingDate"),
                               UserID = r.Field<string?>("UserID"),
                               UserName = r.Field<string?>("FullName"),
                               //Fees = r.Field<string?>("Fees"),
                               PatientId = r.Field<string?>("PatientID"),
                               PatientName = r.Field<string?>("PatientName"),
                               PaymentType = r.Field<string?>("PaymentType"),
                               DateEntered = r.Field<DateTime?>("DateEntered"),
                               IsCanceled = r.Field<bool?>("IsCanceled"),
                               IsActive = r.Field<bool?>("IsActive"),
                               PaymentDue = r.Field<string?>("PaymentDue"),
                               TotalFees = r.Field<decimal?>("TotalFees"),
                               Status = r.Field<string?>("Status"),
                               DueAmount = r.Field<decimal?>("DueAmount"),
                               TotalPayment = r.Field<decimal?>("TotalPayment"),
                               PatientAge = r.Field<Int32?>("PatientAge"),
                               PrimaryPhone = r.Field<string?>("PrimaryPhone"),

                           }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void ManageTestBookingDetails(eTestBooking AB, out List<eTestBooking> ListOut)
        {
            try
            {

                DBAccess objDbAccess = new DBAccess();
                string SP = "ManageTestBookingDetails";
                SqlParameter[] spc = new SqlParameter[4];

                spc[0] = new SqlParameter("@TestBookingDetailsID", AB.TestBookingDetailsID);
                spc[1] = new SqlParameter("@BookingID", AB.BookingID);
                spc[2] = new SqlParameter("@IsCanceled", AB.IsCanceled);
                spc[3] = new SqlParameter("@TestBookingID", AB.TestBookingId);


                DataSet ds = objDbAccess.getDataSet(SP, spc);
                ListOut = (from r in ds.Tables[0].AsEnumerable()

                           select new eTestBooking
                           {
                               TestBookingDetailsID = r.Field<int?>("TestBookingDetailsID"),
                               TestBookingId = r.Field<string?>("TestBookingID"),
                               BookingID = r.Field<string?>("BookingID"),
                               TestId = r.Field<int?>("TestID"),
                               TestName = r.Field<string?>("Name"),
                               Fees = r.Field<decimal?>("TestPrice"),
                               DateEntered = r.Field<DateTime?>("DateEntered"),
                               IsCanceled = r.Field<bool?>("IsCanceled"),
                               IsActive = r.Field<bool?>("IsActive"),
                           }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ManageTestReport(eTestBooking AB, out List<eTestBooking> ListOut)
        {
            try
            {

                DBAccess objDbAccess = new DBAccess();
                string SP = "ManageTestReport";
                SqlParameter[] spc = new SqlParameter[1];
                spc[0] = new SqlParameter("@TestBookingID", AB.TestBookingId);


                DataSet ds = objDbAccess.getDataSet(SP, spc);
                ListOut = (from r in ds.Tables[0].AsEnumerable()

                           select new eTestBooking
                           {
                               TestBookingDetailsID = r.Field<int?>("TestBookingDetailsID"),
                               TestBookingId = r.Field<string?>("TestBookingID"),
                               BookingID = r.Field<string?>("BookingID"),
                               TestId = r.Field<int?>("TestID"),
                               TestName = r.Field<string?>("Name"),
                               TestReportID = r.Field<int?>("TestReportID"),
                               TestReportHTML = r.Field<string?>("TestReportHTML"),
                               ReportHTML = r.Field<string?>("ReportHTML"),
                           }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddEditTestReport(eTestBooking BD, out string oTestReportID)
        {
            try
            {
                DataSet ds = new DataSet();
                DBAccess objDbAccess = new DBAccess();

                string SP = "AddEditTestReport";

                SqlParameter[] spc = new SqlParameter[7];

                spc[0] = new SqlParameter("@TestReportID", BD.TestReportID);
                spc[1] = new SqlParameter("@TestBookingID", BD.TestBookingId);
                spc[2] = new SqlParameter("@BookingID", BD.BookingID);
                spc[3] = new SqlParameter("@TestBookingDetailsID", BD.TestBookingDetailsID);
                spc[4] = new SqlParameter("@TestID", BD.TestId);
                spc[5] = new SqlParameter("@TestReportHTML", BD.TestReportHTML);
                spc[6] = new SqlParameter("@IsActive", BD.IsActive);

                ds = objDbAccess.getDataSet(SP, spc);

                oTestReportID = ds.Tables[0].Rows[0]["TestReportID"].ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
