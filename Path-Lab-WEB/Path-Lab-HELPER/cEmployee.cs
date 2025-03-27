using Path_Lab_DL;
using System;
using System.Collections.Generic;
using System.Text;
using Path_Lab_ENTITY;


namespace Path_Lab_HELPER
{
    public class cEmployee
    {
        public static List<eEmployee> ManageEmployee(eEmployee BD)
        {
            List<eEmployee> ListOut = new List<eEmployee>();
            dlEmployee obj = new dlEmployee();
            obj.ManageEmployee(BD, out ListOut);
            return ListOut;
        }
        public static string AddEditEmployee(eEmployee CB)
        {
            string vRetId = String.Empty;
            dlEmployee obj = new dlEmployee();
            obj.AddEditEmployee(CB, out vRetId);
            return vRetId;
        }
    }
}