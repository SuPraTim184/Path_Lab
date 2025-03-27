using Path_Lab_DL;
using Path_Lab_ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_Lab_HELPER
{
    public class cDoctor
    {
        public static List<eDoctor> ManageDoctor(eDoctor BD)
        {
            List<eDoctor> ListOut = new List<eDoctor>();
            dlDoctor obj = new dlDoctor();
            obj.ManageDoctor(BD, out ListOut);
            return ListOut;
        }
        public static string AddEditDoctor(eDoctor CB)
        {
            string vRetId = String.Empty;
            dlDoctor obj = new dlDoctor();
            obj.AddEditDoctor(CB, out vRetId);
            return vRetId;
        }
    }
}
