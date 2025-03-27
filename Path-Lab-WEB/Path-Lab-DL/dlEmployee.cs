using Path_Lab_DS;
using System.Data.SqlClient;
using System.Data;
using Path_Lab_ENTITY;

namespace Path_Lab_DL
{
    public class dlEmployee
    {
        public void AddEditEmployee(eEmployee BD, out string oFDAccountId)
        {
            try
            {
                DataSet ds = new DataSet();
                DBAccess objDbAccess = new DBAccess();

                string SP = "AddEditEmployee";

                SqlParameter[] spc = new SqlParameter[14];
                spc[0] = new SqlParameter("@EmployeeId", BD.EmployeeId);
                spc[1] = new SqlParameter("@EmployeeName", BD.EmployeeName);
                spc[2] = new SqlParameter("@Degination", BD.Degination);
                spc[3] = new SqlParameter("@Gender", BD.Gender);
                spc[4] = new SqlParameter("@PhoneNumber", BD.PhoneNumber);
                spc[5] = new SqlParameter("@DateOfJoining", BD.DateOfJoining);
                spc[6] = new SqlParameter("@Email", BD.Email);
                spc[7] = new SqlParameter("@Address", BD.Address);
                spc[8] = new SqlParameter("@PinCode", BD.PinCode);
                spc[9] = new SqlParameter("@Qualification", BD.Qualification);
                spc[10] = new SqlParameter("@Type", BD.Type);
                spc[11] = new SqlParameter("@IsActive", BD.IsActive);
                spc[12] = new SqlParameter("@ImagePath", BD.ImagePath);
                spc[13] = new SqlParameter("@IsAvailable", BD.IsAvailable);
                ds = objDbAccess.getDataSet(SP, spc);

                //oFDAccountId = ds.Tables[0].Rows[0]["EmployeeId"].ToString();
                oFDAccountId = objDbAccess.ExecuteNonQuerywithReturnID(SP, spc).ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ManageEmployee(eEmployee RD, out List<eEmployee> ListOut)
        {
            try
            {

                DBAccess objDbAccess = new DBAccess();
                string SP = "ManageEmployee";
                SqlParameter[] spc = new SqlParameter[6];

                spc[0] = new SqlParameter("@EmployeeId", RD.EmployeeId);
                spc[1] = new SqlParameter("@Degination", RD.Degination);
                spc[2] = new SqlParameter("@EmployeeName", RD.EmployeeName);
                spc[3] = new SqlParameter("@Type", RD.Type);
                spc[4] = new SqlParameter("@PhoneNumber", RD.PhoneNumber);
                spc[5] = new SqlParameter("@IsActive", RD.IsActive);

                DataSet ds = objDbAccess.getDataSet(SP, spc);
                ListOut = (from r in ds.Tables[0].AsEnumerable()

                           select new eEmployee
                           {
                               EmployeeId = r.Field<Int32?>("EmployeeId"),
                               EmployeeName = r.Field<string?>("EmployeeName"),
                               Degination = r.Field<string>("Degination"),
                               Gender = r.Field<string>("Gender"),
                               PhoneNumber = r.Field<string>("PhoneNumber"),
                               DateOfJoining = r.Field<DateTime?>("DateOfJoining"),
                               Email = r.Field<string>("Email"),
                               Address = r.Field<string?>("Address"),
                               PinCode = r.Field<string>("PinCode"),
                               Qualification = r.Field<string>("Qualification"),
                               Type = r.Field<string>("Type"),
                               ImagePath = r.Field<string>("ImagePath"),
                               IsActive = r.Field<bool?>("IsActive"),
                               IsAvailable = r.Field<bool?>("IsAvailable"),

                           }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}