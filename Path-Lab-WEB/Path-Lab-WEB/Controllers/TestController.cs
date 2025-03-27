using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Path_Lab_ENTITY;
using Path_Lab_HELPER;

namespace Path_Lab_WEB.Controllers
{
    public class TestController : Controller
    {
        public IActionResult ManageTest(int id, string cf, string cfid, eTest LD, string Command)
        {
            if (!CommonHelper.IsAuthenticate(Request) && CommonHelper.GetCookieUserTypeID(Request) == "10")
            {
                return RedirectToAction("Login", "Home");
            }
            {
                eTest Obj = new eTest();

                if (Command == "Search")
                {
                    if (!string.IsNullOrEmpty(LD.Name))
                    {
                        Obj.Name = LD.Name;
                    }
                    if (!string.IsNullOrEmpty(LD.LabName))
                    {
                        Obj.LabName = LD.LabName;
                    }
                    if (LD.TestTime != null)
                    {
                        Obj.TestTime = LD.TestTime;
                    }
                    if (LD.TestPrice != null)
                    {
                        Obj.TestPrice = LD.TestPrice;
                    }
                }

                Obj.IsActive = true;
                ViewBag.TestDetail = cTest.ManageTest(Obj);

                if (Command == "TestDelete")
                {
                    if (id != null)
                    {
                        Obj.TestId = id;
                    }
                    List<eTest> abc = cTest.ManageTest(Obj);
                    Obj = abc[0];
                    Obj.IsActive = false;

                    string vTestId = cTest.AddEditTest(Obj);

                    return RedirectToAction("ManageTest", "Test");
                }


                return View();
            }
        }

        public IActionResult AddEditTest(int id, string cf, string cfid, eTest BD, string Command)
        {
            if (!CommonHelper.IsAuthenticate(Request) && CommonHelper.GetCookieUserTypeID(Request) == "10")
            {
                return RedirectToAction("Login", "Home");
            }
            {
                eTest CB = new eTest();

                if (Command == "Save")
                {
                    if (!string.IsNullOrEmpty(BD.Name))
                    {
                        CB.TestId = BD.TestId;
                        CB.Name = BD.Name;
                        CB.TestTime = BD.TestTime;
                        CB.LabName = BD.LabName;
                        CB.TestPrice = BD.TestPrice;
                        CB.OtherTestPrice = BD.OtherTestPrice;

                        if (BD.IsActive == null)
                        {
                            CB.IsActive = true;
                        }
                        else
                        {
                            CB.IsActive = BD.IsActive;
                        }


                        string vTestId = cTest.AddEditTest(CB);

                        if (vTestId != "")
                        {
                            return RedirectToAction("ManageTest", "Test");
                        }
                    }
                }
                if (id != 0)
                {
                    eTest Obj = new eTest();

                    Obj.TestId = id;

                    var TestDetails = cTest.ManageTest(Obj);

                    if (TestDetails.Count > 0)
                    {
                        CB = TestDetails[0];
                    }
                }
                return View(CB);
            }


        }

        public IActionResult GetTestPrice(int id)
        {
            try
            {
                eTest SGM = new eTest();
                List<eTest> SGMLM = new List<eTest>();

                SGM.TestId = id;
                SGMLM = cTest.ManageTest(SGM);

                SGM = SGMLM[0];
                string JsonString = JsonConvert.SerializeObject(SGM);

                return Content(JsonString, "application/json");
            }
            catch (Exception ex)
            {
                return Json(null); // You can customize the response for error handling
            }


        }

        public IActionResult AddEditTestReportSample(int id,string cfid,string cf,string Command, eTest ts)
        {
            if (!CommonHelper.IsAuthenticate(Request) && CommonHelper.GetCookieUserTypeID(Request) == "10")
            {
                return RedirectToAction("Login", "Home");
            }


            eTest Obj = new eTest();
            Obj.IsActive = true;
            ViewBag.TestDetail = cTest.ManageTest(Obj);


            if (Command == "Save")
            {
                Obj.TestId = ts.TestId;
                Obj.TestReportSampleID = ts.TestReportSampleID;
                Obj.ReportHTML = ts.ReportHTML;

                string vTestId = cTest.AddEditTestReportSample(Obj);

                return RedirectToAction("AddEditTestReportSample", "Test");
            }

            if(id != 0)
            {
                Obj.TestId = id;
                Obj.IsActive = true;

                ViewBag.ReportViewList = cTest.ManageTestReportSample(Obj);

                if(ViewBag.ReportViewList.Count > 0)
                {
                    ts.TestReportSampleID = ViewBag.ReportViewList[0].TestReportSampleID;
                    ts.TestId = ViewBag.ReportViewList[0].TestId;
                    ts.ReportHTML = ViewBag.ReportViewList[0].ReportHTML;

                    return View(ts);
                }                
            }

            ts.TestId = id;
            return View(ts);
        }
    }
}
