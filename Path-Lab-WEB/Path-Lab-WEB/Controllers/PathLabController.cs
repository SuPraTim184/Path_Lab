using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Path_Lab_ENTITY;
using Path_Lab_HELPER;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using Humanizer;
using NuGet.ContentModel;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Utilities.Net;
using System;

namespace Path_Lab_WEB.Controllers
{
    public class PathLabController : Controller
    {
        public IActionResult Index(string Command, eSaveContact SC)
        {
            eDoctor Obj = new eDoctor();
            Obj.IsActive = true;
            ViewBag.DoctorDetail = cDoctor.ManageDoctor(Obj);

            if (SC.ContactName != null)
            {
                eSaveContact ObjSC = new eSaveContact();
                ObjSC.ContactName = SC.ContactName;
                ObjSC.ContactEmail = SC.ContactEmail;
                ObjSC.ContactSubject = SC.ContactSubject;
                ObjSC.ContactMessage = SC.ContactMessage;
                ObjSC.IsActive = true;
                ObjSC.IsRead = false;
                ObjSC.SendBy = "User";
                string ContactUsID = cUsers.AddContactUs(ObjSC);

                if (ContactUsID != null || ContactUsID != "")
                {
                    ViewBag.alert = "Your Message Send Successfully";

                    try
                    {
                        string fromMail = "sahasusabhan084@gmail.com";
                        string fromPassword = "fmwgzxzidufcgnsv";

                        MailMessage message = new MailMessage();
                        message.From = new MailAddress(fromMail);
                        message.Subject = "Reply From Your Lab For Contact Us";
                        message.To.Add(new MailAddress(SC.ContactEmail));
                        message.Body = "<b>Subject: Thank You for Contacting Us!</b><br>Dear," + SC.ContactName + "<br><br>\r\nThank you for reaching out to us! We appreciate your message and the opportunity to assist you.<br>\r\nWe have received your inquiry regarding['" + SC.ContactSubject + "' ] \r\nOur team is currently reviewing your request and will get back to you as soon as possible.<br>\r\nIf you need immediate assistance, please feel free to contact us at[+91-8927483306] or[yourlabsample@gmail.com].<br><br>\r\nThank you for your patience, and we look forward to serving you! <br><br>Best regards,\r\n<br>\r\nYour Lab";

                        message.IsBodyHtml = true;

                        var smtpClient = new SmtpClient("smtp.gmail.com")
                        {
                            Port = 587,
                            Credentials = new NetworkCredential(fromMail, fromPassword),
                            EnableSsl = true,
                        };
                        smtpClient.Send(message);
                    }
                    catch (Exception ex)
                    {

                    }
                }
                else
                {
                    ViewBag.alert = "Sorry,Unable to send Message";
                }
            }
            return View();
        }
        public IActionResult AppointmentBooking(int id, string cf, string cfid, eAppoinmentBooking AB, string Command)
        {

            if (Command == "SaveBooking")
            {
                if (!CommonHelper.IsAuthenticate(Request))
                {
                    //return RedirectToAction("Index", "PathLab");
                    ViewBag.LoginAlert = "Please Login , After Submit the Patient Details";

                    eDoctor Objs = new eDoctor();
                    Objs.IsActive = true;
                    ViewBag.DoctorDetail = cDoctor.ManageDoctor(Objs);

                    ePatient Pts = new ePatient();
                    Pts.IsActive = true;
                    if (CommonHelper.GetCookieUserID(Request) == "" || CommonHelper.GetCookieUserID(Request) == null)
                    {
                        List<ePatient> ObjPatient = new List<ePatient>();
                        Pts.PatientId = null;
                        Pts.PatientName = "";
                        ObjPatient.Add(Pts);

                        ViewBag.Patient = ObjPatient;

                    }
                    else
                    {
                        Pts.UserId = CommonHelper.GetCookieUserID(Request);
                        ViewBag.Patient = cPatient.ManagePatient(Pts);
                    }

                    return View();
                }
                else
                {
                    eAppoinmentBooking ABList = new eAppoinmentBooking();

                    ABList.AppointmentBookingID = AB.AppointmentBookingID;
                    ABList.BookingDate = AB.BookingDate;
                    ABList.DoctorId = AB.DoctorId;
                    ABList.UserID = CommonHelper.GetCookieUserID(Request);
                    ABList.Fees = AB.Fees;
                    ABList.PatientId = AB.PatientId;
                    ABList.PaymentType = AB.PaymentType;
                    ABList.IsCanceled = false;
                    ABList.IsActive = true;
                    ABList.Status = "Booked";

                    string BookingID = cAppointmentBooking.AddEditAppointmentBooking(ABList);

                    if (BookingID != null)
                    {
                        ViewBag.LoginAlert = "Doctor Appointment Book Successfully, and Booking ID is " + BookingID;

                        try
                        {
                            string fromMail = "sahasusabhan084@gmail.com";
                            string fromPassword = "fmwgzxzidufcgnsv";

                            MailMessage message = new MailMessage();
                            message.From = new MailAddress(fromMail);
                            message.Subject = "Doctor Appintment Booking Successfully";
                            message.To.Add(new MailAddress(CommonHelper.GetCookieUserNameEmail(Request)));
                            message.Body = "<h1>Your Doctor Appointment Booking Successfully.</h1>\r\n<p style='font-color:green;'>Your Doctor Appointment Booking ID is " + BookingID + "</p>\r\n<p>From,<br>&nbsp;&nbsp;Your Lab</p>";
                            message.IsBodyHtml = true;

                            var smtpClient = new SmtpClient("smtp.gmail.com")
                            {
                                Port = 587,
                                Credentials = new NetworkCredential(fromMail, fromPassword),
                                EnableSsl = true,
                            };
                            smtpClient.Send(message);
                        }
                        catch (Exception ex)
                        {

                        }

                    }
                    else
                    {
                        ViewBag.LoginAlert = "Doctor Appointment Book  Unsuccessfully";
                    }
                }
            }

            if (Command == "SavePatient")
            {
                if (AB.PatientName != null && AB.PatientGender != null && AB.PatientDOB != null)
                {
                    if (!CommonHelper.IsAuthenticate(Request))
                    {
                        //return RedirectToAction("Index", "PathLab");
                        ViewBag.LoginAlert = "Please Login , After Submit the Patient Details";


                        eDoctor Objs = new eDoctor();
                        Objs.IsActive = true;
                        ViewBag.DoctorDetail = cDoctor.ManageDoctor(Objs);

                        ePatient Pts = new ePatient();
                        Pts.IsActive = true;
                        if (CommonHelper.GetCookieUserID(Request) == "" || CommonHelper.GetCookieUserID(Request) == null)
                        {
                            List<ePatient> ObjPatient = new List<ePatient>();
                            Pts.PatientId = null;
                            Pts.PatientName = "";
                            ObjPatient.Add(Pts);

                            ViewBag.Patient = ObjPatient;

                        }
                        else
                        {
                            Pts.UserId = CommonHelper.GetCookieUserID(Request);
                            ViewBag.Patient = cPatient.ManagePatient(Pts);
                        }

                        return View();
                    }
                    else
                    {
                        ePatient PD = new ePatient();
                        PD.PatientName = AB.PatientName;
                        PD.PatientGender = AB.PatientGender;
                        PD.PatientDOB = AB.PatientDOB;
                        PD.IsActive = true;
                        PD.UserId = CommonHelper.GetCookieUserID(Request);
                        string PatientID = cPatient.AddEditPatient(PD);
                        if (PatientID != null)
                        {
                            ViewBag.LoginAlert = "Patient Details Inserted Successfully";
                        }
                        else
                        {
                            ViewBag.LoginAlert = "Patient Details Inserted Unsuccessfully";
                        }
                    }
                }
                else { ViewBag.LoginAlert = "Please Provide Patient All Details"; }
            }


            eDoctor Obj = new eDoctor();
            Obj.IsActive = true;
            ViewBag.DoctorDetail = cDoctor.ManageDoctor(Obj);

            ePatient Pt = new ePatient();
            Pt.IsActive = true;
            if (CommonHelper.GetCookieUserID(Request) == "" || CommonHelper.GetCookieUserID(Request) == null)
            {
                List<ePatient> ObjPatient = new List<ePatient>();
                Pt.PatientId = null;
                Pt.PatientName = "";
                ObjPatient.Add(Pt);

                ViewBag.Patient = ObjPatient;

            }
            else
            {
                Pt.UserId = CommonHelper.GetCookieUserID(Request);
                ViewBag.Patient = cPatient.ManagePatient(Pt);
            }



            return View(AB);
        }

        public IActionResult ManageAppointmentBooking(int id, string cf, string cfid, eAppoinmentBooking AB, string Command)
        {
            if (!CommonHelper.IsAuthenticate(Request))
            {
                //return RedirectToAction("Index", "PathLab");
                ViewBag.LoginAlert = "Please Login , After Submit the Patient Details";
                return View();
            }
            eAppoinmentBooking Obj = new eAppoinmentBooking();
            eAppoinmentBooking Objs = new eAppoinmentBooking();

            if (Command == "Cancel")
            {
                Objs.AppointmentBookingID = AB.AppointmentBookingID;
                Objs.Reason = AB.Reason;
                Objs.UserID = CommonHelper.GetCookieUserID(Request);
                Objs.Status = "Cancelled";
                Objs.IsCanceled = true;

                var AppointmentBookingID = cAppointmentBooking.AddAppointmentCancel(Objs);
                if (AppointmentBookingID != null)
                {
                    ViewBag.LoginAlert = "Appointment Booking Cancelled";
                }
            }

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
            if (!string.IsNullOrEmpty(CommonHelper.GetCookieUserID(Request)))
            {
                Obj.UserID = CommonHelper.GetCookieUserID(Request);
                ViewBag.ManageAppointmentBooking = cAppointmentBooking.ManageAppointmentBooking(Obj);
            }

            return View();
        }

        public IActionResult AppointmentInvoice(string id, eAppoinmentBooking AB)
        {
            if (!CommonHelper.IsAuthenticate(Request))
            {
                //return RedirectToAction("Index", "PathLab");
                ViewBag.LoginAlert = "Please Login , After Submit the Patient Details";

                return RedirectToAction("Index", "PathLab");
            }

            eAppoinmentBooking obj = new eAppoinmentBooking();
            obj.AppointmentBookingID = id;

            ViewBag.obj = cAppointmentBooking.ManageAppointmentBookingByID(obj);

            if (ViewBag.obj.Count > 0)
            {
                obj = ViewBag.obj[0];
            }

            AB.AppointmentBookingID = id;
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
            obj.MedicineList = cAppointmentBooking.ManagePrescriptionMedicine(ObjMedi);

            ePrescriptionDetails PD = new ePrescriptionDetails();
            PD.AppointmentBookingID = id;
            //PD.BookingID = cf;
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


        public IActionResult AddEditPatient(string id, string cf, string cfid, ePatient AB, string Command)
        {
            if (!CommonHelper.IsAuthenticate(Request))
            {
                return RedirectToAction("Index", "PathLab");
            }
            else
            {
                string CurrUrl = Request.GetDisplayUrl();
                if (AB.PatientName != null)
                {
                }
                else
                {
                    ePatient PD = new ePatient();
                    PD.PatientName = AB.PatientName;
                    PD.PatientGender = AB.PatientGender;
                    PD.PatientDOB = AB.PatientDOB;
                    PD.IsActive = true;
                    PD.UserId = CommonHelper.GetCookieUserID(Request);
                    cPatient.AddEditPatient(PD);
                }
                return Redirect(CurrUrl);
            }

        }

        public IActionResult TestBooking(int id, string cf, string cfid, eTestBooking AB, string Command)
        {


            if (Command == "SaveBooking")
            {
                if (!CommonHelper.IsAuthenticate(Request))
                {
                    //return RedirectToAction("Index", "PathLab");
                    ViewBag.LoginAlert = "Please Login , After Submit the Patient Details";

                    eTest Objs = new eTest();
                    Objs.IsActive = true;
                    ViewBag.TestDetail = cTest.ManageTest(Objs);

                    ePatient Pts = new ePatient();
                    Pts.IsActive = true;
                    if (CommonHelper.GetCookieUserID(Request) == "" || CommonHelper.GetCookieUserID(Request) == null)
                    {
                        List<ePatient> ObjPatient = new List<ePatient>();
                        Pts.PatientId = null;
                        Pts.PatientName = "";
                        ObjPatient.Add(Pts);

                        ViewBag.Patient = ObjPatient;

                    }
                    else
                    {
                        Pts.UserId = CommonHelper.GetCookieUserID(Request);
                        ViewBag.Patient = cPatient.ManagePatient(Pts);
                    }

                    if (AB.TestList == null || AB.TestList.Count == 0)
                    {
                        AB.TestList = new List<eTest>();
                        Objs.TestId = null;
                        Objs.TestPrice = null;
                        AB.TestList.Add(Objs);
                    }
                    ViewBag.TestList = AB.TestList;


                    return View(AB);
                }
                else
                {
                    eTestBooking ABList = new eTestBooking();
                    eTestBooking _ObjABList = new eTestBooking();
                    string _TestBookingID = null;

                    ABList.TestBookingId = AB.TestBookingId;
                    ABList.BookingDate = AB.BookingDate;
                    ABList.UserID = CommonHelper.GetCookieUserID(Request);
                    ABList.PatientId = AB.PatientId;
                    ABList.PaymentType = AB.PaymentType;
                    ABList.IsCanceled = false;
                    ABList.IsActive = true;


                    string strXML = string.Empty;
                    String[] col = { "TestId", "TestPrice", "IsCanceled", "IsActive" };
                    DataTable dt = CreateDatatable(col);

                    foreach (var item in AB.TestList)
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

                    string BookingID = null;
                    //string BookingID;
                    if (AB.TestList.Count > 0)
                    {
                        BookingID = cAppointmentBooking.AddEditTestBooking(ABList);
                    }
                    else
                    {
                        ViewBag.LoginAlert = "Please, Select Minimun 1 Test ";
                    }

                    if (BookingID != null)
                    {
                        ViewBag.LoginAlert = "Test Booked Successfully, and Your Test Booking ID is " + BookingID;

                        try
                        {
                            string fromMail = "sahasusabhan084@gmail.com";
                            string fromPassword = "fmwgzxzidufcgnsv";

                            MailMessage message = new MailMessage();
                            message.From = new MailAddress(fromMail);
                            message.Subject = "Test Booking Successfully";
                            message.To.Add(new MailAddress(CommonHelper.GetCookieUserNameEmail(Request)));
                            message.Body = "<h1>Your test booking successfully.</h1>\r\n<p style='font-color:green;'>Your Test Booking ID is " + BookingID + "</p>\r\n<p>From,<br>&nbsp;&nbsp;Your Lab</p>";
                            message.IsBodyHtml = true;

                            var smtpClient = new SmtpClient("smtp.gmail.com")
                            {
                                Port = 587,
                                Credentials = new NetworkCredential(fromMail, fromPassword),
                                EnableSsl = true,
                            };
                            smtpClient.Send(message);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    else
                    {
                        ViewBag.LoginAlert = "Test Booked  Unsuccessfully";
                    }

                }
            }

            if (Command == "SavePatient")
            {
                if (AB.PatientName != null && AB.PatientGender != null && AB.PatientDOB != null)
                {
                    if (!CommonHelper.IsAuthenticate(Request))
                    {
                        //return RedirectToAction("Index", "PathLab");
                        ViewBag.LoginAlert = "Please Login , After Submit the Patient Details";

                        eTest Objs = new eTest();
                        Objs.IsActive = true;
                        ViewBag.TestDetail = cTest.ManageTest(Objs);

                        ePatient Pts = new ePatient();
                        Pts.IsActive = true;
                        if (CommonHelper.GetCookieUserID(Request) == "" || CommonHelper.GetCookieUserID(Request) == null)
                        {
                            List<ePatient> ObjPatient = new List<ePatient>();
                            Pts.PatientId = null;
                            Pts.PatientName = "";
                            ObjPatient.Add(Pts);

                            ViewBag.Patient = ObjPatient;

                        }
                        else
                        {
                            Pts.UserId = CommonHelper.GetCookieUserID(Request);
                            ViewBag.Patient = cPatient.ManagePatient(Pts);
                        }

                        if (AB.TestList == null || AB.TestList.Count == 0)
                        {
                            AB.TestList = new List<eTest>();
                            Objs.TestId = null;
                            Objs.TestPrice = null;
                            AB.TestList.Add(Objs);
                        }
                        ViewBag.TestList = AB.TestList;


                        return View(AB);

                    }
                    else
                    {
                        ePatient PD = new ePatient();
                        PD.PatientName = AB.PatientName;
                        PD.PatientGender = AB.PatientGender;
                        PD.PatientDOB = AB.PatientDOB;
                        PD.IsActive = true;
                        PD.UserId = CommonHelper.GetCookieUserID(Request);
                        string PatientID = cPatient.AddEditPatient(PD);
                        if (PatientID != null)
                        {
                            ViewBag.LoginAlert = "Patient Details Inserted Successfully";
                        }
                        else
                        {
                            ViewBag.LoginAlert = "Patient Details Inserted Unsuccessfully";
                        }
                    }
                }
                else { ViewBag.LoginAlert = "Please Provide Patient All Details"; }
            }

            eTest Obj = new eTest();
            Obj.IsActive = true;
            ViewBag.TestDetail = cTest.ManageTest(Obj);

            ePatient Pt = new ePatient();
            Pt.IsActive = true;
            if (CommonHelper.GetCookieUserID(Request) == "" || CommonHelper.GetCookieUserID(Request) == null)
            {
                List<ePatient> ObjPatient = new List<ePatient>();
                Pt.PatientId = null;
                Pt.PatientName = "";
                ObjPatient.Add(Pt);

                ViewBag.Patient = ObjPatient;

            }
            else
            {
                Pt.UserId = CommonHelper.GetCookieUserID(Request);
                ViewBag.Patient = cPatient.ManagePatient(Pt);
            }
            AB = new eTestBooking();
            if (AB.TestList == null || AB.TestList.Count == 0)
            {
                AB.TestList = new List<eTest>();
                Obj.TestId = null;
                Obj.TestPrice = null;
                AB.TestList.Add(Obj);
            }
            ViewBag.TestList = AB.TestList;


            return View(AB);
        }

        public IActionResult ManageTestBooking(int id, string cf, string cfid, eTestBooking AB, string Command)
        {
            if (!CommonHelper.IsAuthenticate(Request))
            {
                //return RedirectToAction("Index", "PathLab");
                ViewBag.LoginAlert = "Please Login , After Submit the Patient Details";
                return View();
            }
            eTestBooking Obj = new eTestBooking();
            eTestBooking Objs = new eTestBooking();


            if (Command == "Cancel")
            {
                Objs.TestBookingId = AB.TestBookingId;
                Objs.Reason = AB.Reason;
                Objs.UserID = CommonHelper.GetCookieUserID(Request);
                Objs.Status = "Cancelled";
                Objs.IsCanceled = true;

                var AppointmentBookingID = cAppointmentBooking.AddTestCancel(Objs);
                if (AppointmentBookingID != null)
                {
                    ViewBag.LoginAlert = "Appointment Booking Cancelled";
                }
            }


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
            if (!string.IsNullOrEmpty(CommonHelper.GetCookieUserID(Request)))
            {
                Obj.UserID = CommonHelper.GetCookieUserID(Request);
                ViewBag.ManageTestBookingList = cAppointmentBooking.ManageTestBooking(Obj);
            }

            return View();
        }


        public IActionResult TestInvoice(string id, eTestBooking AB)
        {
            if (!CommonHelper.IsAuthenticate(Request))
            {
                //return RedirectToAction("Index", "PathLab");
                ViewBag.LoginAlert = "Please Login , After Submit the Patient Details";

                return RedirectToAction("Index", "PathLab");
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

        public IActionResult EmployeeProfile(eUser U, string Command)
        {
            if (!CommonHelper.IsAuthenticate(Request))
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
                    ViewBag.Message = "Password Updated Successfully";
                }
                //return RedirectToAction("DoctorDashBoard", "PathLa");
                //return View();
            }

            objU.UserID = CommonHelper.GetCookieUserID(Request);
            lstUserDetail = cUsers.ManageUser(objU);
            if (lstUserDetail.Count > 0)
            {
                objU = lstUserDetail[0];
            }


            return View(objU);
        }

        public IActionResult UserProfile(eUser U, string Command)
        {
            if (!CommonHelper.IsAuthenticate(Request))
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
                    ViewBag.Message = "Password Updated Successfully";
                }
                //return RedirectToAction("DoctorDashBoard", "PathLa");
                //return View();
            }

            objU.UserID = CommonHelper.GetCookieUserID(Request);
            lstUserDetail = cUsers.ManageUser(objU);
            if (lstUserDetail.Count > 0)
            {
                objU = lstUserDetail[0];
            }


            return View(objU);
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


        #region JSON
        public IActionResult GetAppointmentBookingID(string id)
        {
            try
            {
                eAppoinmentBooking SGM = new eAppoinmentBooking();
                List<eAppoinmentBooking> SGMLM = new List<eAppoinmentBooking>();

                SGM.AppointmentBookingID = id;
                SGMLM = cAppointmentBooking.ManageAppointmentBooking(SGM);

                SGM = SGMLM[0];
                string JsonString = JsonConvert.SerializeObject(SGM);

                return Content(JsonString, "application/json");
            }
            catch (Exception ex)
            {
                return Json(null); // You can customize the response for error handling
            }



        }
        public IActionResult GetTestBookingID(string id)
        {
            try
            {
                eTestBooking SGM = new eTestBooking();
                List<eTestBooking> SGMLM = new List<eTestBooking>();

                SGM.TestBookingId = id;
                SGMLM = cAppointmentBooking.ManageTestBooking(SGM);

                SGM = SGMLM[0];
                string JsonString = JsonConvert.SerializeObject(SGM);

                return Content(JsonString, "application/json");
            }
            catch (Exception ex)
            {
                return Json(null); // You can customize the response for error handling
            }



        }

        #endregion

        public IActionResult ManageContactUS(string id, eSaveContact SC)
        {
            if (!CommonHelper.IsAuthenticate(Request))
            {
                return RedirectToAction("Index", "PathLab");
            }
            eSaveContact ObjSC = new eSaveContact();
            ObjSC.IsActive = true;
            ViewBag.ManaContactUsDetails = cUsers.ManageContactUs(ObjSC);

            return View();
        }

        public IActionResult ViewContactUs(string id, string cf, string cfid, string Command, eSaveContact SC)
        {
            if (!CommonHelper.IsAuthenticate(Request))
            {
                return RedirectToAction("Index", "PathLab");
            }
            if (Command == "SaveByAdmin")
            {
                if (SC.ContactMessageByAdmin != null)
                {
                    eSaveContact Obj = new eSaveContact();
                    Obj.ContactUsID = SC.ContactUsID;
                    Obj.IsRead = true;
                    Obj.ContactName = "Admin";
                    Obj.SendBy = "Admin";
                    Obj.ContactMessage = SC.ContactMessageByAdmin;
                    string ContactUsID = cUsers.AddContactUs(Obj);
                    if (ContactUsID != null)
                    {
                        try
                        {
                            string fromMail = "sahasusabhan084@gmail.com";
                            string fromPassword = "fmwgzxzidufcgnsv";

                            MailMessage message = new MailMessage();
                            message.From = new MailAddress(fromMail);
                            message.Subject = "Reply From Your Lab For Contact Us";
                            message.To.Add(new MailAddress(SC.ContactEmail));
                            //message.Body = "<h1>Your test booking successfully.</h1>\r\n<p style='font-color:green;'>Your Test Booking ID is " + BookingID + "</p>\r\n<p>From,<br>&nbsp;&nbsp;Your Lab</p>";
                            //message.Body = "<b>Subject: Thank You for Contacting Us!</b><br>Dear" +SC.ContactName+ ",<br>\r\nThank you for reaching out to us! We appreciate your message and the opportunity to assist you.<br>\r\nWe have received your inquiry regarding[" + SC.ContactSubject + " ] \r\nOur team is currently reviewing your request and will get back to you as soon as possible.<br>\r\nIf you need immediate assistance, please feel free to contact us at[phone number] or[alternative email address].<br>\r\nThank you for your patience, and we look forward to serving you! <br>Best regards,\r\n<br>\r\nYour Lab";
                            message.Body = "<b>Subject: " + SC.ContactSubject + "</b><br>Dear," + SC.ContactName + ",<br>\r\n" +
                                "Your query About <br>\r\n" + SC.ContactMessage + "<br>\r\n<br>\r\n For this query your Answer is <br>\r\n<br>\r\n" + SC.ContactMessageByAdmin +
                                "<br>\r\n<br>Best regards,\r\n<br>\r\nYour Lab";
                            message.IsBodyHtml = true;

                            var smtpClient = new SmtpClient("smtp.gmail.com")
                            {
                                Port = 587,
                                Credentials = new NetworkCredential(fromMail, fromPassword),
                                EnableSsl = true,
                            };
                            smtpClient.Send(message);
                        }
                        catch (Exception ex)
                        {

                        }
                    }

                    return Redirect("~/PathLab/ViewContactUs/0/0/" + id);
                }
            }

            eSaveContact ObjSC = new eSaveContact();
            ObjSC.ContactUsID = id;
            ObjSC.IsActive = true;
            ViewBag.ContactList = cUsers.ManageContactUs(ObjSC);
            ViewBag.ContactListForMessage = cUsers.ManageContactUsForMessage(ObjSC);

            if (ViewBag.ContactList.Count > 0)
            {
                ObjSC = ViewBag.ContactList[0];
                ObjSC.ContactMessageByAdmin = null;
            }

            return View(ObjSC);
        }

        public IActionResult ChatUsUser(string id, string Command, eChatUs CU)
        {
            if (!CommonHelper.IsAuthenticate(Request))
            {
                return RedirectToAction("Index", "PathLab");
            }

            eChatUs ObjCU = new eChatUs();
            if (Command == "SaveChat")
            {
                if (CU.ChatComment != null)
                {
                    ObjCU.UserID = CommonHelper.GetCookieUserID(Request);
                    ObjCU.ChatComment = CU.ChatComment;
                    ObjCU.ReplyByName = "User";
                    ObjCU.IsReadAdmin = false;
                    ObjCU.IsReadUser = true;

                    string ChatUsId = cUsers.AddChatUs(ObjCU);
                    return Redirect("~/PathLab/ChatUsUser");
                }
            }

            ObjCU.ChatComment = CU.ChatComment;
            ObjCU.@ReplyByName = "User";
            ObjCU.UserID = CommonHelper.GetCookieUserID(Request);
            ViewBag.ChatUsList = cUsers.ManageChatUs(ObjCU);

            return View();
        }

        public IActionResult ChatUsAdmin(string id, string cfid, string Command, eChatUs CU)
        {
            if (!CommonHelper.IsAuthenticate(Request))
            {
                return RedirectToAction("Index", "PathLab");
            }

            eChatUs ObjCU = new eChatUs();
            if (Command == "SaveChat")
            {
                if (CU.ChatComment != null)
                {
                    ObjCU.UserID = id;
                    ObjCU.ChatComment = CU.ChatComment;
                    ObjCU.ReplyByName = "Admin";
                    ObjCU.IsReadAdmin = true;
                    ObjCU.IsReadUser = false;

                    string ChatUsId = cUsers.AddChatUs(ObjCU);
                    return Redirect("~/PathLab/ChatUsAdmin/0/" + cfid + "/" + id);
                }
            }

            ObjCU.@ReplyByName = "Admin";
            ObjCU.UserID = id;
            ViewBag.ChatUsList = cUsers.ManageChatUs(ObjCU);

            ObjCU.ChatComment = CU.ChatComment;
            ObjCU.UserID = id;
            ObjCU.FullName = cfid;
            return View(ObjCU);
        }

        public IActionResult ChatUsAdminGrid(string id, string cfid, string Command, eChatUs CU)
        {
            if (!CommonHelper.IsAuthenticate(Request))
            {
                return RedirectToAction("Index", "PathLab");
            }

            eChatUs ObjCU = new eChatUs();
            ObjCU.@ReplyByName = "Admin";
            ViewBag.ChatUsList = cUsers.ManageChatUsGrid(ObjCU);

            return View();
        }
    }
}
