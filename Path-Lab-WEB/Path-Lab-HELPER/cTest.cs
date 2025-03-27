using Path_Lab_DL;
using Path_Lab_ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_Lab_HELPER
{
    public class cTest
    {
        public static List<eTest> ManageTest(eTest BD)
        {
            List<eTest> ListOut = new List<eTest>();
            dlTest obj = new dlTest();
            obj.ManageTest(BD, out ListOut);
            return ListOut;
        }
        public static string AddEditTest(eTest CB)
        {
            string vRetId = String.Empty;
            dlTest obj = new dlTest();
            obj.AddEditTest(CB, out vRetId);
            return vRetId;
        }
        public static string AddEditTestReportSample(eTest CB)
        {
            string vRetId = String.Empty;
            dlTest obj = new dlTest();
            obj.AddEditTestReportSample(CB, out vRetId);
            return vRetId;
        }

        public static List<eTest> ManageTestReportSample(eTest BD)
        {
            List<eTest> ListOut = new List<eTest>();
            dlTest obj = new dlTest();
            obj.ManageTestReportSample(BD, out ListOut);
            return ListOut;
        }
    }
}
