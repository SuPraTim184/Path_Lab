using Path_Lab_DL;
using Path_Lab_ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_Lab_HELPER
{
    public class cPatient
    {
        public static string AddEditPatient(ePatient PD)
        {
            string vRetId = String.Empty;
            dlPatient obj = new dlPatient();
            obj.AddEditPatient(PD, out vRetId);
            return vRetId;
        }

        public static List<ePatient> ManagePatient(ePatient BD)
        {
            List<ePatient> ListOut = new List<ePatient>();
            dlPatient obj = new dlPatient();
            obj.ManagePatient(BD, out ListOut);
            return ListOut;
        }
    }
}
