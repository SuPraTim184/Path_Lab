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
    public class dlDoctor
    {
        public void AddEditDoctor(eDoctor BD, out string oDoctorID)
        {
            try
            {
                DataSet ds = new DataSet();
                DBAccess objDbAccess = new DBAccess();

                string SP = "AddEditDoctorDetails";

                SqlParameter[] spc = new SqlParameter[15];
                spc[0] = new SqlParameter("@DoctorId", BD.DoctorId);
                spc[1] = new SqlParameter("@DoctorName", BD.DoctorName);
                spc[2] = new SqlParameter("@Gender", BD.Gender);
                spc[3] = new SqlParameter("@PhoneNumber", BD.PhoneNumber);
                spc[4] = new SqlParameter("@Email", BD.Email);
                spc[5] = new SqlParameter("@Address", BD.Address);
                spc[6] = new SqlParameter("@PinCode", BD.PinCode);
                spc[7] = new SqlParameter("@Specialization", BD.Specialization);
                spc[8] = new SqlParameter("@Qualification", BD.Qualification);
                spc[9] = new SqlParameter("@JoiningDate", BD.JoiningDate);
                spc[10] = new SqlParameter("@Availablechambers", BD.Availablechambers);
                spc[11] = new SqlParameter("@IsActive", BD.IsActive);
                spc[12] = new SqlParameter("@ImagePath", BD.ImagePath);
                spc[13] = new SqlParameter("@IsAvailable", BD.IsAvailable);
                spc[14] = new SqlParameter("@Fees", BD.Fees);
                ds = objDbAccess.getDataSet(SP, spc);

                //oFDAccountId = ds.Tables[0].Rows[0]["EmployeeId"].ToString();
                oDoctorID = objDbAccess.ExecuteNonQuerywithReturnID(SP, spc).ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public void ManageDoctor(eDoctor RD, out List<eDoctor> ListOut)
        {
            try
            {

                DBAccess objDbAccess = new DBAccess();
                string SP = "ManageDoctorDetails";
                SqlParameter[] spc = new SqlParameter[6];

                spc[0] = new SqlParameter("@DoctorId", RD.DoctorId);
                spc[1] = new SqlParameter("@Specialization", RD.Specialization);
                spc[2] = new SqlParameter("@DoctorName", RD.DoctorName);
                spc[3] = new SqlParameter("@Qualification", RD.Qualification);
                spc[4] = new SqlParameter("@PhoneNumber", RD.PhoneNumber);
                spc[5] = new SqlParameter("@IsActive", RD.IsActive);

                DataSet ds = objDbAccess.getDataSet(SP, spc);
                ListOut = (from r in ds.Tables[0].AsEnumerable()

                           select new eDoctor
                           {
                               DoctorId = r.Field<Int32?>("DoctorId"),
                               DoctorName = r.Field<string?>("DoctorName"),
                               Specialization = r.Field<string>("Specialization"),
                               Gender = r.Field<string>("Gender"),
                               PhoneNumber = r.Field<string>("PhoneNumber"),
                               JoiningDate = r.Field<DateTime?>("JoiningDate"),
                               Email = r.Field<string>("Email"),
                               Address = r.Field<string?>("Address"),
                               PinCode = r.Field<string>("PinCode"),
                               Qualification = r.Field<string>("Qualification"),
                               Availablechambers = r.Field<string>("Availablechambers"),
                               ImagePath = r.Field<string>("ImagePath"),
                               IsActive = r.Field<bool?>("IsActive"),
                               IsAvailable = r.Field<bool?>("IsAvailable"),
                               DocNameSpec = r.Field<string?>("DocNameSpec"),
                               Fees = r.Field<decimal?>("Fees"),

                           }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
