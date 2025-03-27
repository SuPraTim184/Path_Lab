using Microsoft.AspNetCore.Mvc;
using Path_Lab_DL;
using Path_Lab_ENTITY;
using Path_Lab_HELPER;
using System.Data;

namespace Path_Lab_WEB.Controllers
{
    public class DoctorWorkController : Controller
    {
        public IActionResult DoctorDashBoard(string Command, eAppoinmentBooking AB)
        {
            if (!CommonHelper.IsAuthenticate(Request) && CommonHelper.GetCookieUserTypeID(Request) == "20")
            {
                return RedirectToAction("Login", "Home");
            }

            eAppoinmentBooking Obj = new eAppoinmentBooking();
            if (Command == null & AB.BookingDate == null)
            {
                Obj.BookingDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yyyy"));
            }
            if (Command == "Search")
            {
                if (AB.BookingDate != null)
                {
                    Obj.BookingDate = AB.BookingDate;
                }
            }

            Obj.DoctorId = Convert.ToInt32(CommonHelper.GetCookieEntityTypeID(Request));
            ViewBag.ManageAppointmentBooking = cAppointmentBooking.ManageAppointmentBooking(Obj);

            try
            {
                var DashBoardList = cAdmin.ManageDashBoardForDoctor(Obj);
                if (DashBoardList.Count > 0)
                {
                    Obj.TodayAppointment = DashBoardList[0].TodayAppointment;
                    Obj.TodayAppointmentCancel = DashBoardList[0].TodayAppointmentCancel;
                    Obj.ThisMonthAppointment = DashBoardList[0].ThisMonthAppointment;
                    Obj.ThisMonthAppointmentCancel = DashBoardList[0].ThisMonthAppointmentCancel;
                }
            }
            catch (Exception ex)
            {

            }
            return View(Obj);
        }

        public IActionResult DoctorProfile(eUser U, string Command)
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
                return RedirectToAction("DoctorDashBoard", "DoctorWork");
            }

            objU.UserID = CommonHelper.GetCookieUserID(Request);
            lstUserDetail = cUsers.ManageUser(objU);
            if (lstUserDetail.Count > 0)
            {
                objU = lstUserDetail[0];
            }


            return View(objU);
        }

        public IActionResult AddEditprescription(string? id, string cf, string cfid, string Command, eAppointmentDetails PAD)
        {
            if (!CommonHelper.IsAuthenticate(Request) && CommonHelper.GetCookieUserTypeID(Request) == "20")
            {
                return RedirectToAction("Login", "Home");
            }

            eAppoinmentBooking AB = new eAppoinmentBooking();
            eAppointmentDetails AD = new eAppointmentDetails();
            eMedicine Obj = new eMedicine();

            if (Command == "SaveMedicine")
            {
                AD.BookingID = PAD.BookingID;
                AD.AppointmentBookingID = PAD.AppointmentBookingID;
                AD.PatientID = PAD.PatientID;
                AD.SuccessfulAppointment = PAD.SuccessfulAppointment;
                AD.PatientHeight = PAD.PatientHeight;
                AD.PatientWeight = PAD.PatientWeight;
                AD.PatientBPHigh = PAD.PatientBPHigh;
                AD.PatientBPLow = PAD.PatientBPLow;
                AD.Description = PAD.Description;

                string strXML = string.Empty;
                String[] col = { "MedicineName", "MedicineUsing", "IsActive" };
                DataTable dt = CreateDatatable(col);

                foreach (var item in PAD.MedicineList)
                {
                    if (item.MedicineName != null)
                    {
                        DataRow row = dt.NewRow();
                        row["MedicineName"] = item.MedicineName;
                        row["MedicineUsing"] = item.MedicineUsing;
                        row["IsActive"] = true;
                        dt.Rows.Add(row);

                    }
                }

                DataSet dschk = new DataSet();
                dschk.Tables.Add(dt);
                strXML = CreateXMLString(dschk);
                AD.pstrXML = strXML;

                cAppointmentBooking.AddEditPrescriptionDetails(AD);

                return RedirectToAction("DoctorDashBoard", "DoctorWork");
            }

            if (cf != null)
            {
                AB.AppointmentBookingID = cf;
                AB.BookingID = cfid;
                AD.AppointmentBookingID = cf;
                AD.BookingID = cfid;
                ViewBag.Appointment = cAppointmentBooking.ManageAppointmentBooking(AB);

                if (ViewBag.Appointment.Count > 0)
                {
                    AD.PatientName = ViewBag.Appointment[0].PatientName;
                    AD.PatientID = ViewBag.Appointment[0].PatientId;
                    AD.PatientDOB = ViewBag.Appointment[0].PatientDOB;
                    AD.SuccessfulAppointment = ViewBag.Appointment[0].SuccessfulAppointment;
                }

                Obj.AppointmentBookingID = cf;
                Obj.BookingID = cfid;
                AD.MedicineList = cAppointmentBooking.ManagePrescriptionMedicine(Obj);

                ePrescriptionDetails PD = new ePrescriptionDetails();
                PD.AppointmentBookingID = cf;
                PD.BookingID = cfid;

                ViewBag.PetientgeneralInfo = cAppointmentBooking.ManagePrescriptionDetails(PD);
                if (ViewBag.PetientgeneralInfo.Count > 0)
                {
                    AD.PatientHeight = ViewBag.PetientgeneralInfo[0].PatientHeight;
                    AD.PatientWeight = ViewBag.PetientgeneralInfo[0].PatientWeight;
                    AD.PatientBPHigh = ViewBag.PetientgeneralInfo[0].PatientBPHigh;
                    AD.PatientBPLow = ViewBag.PetientgeneralInfo[0].PatientBPLow;
                    AD.Description = ViewBag.PetientgeneralInfo[0].Description;
                }

            }



            if (AD.MedicineList == null || AD.MedicineList.Count == 0)
            {
                AD.MedicineList = new List<eMedicine>();
                Obj.MedicineName = null;
                Obj.MedicineUsing = null;
                AD.MedicineList.Add(Obj);
            }

            eAppoinmentBooking ApBooking = new eAppoinmentBooking();
            ApBooking.BookingID = AD.BookingID;
            ApBooking.PatientId = AD.PatientID;
            ViewBag.PreviousList = cAppointmentBooking.ManageAppointmentBookingForPrescription(ApBooking);

            return View(AD);
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


        public JsonResult GetBookingDetails(string bookingID, string appointmentBookingID)
        {
            eAppoinmentBooking AB = new eAppoinmentBooking();
            eAppoinmentBooking data = new eAppoinmentBooking();

            AB.AppointmentBookingID = appointmentBookingID;            
            ViewBag.Appointment = cAppointmentBooking.ManageAppointmentBooking(AB);

            if (ViewBag.Appointment.Count > 0)
            {
                data.PatientName = ViewBag.Appointment[0].PatientName;
                data.PatientID = ViewBag.Appointment[0].PatientId;
                data.PatientDOB = ViewBag.Appointment[0].PatientDOB;
                data.SuccessfulAppointment = ViewBag.Appointment[0].SuccessfulAppointment;
            }

            eMedicine ObjMedi = new eMedicine();

            ObjMedi.AppointmentBookingID = appointmentBookingID;
            //ObjMedi.BookingID = cfid;
            ViewBag.MedicineList = cAppointmentBooking.ManagePrescriptionMedicine(ObjMedi);
            //data.MedicineList = cAppointmentBooking.ManagePrescriptionMedicine(ObjMedi);

            ePrescriptionDetails PD = new ePrescriptionDetails();
            //PD.AppointmentBookingID = cf;
            PD.AppointmentBookingID = appointmentBookingID;
            PD.BookingID = bookingID;
            ViewBag.PetientgeneralInfo = cAppointmentBooking.ManagePrescriptionDetails(PD);
            if (ViewBag.PetientgeneralInfo.Count > 0)
            {
                data.PatientHeight = ViewBag.PetientgeneralInfo[0].PatientHeight;
                data.PatientWeight = ViewBag.PetientgeneralInfo[0].PatientWeight;
                data.PatientBPHigh = ViewBag.PetientgeneralInfo[0].PatientBPHigh;
                data.PatientBPLow = ViewBag.PetientgeneralInfo[0].PatientBPLow;
                data.Description = ViewBag.PetientgeneralInfo[0].Description;
            }



            return Json(data);
        }

        [HttpGet]
        public JsonResult GetData()
        {
            // Example data
            eAppoinmentBooking obj = new eAppoinmentBooking();
            obj.DoctorId = Convert.ToInt32(CommonHelper.GetCookieEntityTypeID(Request));
            var AppointmentList = cAdmin.Manage7DaysAppointment(obj);

            var data = new
            {
                //labels = new[] { "January", "February", "March" },
                //values = new[] { 10, 20, 30 }
                labels = AppointmentList.Select(a => a.AppointmentDate).ToArray(),
                values = AppointmentList.Select(a => a.AppointmentCount).ToArray()
            };

            return Json(data);
        }
    }
}
