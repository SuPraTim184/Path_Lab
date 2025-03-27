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
    public class dlUserDetail
    {

        public void DAValidateUser(eLogin RD, out List<eUser> ListOut)
        {
            try
            {
                DataSet ds = new DataSet();
                DBAccess objDbAccess = new DBAccess();
                string SP = "ValidateUser";
                SqlParameter[] spc = new SqlParameter[10];
                spc[0] = new SqlParameter("@UserName", RD.UserName);
                spc[1] = new SqlParameter("@LoginPassword", RD.LoginPassword);
                spc[2] = new SqlParameter("@ClientIP", RD.ClientIP);
                spc[3] = new SqlParameter("@LoginDevice", RD.LoginDevice);
                spc[4] = new SqlParameter("@ClientIPV6", RD.ClientIPV6);
                spc[5] = new SqlParameter("@ClientMac", RD.ClientMac);
                spc[6] = new SqlParameter("@LoginDeviceName", RD.LoginDeviceName);
                spc[7] = new SqlParameter("@LoginDeviceOs", RD.LoginDeviceOs);
                spc[8] = new SqlParameter("@Mode", RD.Mode);
                spc[9] = new SqlParameter("@UserID", RD.UserID);

                ds = objDbAccess.getDataSet(SP, spc);

                ListOut = (from r in ds.Tables[0].AsEnumerable()
                           select new eUser
                           {
                               UserID = r.Field<string>("UserID"),
                               UserName = r.Field<string>("UserName"),
                               FullName = r.Field<string>("FullName"),
                               UserTypeID = r.Field<Int32?>("UserTypeID"),
                               ProfilePicture = r.Field<string>("ProfilePicture"),
                               OrgID = r.Field<string>("OrgId"),
                               EntityTypeID = r.Field<int?>("EntityTypeID"),
                               //OrgCode = r.Field<string>("OrgCode"),
                               //OrgName = r.Field<string>("OrgName"),
                               //OrgAddress = r.Field<string>("OrgAddress"),
                               //CorporateId = r.Field<string>("CorporateId"),
                               //CorporateName = r.Field<string>("CorporateName"),
                               //DefaultLanding = r.Field<string>("DefaultLanding"),
                           }).ToList();

                //ListOut = ds.Tables[0].ToList<eUser>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ManagePerson(ePerson RD, out List<ePerson> ListOut)
        {
            try
            {
                DataSet ds = new DataSet();
                DBAccess objDbAccess = new DBAccess();
                string SP = "ManagePerson";
                SqlParameter[] spc = new SqlParameter[4];

                spc[0] = new SqlParameter("@EntityTypeId", RD.EntityTypeID);
                spc[1] = new SqlParameter("@Srtxt", RD.SrTxt);
                spc[2] = new SqlParameter("@IsActive", RD.IsActive);
                spc[3] = new SqlParameter("@OrgID", RD.OrgID);

                ds = objDbAccess.getDataSet(SP, spc);
                ListOut = (from r in ds.Tables[0].AsEnumerable()
                           select new ePerson
                           {
                               PersonId = r.Field<string>("EnityId"),
                               FullName = r.Field<string>("FullName"),
                           }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void DAManageUser(eUser RD, out List<eUser> ListOut)
        {
            try
            {
                DataSet ds = new DataSet();
                DBAccess objDbAccess = new DBAccess();
                string SP = "ManageUser";
                SqlParameter[] spc = new SqlParameter[5];

                spc[0] = new SqlParameter("@UserID", RD.UserID);
                spc[1] = new SqlParameter("@Username", RD.UserName);
                spc[2] = new SqlParameter("@UserTypeID", RD.UserTypeID);
                spc[3] = new SqlParameter("@IsActive", RD.IsActive);
                spc[4] = new SqlParameter("@OrgID", RD.OrgID);

                ds = objDbAccess.getDataSet(SP, spc);
                ListOut = (from r in ds.Tables[0].AsEnumerable()
                           select new eUser
                           {
                               UserID = r.Field<string>("UserID"),
                               UserName = r.Field<string>("Username"),
                               FullName = r.Field<string>("FullName"),
                               PrimaryEmail = r.Field<string>("PrimaryEmail"),
                               PrimaryPhone = r.Field<string>("PrimaryPhone"),
                               ProfilePicture = r.Field<string>("ProfilePicture"),
                               EntityTypeID = r.Field<Int32?>("EntityTypeID"),
                               EntityID = r.Field<string>("EntityID"),
                               UserTypeID = r.Field<Int32?>("UserTypeID"),
                               //UserTypeName = r.Field<string>("UserTypeName"),
                               SecurityGroupID = r.Field<Int32?>("SecurityGroupID"),
                               //SecurityGroupName = r.Field<string>("SecurityGroupName"),

                               LoginPassword = r.Field<string>("LoginPassword"),
                               IsLocked = r.Field<bool>("IsLocked"),
                               LastLoggedIn = r.Field<DateTime?>("LastLoggedIn"),
                               PasswordExpire = r.Field<DateTime?>("PasswordExpire"),
                               PasswordStart = r.Field<DateTime?>("PasswordStart"),
                               IsActive = r.Field<bool?>("IsActive"),
                               //OrgCode = r.Field<string>("OrgCode"),
                               //OrgName = r.Field<string>("OrgName"),
                           }).ToList();



            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdatePassword(eUser RD, out string vUserID)
        {
            try
            {

                DataSet ds = new DataSet();

                DBAccess objDbAccess = new DBAccess();
                string SP = "UpdatePassword";
                SqlParameter[] spc = new SqlParameter[2];

                spc[0] = new SqlParameter("@UserID", RD.UserID);
                spc[1] = new SqlParameter("@LoginPassword", RD.LoginPassword);


                ds = objDbAccess.getDataSet(SP, spc);

                vUserID = ds.Tables[0].Rows[0]["UserID"].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public void DAAddEditUser(eUser RD, out string vUserID)
        {
            try
            {

                DataSet ds = new DataSet();

                DBAccess objDbAccess = new DBAccess();
                string SP = "AddEditUser";
                SqlParameter[] spc = new SqlParameter[18];

                spc[0] = new SqlParameter("@UserID", RD.UserID);
                spc[1] = new SqlParameter("@EntityTypeId", RD.EntityTypeID);
                spc[2] = new SqlParameter("@EntityID", RD.EntityID);
                spc[3] = new SqlParameter("@UserTypeID", RD.UserTypeID);
                spc[4] = new SqlParameter("@FullName", RD.FullName);
                spc[5] = new SqlParameter("@PrimaryPhone", RD.PrimaryPhone);
                spc[6] = new SqlParameter("@PrimaryEmail", RD.PrimaryEmail);
                spc[7] = new SqlParameter("@UserName", RD.UserName);
                spc[8] = new SqlParameter("@LoginPassword", RD.LoginPassword);
                spc[9] = new SqlParameter("@PasswordStart", RD.PasswordStart);
                spc[10] = new SqlParameter("@PasswordExpire", RD.PasswordExpire);
                spc[11] = new SqlParameter("@ProfilePicture", RD.ProfilePicture);
                spc[12] = new SqlParameter("@IsLocked", RD.IsLocked);
                spc[13] = new SqlParameter("@IsActive", RD.IsActive);
                spc[14] = new SqlParameter("@IsPublic", RD.IsPublic);
                spc[15] = new SqlParameter("@OrgId", RD.OrgID);
                spc[16] = new SqlParameter("@ActorID", RD.ActorID);
                spc[17] = new SqlParameter("@SecurityGroupID", RD.SecurityGroupID);


                ds = objDbAccess.getDataSet(SP, spc);

                vUserID = ds.Tables[0].Rows[0]["UserID"].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpadtePassword(eUser BD, out string oUserID)
        {
            try
            {
                DataSet ds = new DataSet();
                DBAccess objDbAccess = new DBAccess();

                string SP = "UpdatePassword";

                SqlParameter[] spc = new SqlParameter[2];
                spc[0] = new SqlParameter("@UserID", BD.UserID);
                spc[1] = new SqlParameter("@LoginPassword", BD.LoginPassword);
                ds = objDbAccess.getDataSet(SP, spc);

                //oFDAccountId = ds.Tables[0].Rows[0]["EmployeeId"].ToString();
                oUserID = objDbAccess.ExecuteNonQuerywithReturnID(SP, spc).ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void GetUser(eLogin RD, out List<eUser> ListOut)
        {
            try
            {
                DataSet ds = new DataSet();
                DBAccess objDbAccess = new DBAccess();
                string SP = "GetUser";
                SqlParameter[] spc = new SqlParameter[2];
                spc[0] = new SqlParameter("@UserName", RD.UserName);
                spc[1] = new SqlParameter("@UserID", RD.UserID);

                ds = objDbAccess.getDataSet(SP, spc);

                ListOut = (from r in ds.Tables[0].AsEnumerable()
                           select new eUser
                           {
                               UserID = r.Field<string>("UserID"),
                               UserName = r.Field<string>("UserName"),
                               FullName = r.Field<string>("FullName"),
                               UserTypeID = r.Field<Int32?>("UserTypeID"),                               
                               EntityTypeID = r.Field<int?>("EntityTypeID"),
                           }).ToList();

                //ListOut = ds.Tables[0].ToList<eUser>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddContactUs(eSaveContact RD, out string vUserID)
        {
            try
            {
                DataSet ds = new DataSet();
                DBAccess objDbAccess = new DBAccess();
                string SP = "AddContactUs";
                SqlParameter[] spc = new SqlParameter[7];
                spc[0] = new SqlParameter("@ContactUsID", RD.ContactUsID);
                spc[1] = new SqlParameter("@ContactName", RD.ContactName);
                spc[2] = new SqlParameter("@ContactEmail", RD.ContactEmail);
                spc[3] = new SqlParameter("@ContactSubject", RD.ContactSubject);
                spc[4] = new SqlParameter("@ContactMessage", RD.ContactMessage);
                spc[5] = new SqlParameter("@IsRead", RD.IsRead);
                spc[6] = new SqlParameter("@SendBy", RD.SendBy);
                ds = objDbAccess.getDataSet(SP, spc);
                vUserID = ds.Tables[0].Rows[0]["ContactUsID"].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ManageContactUs(eSaveContact RD, out List<eSaveContact> ListOut)
        {
            try
            {
                DBAccess objDbAccess = new DBAccess();
                string SP = "ManageContactUs";
                SqlParameter[] spc = new SqlParameter[4];
                spc[0] = new SqlParameter("@ContactUsID", RD.ContactUsID);
                spc[1] = new SqlParameter("@ContactName", RD.ContactName);
                spc[2] = new SqlParameter("@ContactEmail", RD.ContactEmail);
                spc[3] = new SqlParameter("@IsActive", RD.IsActive);

                DataSet ds = objDbAccess.getDataSet(SP, spc);
                ListOut = (from r in ds.Tables[0].AsEnumerable()

                           select new eSaveContact
                           {
                               //PatientId = Convert.ToGuid(r.Field<string?>("PatientID")),
                               ContactUsID = r.Field<string?>("ContactUsID"),
                               ContactName = r.Field<string?>("ContactName"),
                               ContactEmail = r.Field<string?>("ContactEmail"),
                               ContactSubject = r.Field<string?>("ContactSubject"),
                               ContactMessage = r.Field<string?>("ContactMessage"),
                               DateEntered = r.Field<DateTime?>("DateEntered"),
                               IsRead = r.Field<bool?>("IsRead"),                              
                               IsActive = r.Field<bool?>("IsActive"),
                               ReplyContactUsID = r.Field<string?>("ReplyContactUsID"),
                               SendBy = r.Field<string?>("SendBy"),
                           }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public void ManageContactUsForMessage(eSaveContact RD, out List<eSaveContact> ListOut)
        {
            try
            {
                DBAccess objDbAccess = new DBAccess();
                string SP = "ManageContactUsForMessage";
                SqlParameter[] spc = new SqlParameter[4];
                spc[0] = new SqlParameter("@ContactUsID", RD.ContactUsID);
                spc[1] = new SqlParameter("@ContactName", RD.ContactName);
                spc[2] = new SqlParameter("@ContactEmail", RD.ContactEmail);
                spc[3] = new SqlParameter("@IsActive", RD.IsActive);

                DataSet ds = objDbAccess.getDataSet(SP, spc);
                ListOut = (from r in ds.Tables[0].AsEnumerable()

                           select new eSaveContact
                           {
                               //PatientId = Convert.ToGuid(r.Field<string?>("PatientID")),
                               ContactUsID = r.Field<string?>("ContactUsID"),
                               ContactName = r.Field<string?>("ContactName"),
                               ContactEmail = r.Field<string?>("ContactEmail"),
                               ContactSubject = r.Field<string?>("ContactSubject"),
                               ContactMessage = r.Field<string?>("ContactMessage"),
                               DateEntered = r.Field<DateTime?>("DateEntered"),
                               IsRead = r.Field<bool?>("IsRead"),                              
                               IsActive = r.Field<bool?>("IsActive"),
                               ReplyContactUsID = r.Field<string?>("ReplyContactUsID"),
                               SendBy = r.Field<string?>("SendBy"),
                           }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddChatUs(eChatUs RD, out string vUserID)
        {
            try
            {
                DataSet ds = new DataSet();
                DBAccess objDbAccess = new DBAccess();
                string SP = "AddChatUs";
                SqlParameter[] spc = new SqlParameter[8];
                spc[0] = new SqlParameter("@UserID", RD.UserID);
                spc[1] = new SqlParameter("@ChatComment", RD.ChatComment);
                spc[2] = new SqlParameter("@ReplyByName", RD.ReplyByName);
                spc[3] = new SqlParameter("@ReplyDate", RD.ReplyDate);
                spc[4] = new SqlParameter("@IsActive", RD.IsActive);
                spc[5] = new SqlParameter("@IsReadAdmin", RD.IsReadAdmin);
                spc[6] = new SqlParameter("@IsReadUser", RD.IsReadUser);
                spc[7] = new SqlParameter("@ChatUsID", RD.ChatUsID);
                //ds = objDbAccess.getDataSet(SP, spc);
                //vUserID = Convert.ToInt32(ds.Tables[0].Rows[0]["ChatUsID"]);
                ds = objDbAccess.getDataSet(SP, spc);
                vUserID = objDbAccess.ExecuteNonQuerywithReturnID(SP, spc).ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ManageChatUs(eChatUs RD, out List<eChatUs> ListOut)
        {
            try
            {
                DBAccess objDbAccess = new DBAccess();
                string SP = "ManageChatUs";
                SqlParameter[] spc = new SqlParameter[2];
                spc[0] = new SqlParameter("@UserID", RD.UserID);
                spc[1] = new SqlParameter("@ReplyByName", RD.ReplyByName);

                DataSet ds = objDbAccess.getDataSet(SP, spc);
                ListOut = (from r in ds.Tables[0].AsEnumerable()

                           select new eChatUs
                           {
                               //PatientId = Convert.ToGuid(r.Field<string?>("PatientID")),
                               ChatUsID = r.Field<int?>("ChatUsID"),
                               UserID = r.Field<string?>("UserID"),
                               FullName = r.Field<string?>("FullName"),
                               ChatComment = r.Field<string?>("ChatComment"),
                               ReplyByName = r.Field<string?>("ReplyByName"),
                               DateEntered = r.Field<DateTime?>("DateEntered"),
                               ReplyDate = r.Field<DateTime?>("ReplyDate"),
                               IsReadAdmin = r.Field<bool?>("IsReadAdmin"),
                               IsReadUser = r.Field<bool?>("IsReadUser")
                           }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void ManageChatUsGrid(eChatUs RD, out List<eChatUs> ListOut)
        {
            try
            {
                DBAccess objDbAccess = new DBAccess();
                string SP = "ManageChatUsForGrid";
                SqlParameter[] spc = new SqlParameter[1];
                spc[0] = new SqlParameter("@ReplyByName", RD.ReplyByName);

                DataSet ds = objDbAccess.getDataSet(SP, spc);
                ListOut = (from r in ds.Tables[0].AsEnumerable()

                           select new eChatUs
                           {
                               UserID = r.Field<string?>("UserID"),
                               FullName = r.Field<string?>("FullName"),
                               ReplyDate = r.Field<DateTime?>("ReplyDate"),
                               IsReadAdmin = r.Field<bool?>("IsReadAdmin"),
                               IsReadUser = r.Field<bool?>("IsReadUser")
                           }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
