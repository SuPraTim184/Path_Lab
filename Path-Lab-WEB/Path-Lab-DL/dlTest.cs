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
    public class dlTest
    {
        public void AddEditTest(eTest BD, out string oTestID)
        {
            try
            {
                DataSet ds = new DataSet();
                DBAccess objDbAccess = new DBAccess();

                string SP = "AddEditTest";

                SqlParameter[] spc = new SqlParameter[7];
                spc[0] = new SqlParameter("@TestId", BD.TestId);
                spc[1] = new SqlParameter("@Name", BD.Name);
                spc[2] = new SqlParameter("@TestTime", BD.TestTime);
                spc[3] = new SqlParameter("@LabName", BD.LabName);
                spc[4] = new SqlParameter("@TestPrice", BD.TestPrice);
                spc[5] = new SqlParameter("@OtherTestPrice", BD.OtherTestPrice);
                spc[6] = new SqlParameter("@IsActive", BD.IsActive);
                ds = objDbAccess.getDataSet(SP, spc);

                //oFDAccountId = ds.Tables[0].Rows[0]["EmployeeId"].ToString();
                oTestID = objDbAccess.ExecuteNonQuerywithReturnID(SP, spc).ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void AddEditTestReportSample(eTest BD, out string oTestID)
        {
            try
            {
                DataSet ds = new DataSet();
                DBAccess objDbAccess = new DBAccess();

                string SP = "AddEditTestReportSample";

                SqlParameter[] spc = new SqlParameter[4];
                spc[0] = new SqlParameter("@TestReportSampleID", BD.@TestReportSampleID);
                spc[1] = new SqlParameter("@TestId", BD.TestId);
                spc[2] = new SqlParameter("@ReportHTML", BD.ReportHTML);
                spc[3] = new SqlParameter("@IsActive", BD.IsActive);
                ds = objDbAccess.getDataSet(SP, spc);

                //oFDAccountId = ds.Tables[0].Rows[0]["EmployeeId"].ToString();
                oTestID = objDbAccess.ExecuteNonQuerywithReturnID(SP, spc).ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ManageTest(eTest RD, out List<eTest> ListOut)
        {
            try
            {

                DBAccess objDbAccess = new DBAccess();
                string SP = "ManageTest";
                SqlParameter[] spc = new SqlParameter[7];

                spc[0] = new SqlParameter("@TestId", RD.TestId);
                spc[1] = new SqlParameter("@Name", RD.Name);
                spc[2] = new SqlParameter("@TestTime", RD.TestTime);
                spc[3] = new SqlParameter("@LabName", RD.LabName);
                spc[4] = new SqlParameter("@TestPrice", RD.TestPrice);
                spc[5] = new SqlParameter("@OtherTestPrice", RD.OtherTestPrice);
                spc[6] = new SqlParameter("@IsActive", RD.IsActive);

                DataSet ds = objDbAccess.getDataSet(SP, spc);
                ListOut = (from r in ds.Tables[0].AsEnumerable()

                           select new eTest
                           {
                               TestId = r.Field<Int32?>("TestId"),
                               Name = r.Field<string?>("Name"),
                               TestTime = r.Field<string?>("TestTime"),
                               LabName = r.Field<string>("LabName"),
                               TestPrice = r.Field<decimal?>("TestPrice"),
                               OtherTestPrice = r.Field<decimal?>("OtherTestPrice"),
                               IsActive = r.Field<bool?>("IsActive"),

                           }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public void ManageTestReportSample(eTest RD, out List<eTest> ListOut)
        {
            try
            {

                DBAccess objDbAccess = new DBAccess();
                string SP = "ManageTestReportSample";
                SqlParameter[] spc = new SqlParameter[2];

                spc[0] = new SqlParameter("@TestId", RD.TestId);
                spc[1] = new SqlParameter("@IsActive", RD.IsActive);

                DataSet ds = objDbAccess.getDataSet(SP, spc);
                ListOut = (from r in ds.Tables[0].AsEnumerable()

                           select new eTest
                           {
                               TestReportSampleID = r.Field<Int32?>("TestReportSampleID"),
                               TestId = r.Field<Int32?>("TestId"),
                               ReportHTML = r.Field<string?>("ReportHTML"),
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
