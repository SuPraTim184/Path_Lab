using Microsoft.AspNetCore.Mvc;
using Path_Lab_DL;
using Path_Lab_ENTITY;
using Path_Lab_HELPER;
using System.Data;
using System.Globalization;
using System.Net.Sockets;
using System.Net;

namespace Path_Lab_WEB.Controllers
{
    public class EmployeeWorkController : Controller
    {
        public IActionResult EmployeeDashBoard(string Command, eAppoinmentBooking AB, eTestBooking TB, eEmployeePunchDetails EPDs)
        {
            int userid = Convert.ToInt32(CommonHelper.GetCookieUserTypeID(Request));
            if (!CommonHelper.IsAuthenticate(Request) && (Convert.ToInt32(CommonHelper.GetCookieUserTypeID(Request)) == 30 || Convert.ToInt32(CommonHelper.GetCookieUserTypeID(Request)) == 10))
            {
                return RedirectToAction("Login", "Home");
            }
            eEmployeePunchDetails pd = new eEmployeePunchDetails();

            DateTime dd = DateTime.Now;
            string podate = dd.ToString("dd/MM/yyyy 00:00:00");
            pd.EmployeeId = CommonHelper.GetCookieUserID(Request);
            pd.punchInTime = Convert.ToDateTime(podate);
            var punchDetails = cAdmin.ManageeEmployeePunchDetails(pd);

            if (Command == "PunchIn")
            {
                if (punchDetails.Count > 0)
                {
                    pd = punchDetails[0];
                    ViewBag.AlertDanger = "You Already Punch In";
                }
                else
                {
                    string host = Dns.GetHostName();
                    IPHostEntry ip = Dns.GetHostEntry(host);
                    foreach (IPAddress ipAddress in ip.AddressList)
                    {
                        if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
                        {
                            pd.ClientIP = Convert.ToString(ipAddress);
                        }
                        else if (ipAddress.AddressFamily == AddressFamily.InterNetworkV6)
                        {
                        }
                    }

                    RegionInfo region = RegionInfo.CurrentRegion;

                    pd.EmployeeId = CommonHelper.GetCookieUserID(Request);
                    pd.punchInTime = EPDs.punchInTime;
                    pd.LoginCountry = region.DisplayName;
                    pd.LoginDevice = CommonHelper.GetDeviceType();
                    pd.ClientMac = CommonHelper.GetMACAddress();
                    pd.LoginDeviceName = Environment.MachineName;
                    pd.LoginDeviceOs = Environment.OSVersion.VersionString;
                    pd.LoginDevice = CommonHelper.GetDeviceType();
                    pd.IsLoginSuccess = EPDs.IsLoginSuccess;
                    pd.IsActive = true;
                    pd.ActorID = CommonHelper.GetCookieUserID(Request);

                    if (!string.IsNullOrEmpty(EPDs.EmployeeId))
                    {
                        pd.EmployeeId = EPDs.EmployeeId;
                    }

                    int vEmployeePunchDetailsId = Convert.ToInt32(cAdmin.AddEditEmployeePunchDetails(pd));

                    if (vEmployeePunchDetailsId != null)
                    {
                        return RedirectToAction("EmployeeDashBoard", "EmployeeWork", pd.ActorID);
                    }
                }
            }
            if (Command == "PunchOut")
            {
                if (punchDetails.Count > 0)
                {
                    if (pd.EmployeeId == CommonHelper.GetCookieUserID(Request) && Convert.ToString(pd.punchInTime) == podate)
                    {
                        pd.EmployeeId = CommonHelper.GetCookieUserID(Request);
                        pd.PunchoutTime = DateTime.Now;
                        pd.IsActive = true;
                        pd.EmployeePunchDetailsId = pd.EmployeePunchDetailsId;
                        pd.punchInTime = Convert.ToDateTime(podate);

                        string vEmployeePunchDetailsId = cAdmin.UpdateEmployeePunchDetails(pd);


                        if (vEmployeePunchDetailsId != null)
                        {
                            return RedirectToAction("EmployeeDashBoard", "EmployeeWork", pd.ActorID);
                        }
                    }
                }
                else
                {
                    ViewBag.AlertDanger = "You are Not Punch In Today ";
                }
            }


            eAppoinmentBooking Obj = new eAppoinmentBooking();
            eTest ObjTest = new eTest();

            if (Command == "SaveBooking")
            {

                eTestBooking ABList = new eTestBooking();
                eTestBooking _ObjABList = new eTestBooking();
                string _TestBookingID = null;

                ABList.TestBookingId = TB.TestBookingId;
                ABList.BookingDate = TB.BookingDate;
                //ABList.UserID = CommonHelper.GetCookieUserID(Request);

                ABList.PaymentType = TB.PaymentType;
                ABList.IsCanceled = false;
                ABList.IsActive = true;

                ABList.PatientName = TB.PatientName;
                ABList.PatientGender = TB.PatientGender;
                ABList.PatientDOB = TB.PatientDOB;


                string strXML = string.Empty;
                String[] col = { "TestId", "TestPrice", "IsCanceled", "IsActive" };
                DataTable dt = CreateDatatable(col);

                foreach (var item in TB.TestList)
                {
                    if (item.TestId != null)
                    {
                        DataRow row = dt.NewRow();
                        row["TestId"] = item.TestId;
                        row["TestPrice"] = item.TestPrice;
                        row["IsCanceled"] = false;
                        row["IsActive"] = true;
                        dt.Rows.Add(row);

                    }
                }

                DataSet dschk = new DataSet();
                dschk.Tables.Add(dt);
                strXML = CreateXMLString(dschk);
                ABList.pstrXML = strXML;

                //string BookingID = null;
                string BookingID = cAppointmentBooking.AddEditTestBookingByEmployee(ABList);

                if (BookingID != null)
                {
                    ViewBag.Alert = "Test Booked Successfully, ID : " + BookingID;
                }
                else
                {
                    ViewBag.AlertDanger = "Test Booked  Unsuccessfully";
                }


            }

            if (Command == "SaveBookingAppointment")
            {

                eAppoinmentBooking ABList = new eAppoinmentBooking();

                ABList.AppointmentBookingID = AB.AppointmentBookingID;
                ABList.BookingDate = AB.BookingDate;
                ABList.DoctorId = AB.DoctorId;
                //ABList.UserID = CommonHelper.GetCookieUserID(Request);
                ABList.Fees = AB.Fees;
                //ABList.PatientId = AB.PatientId;
                ABList.PaymentType = AB.PaymentType;
                ABList.IsCanceled = false;
                ABList.IsActive = true;
                ABList.Status = "Booked";

                ABList.PatientName = TB.PatientName;
                ABList.PatientGender = TB.PatientGender;
                ABList.PatientDOB = TB.PatientDOB;


                string BookingID = cAppointmentBooking.AddEditAppointmentBookingByEmployee(ABList);

                if (BookingID != null)
                {
                    ViewBag.Alert = "Doctor Appointment Book Successfully" + BookingID;
                }
                else
                {
                    ViewBag.AlertDanger = "Doctor Appointment Book  Unsuccessfully";
                }

            }


            if (Command != "Search" || Command == null)
            {
                Obj.BookingDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yyyy"));
            }
            if (Command == "Search")
            {
                if (AB.BookingDate != null)
                {
                    Obj.BookingDate = AB.BookingDate;
                }
                if (AB.BookingID != null)
                {
                    Obj.BookingID = AB.BookingID;
                    Obj.BookingDate = null;
                }
            }
            ViewBag.AppointmentBookingList = cAppointmentBooking.ManageAppointmentBooking(Obj);


            eTestBooking ObjT = new eTestBooking();
            if (Command != "SearchTest" || Command == null)
            {
                ObjT.BookingDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yyyy"));
            }
            if (Command == "SearchTest")
            {
                if (TB.TestBookingDate != null)
                {
                    ObjT.BookingDate = TB.TestBookingDate;
                }
                if (TB.BookingIDNew != null)
                {
                    ObjT.BookingID = TB.BookingIDNew;
                    ObjT.BookingDate = null;
                }
            }
            ViewBag.ManageTestBooking = cAppointmentBooking.ManageTestBooking(ObjT);

            eDoctor Objs = new eDoctor();
            Objs.IsActive = true;
            ViewBag.DoctorDetail = cDoctor.ManageDoctor(Objs);

            eTest Objst = new eTest();
            Objst.IsActive = true;
            ViewBag.TestDetail = cTest.ManageTest(Objst);


            eTestBooking TempTB = new eTestBooking();
            TB = TempTB;

            TB = new eTestBooking();
            if (TB.TestList == null || TB.TestList.Count == 0)
            {
                TB.TestList = new List<eTest>();
                ObjTest.TestId = null;
                ObjTest.TestPrice = null;
                TB.TestList.Add(ObjTest);
            }
            ViewBag.TestList = TB.TestList;
            //ViewBag.Alert = "Test Booked  Unsuccessfully";
            return View(TB);
        }

        public IActionResult EmployeeProfile(eUser U, string Command)
        {
            if (!CommonHelper.IsAuthenticate(Request) && CommonHelper.GetCookieUserTypeID(Request) == "20")
            {
                return RedirectToAction("Login", "Home");
            }

            eUser objU = new eUser();
            List<eUser> lstUserDetail = new List<eUser>();

            if (Command == "Update")
            {
                objU.UserID = U.UserID;
                objU.LoginPassword = U.LoginPassword;

                string vDoctorID = cUsers.UpadtePassword(objU);

                if (vDoctorID != null)
                {
                    ViewBag.LoginAlert = "Password Updated Successfully";
                }
                return RedirectToAction("EmployeeDashBoard", "EmployeeWork");
            }

            objU.UserID = CommonHelper.GetCookieUserID(Request);
            lstUserDetail = cUsers.ManageUser(objU);
            if (lstUserDetail.Count > 0)
            {
                objU = lstUserDetail[0];
            }


            return View(objU);
        }

        public IActionResult ManageTestBookingDetails(int id, string cf, string cfid, eTestBooking AB, string Command)
        {
            eTestBooking Obj = new eTestBooking();

            if (Command == "Search")
            {
                if (AB.BookingDate != null)
                {
                    Obj.BookingDate = AB.BookingDate;
                }
                if (!string.IsNullOrEmpty(AB.BookingID))
                {
                    Obj.BookingID = AB.BookingID;
                }
                if (AB.PatientId != null)
                {
                    Obj.PatientId = AB.PatientId;
                }
                if (AB.IsCanceled != null)
                {
                    Obj.IsCanceled = AB.IsCanceled;
                }
            }
            ViewBag.ManageTestBookingList = cAppointmentBooking.ManageTestBooking(Obj);



            return View();
        }

        public IActionResult ManageAppointmentBookingDetails(int id, string cf, string cfid, eAppoinmentBooking AB, string Command)
        {
            eAppoinmentBooking Obj = new eAppoinmentBooking();
            if (Command == "Search")
            {
                if (AB.BookingDate != null)
                {
                    Obj.BookingDate = AB.BookingDate;
                }
                if (!string.IsNullOrEmpty(AB.PaymentType))
                {
                    Obj.PaymentType = AB.PaymentType;
                }
                if (AB.PatientId != null)
                {
                    Obj.PatientId = AB.PatientId;
                }
                if (AB.IsCanceled != null)
                {
                    Obj.IsCanceled = AB.IsCanceled;
                }
            }

            ViewBag.ManageAppointmentBooking = cAppointmentBooking.ManageAppointmentBooking(Obj);

            return View();
        }


        public IActionResult AppointmentDetails(string id, string cf, string cfid, eAppoinmentBooking AB, string Command)
        {

            if (!CommonHelper.IsAuthenticate(Request))
            {
                //return RedirectToAction("Index", "PathLab");
                ViewBag.LoginAlert = "Please Login , After Submit the Patient Details";

                return RedirectToAction("Index", "PathLab");
            }

            eAppoinmentBooking objs = new eAppoinmentBooking();
            if (Command == "SaveBooking")
            {
                if (AB.PayAmount != null)
                {
                    objs.PayAmount = AB.PayAmount;
                    objs.EntityID = AB.AppointmentBookingID;
                    objs.PayAmount = AB.PayAmount;
                    objs.EntityTypeID = AB.EntityTypeID;

                    var PaymentTransID = cAppointmentBooking.AddPaymentTransactionDeatilsForAppointment(objs);

                    return Redirect("/EmployeeWork/AppointmentDetails?id=" + AB.AppointmentBookingID);
                }
            }

            eAppoinmentBooking obj = new eAppoinmentBooking();
            obj.AppointmentBookingID = id;

            ViewBag.obj = cAppointmentBooking.ManageAppointmentBookingByID(obj);

            if (ViewBag.obj.Count > 0)
            {
                obj = ViewBag.obj[0];
            }

            //Prescription

            AB.AppointmentBookingID = id;
            //AB.BookingID = cfid;
            //AD.AppointmentBookingID = id;
           // AD.BookingID = cfid;
            ViewBag.Appointment = cAppointmentBooking.ManageAppointmentBooking(AB);

            if (ViewBag.Appointment.Count > 0)
            {
                obj.PatientName = ViewBag.Appointment[0].PatientName;
                obj.PatientID = ViewBag.Appointment[0].PatientId;
                obj.PatientDOB = ViewBag.Appointment[0].PatientDOB;
                obj.SuccessfulAppointment = ViewBag.Appointment[0].SuccessfulAppointment;
            }

            eMedicine ObjMedi = new eMedicine();

            ObjMedi.AppointmentBookingID = id;
            //ObjMedi.BookingID = cfid;
            obj.MedicineList = cAppointmentBooking.ManagePrescriptionMedicine(ObjMedi);

            ePrescriptionDetails PD = new ePrescriptionDetails();
            //PD.AppointmentBookingID = cf;
            PD.AppointmentBookingID = id;
            PD.BookingID = cfid;
            ViewBag.PetientgeneralInfo = cAppointmentBooking.ManagePrescriptionDetails(PD);
            if (ViewBag.PetientgeneralInfo.Count > 0)
            {
                obj.PatientHeight = ViewBag.PetientgeneralInfo[0].PatientHeight;
                obj.PatientWeight = ViewBag.PetientgeneralInfo[0].PatientWeight;
                obj.PatientBPHigh = ViewBag.PetientgeneralInfo[0].PatientBPHigh;
                obj.PatientBPLow = ViewBag.PetientgeneralInfo[0].PatientBPLow;
                obj.Description = ViewBag.PetientgeneralInfo[0].Description;
            }

            return View(obj);
        }


        public IActionResult TestDetails(string id, string Command, eTestBooking AB/*, string TestReportID, string TestBookingId, string BookingID, string TestBookingDetailsID, string TestId, string ReportHTML*/)
        {
            if (!CommonHelper.IsAuthenticate(Request))
            {
                //return RedirectToAction("Index", "PathLab");
                ViewBag.LoginAlert = "Please Login , After Submit the Patient Details";

                return RedirectToAction("Index", "PathLab");
            }

            eTestBooking objs = new eTestBooking();
            if (Command == "SaveBooking")
            {
                if(AB.PayAmount != null)
                {
                    objs.PayAmount = AB.PayAmount;
                    objs.EntityID = AB.TestBookingId;
                    objs.PayAmount = AB.PayAmount;
                    objs.EntityTypeID = AB.EntityTypeID;

                    var PaymentTransID = cAppointmentBooking.AddPaymentTransactionDeatilsForTest(objs);

                    return Redirect("/EmployeeWork/TestDetails?id="+AB.TestBookingId);
                }
            }

            if(Command == "SaveReport")
            {
                objs.TestReportID = AB.TestReportID;
                objs.TestBookingId = AB.TestBookingId;
                objs.BookingID = AB.BookingID;
                objs.TestBookingDetailsID = AB.TestBookingDetailsID;
                objs.TestId = AB.TestId;
                objs.TestReportHTML = AB.ReportHTML;

                var TestReportID = cAppointmentBooking.AddEditTestReport(objs);
                return Redirect("/EmployeeWork/TestDetails?id=" + AB.TestBookingId);

            }

            eTestBooking obj = new eTestBooking();
            obj.TestBookingId = id;

            ViewBag.obj = cAppointmentBooking.ManageTestBooking(obj);
            if (ViewBag.obj.Count > 0)
            {
                obj = ViewBag.obj[0];
            }
            ViewBag.TestBookingDetails = cAppointmentBooking.ManageTestBookingDetails(obj);

            ViewBag.ManageTestReportDetails = cAppointmentBooking.ManageTestReport(obj);


            return View(obj);
        }
                        
        public static DataTable CreateDatatable(string[] colname)
        {

            DataTable dt = new DataTable();
            foreach (string feildname in colname)
            {
                dt.Columns.Add(feildname, typeof(string));
            }

            return dt;
        }

        public static string CreateXMLString(System.Data.DataSet ds)
        {
            string strXML = "";
            try
            {

                System.IO.StringWriter sw = new System.IO.StringWriter();
                System.Xml.XmlTextWriter xw = new System.Xml.XmlTextWriter(sw);
                System.Xml.XmlTextWriter xw1 = new System.Xml.XmlTextWriter(sw);
                ds.WriteXml(xw);
                strXML = sw.ToString().Replace("_x0020_", "_");
            }
            catch
            {

            }
            return strXML;
        }


    }
}
