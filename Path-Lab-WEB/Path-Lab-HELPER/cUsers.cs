using Path_Lab_ENTITY;
using Path_Lab_DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_Lab_HELPER
{
    public class cUsers
    {
        public static void ValidateUser(eLogin RD, out List<eUser> ListOut)
        {
            dlUserDetail obj = new dlUserDetail();
            obj.DAValidateUser(RD, out ListOut);
        }


        public static void GetUser(eLogin RD, out List<eUser> ListOut)
        {
            dlUserDetail obj = new dlUserDetail();
            obj.GetUser(RD, out ListOut);
        }

        public static string AddEditUser(eUser RD)
        {
            string vUserid = "";
            dlUserDetail obj = new dlUserDetail();
            obj.DAAddEditUser(RD, out vUserid);
            return vUserid;
        }
        
        public static string UpdatePassword(eUser RD)
        {
            string vUserid = "";
            dlUserDetail obj = new dlUserDetail();
            obj.UpdatePassword(RD, out vUserid);
            return vUserid;
        }

        public static List<eUser> ManageUser(eUser RD)
        {
            dlUserDetail obj = new dlUserDetail();
            List<eUser> ListOut = new List<eUser>();
            obj.DAManageUser(RD, out ListOut);
            return ListOut;
        }
        public static List<ePerson> ManagePerson(ePerson RD)
        {
            dlUserDetail obj = new dlUserDetail();
            List<ePerson> ListOut = new List<ePerson>();
            obj.ManagePerson(RD, out ListOut);
            return ListOut;
        }
        public static string UpadtePassword(eUser CB)
        {
            string vRetId = String.Empty;
            dlUserDetail obj = new dlUserDetail();
            obj.UpadtePassword(CB, out vRetId);
            return vRetId;
        }


        public static string AddContactUs(eSaveContact AB)
        {
            string vRetId = String.Empty;
            dlUserDetail obj = new dlUserDetail();
            obj.AddContactUs(AB, out vRetId);
            return vRetId;
        }

        public static List<eSaveContact> ManageContactUs(eSaveContact RD)
        {
            dlUserDetail obj = new dlUserDetail();
            List<eSaveContact> ListOut = new List<eSaveContact>();
            obj.ManageContactUs(RD, out ListOut);
            return ListOut;
        }
        public static List<eSaveContact> ManageContactUsForMessage(eSaveContact RD)
        {
            dlUserDetail obj = new dlUserDetail();
            List<eSaveContact> ListOut = new List<eSaveContact>();
            obj.ManageContactUsForMessage(RD, out ListOut);
            return ListOut;
        }

        public static string AddChatUs(eChatUs RD)
        {
            string vUserid = "";
            dlUserDetail obj = new dlUserDetail();
            obj.AddChatUs(RD, out vUserid);
            return vUserid;
        }

        public static List<eChatUs> ManageChatUs(eChatUs RD)
        {
            dlUserDetail obj = new dlUserDetail();
            List<eChatUs> ListOut = new List<eChatUs>();
            obj.ManageChatUs(RD, out ListOut);
            return ListOut;
        }
        public static List<eChatUs> ManageChatUsGrid(eChatUs RD)
        {
            dlUserDetail obj = new dlUserDetail();
            List<eChatUs> ListOut = new List<eChatUs>();
            obj.ManageChatUsGrid(RD, out ListOut);
            return ListOut;
        }
    }

}
