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
    public class dlPatient
    {
        public void AddEditPatient(ePatient BD, out string oPatientID)
        {
            try
            {
                DataSet ds = new DataSet();
                DBAccess objDbAccess = new DBAccess();

                string SP = "AddEditPatient";

                SqlParameter[] spc = new SqlParameter[6];
                spc[0] = new SqlParameter("@PatientID", BD.PatientId);
                spc[1] = new SqlParameter("@PatientName", BD.PatientName);
                spc[2] = new SqlParameter("@DateOfBirth", BD.PatientDOB);
                spc[3] = new SqlParameter("@Gender", BD.PatientGender);
                spc[4] = new SqlParameter("@IsActive", BD.IsActive);
                spc[5] = new SqlParameter("@UserID", BD.UserId);
                ds = objDbAccess.getDataSet(SP, spc);

                //oFDAccountId = ds.Tables[0].Rows[0]["EmployeeId"].ToString();
                oPatientID = objDbAccess.ExecuteNonQuerywithReturnID(SP, spc).ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ManagePatient(ePatient RD, out List<ePatient> ListOut)
        {
            try
            {

                DBAccess objDbAccess = new DBAccess();
                string SP = "ManagePatient";
                SqlParameter[] spc = new SqlParameter[5];

                spc[0] = new SqlParameter("@PatientID", RD.PatientId);
                spc[1] = new SqlParameter("@PatientName", RD.PatientName);
                spc[2] = new SqlParameter("@Gender", RD.PatientGender);
                spc[3] = new SqlParameter("@UserID", RD.UserId);
                spc[4] = new SqlParameter("@IsActive", RD.IsActive);

                DataSet ds = objDbAccess.getDataSet(SP, spc);
                ListOut = (from r in ds.Tables[0].AsEnumerable()

                           select new ePatient
                           {
                               //PatientId = Convert.ToGuid(r.Field<string?>("PatientID")),
                               PatientId = r.Field<string?>("PatientID").ToString(),
                               PatientName = r.Field<string?>("PatientName"),
                               PatientGender = r.Field<string>("Gender"),
                               PatientDOB = r.Field<DateTime?>("DateOfBirth"),
                               PatientAge = r.Field<int?>("Age"),
                               UserId = r.Field<string?>("UserID").ToString(),
                               FullName = r.Field<string>("FullName"),
                               IsActive = r.Field<bool?>("IsActive"),
                           }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
