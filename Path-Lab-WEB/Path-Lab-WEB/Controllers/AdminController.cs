using Microsoft.AspNetCore.Mvc;
using Path_Lab_ENTITY;
using Path_Lab_HELPER;

namespace Path_Lab_WEB.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PaymentDetails(ePaymentDetails PD,string Command)
        {
            if (!CommonHelper.IsAuthenticate(Request) && CommonHelper.GetCookieUserTypeID(Request) == "10")
            {
                return RedirectToAction("Login", "Home");
            }

            ePaymentDetails ObjPD = new ePaymentDetails();

            if(Command == "Search")
            {
                ObjPD.ToDate = PD.ToDate;
                ObjPD.FromDate = PD.FromDate;
                ObjPD.PayType = PD.PayType;
                ObjPD.EntityTypeID = PD.EntityTypeID;
            }

            ViewBag.PaymentDetailsList = cAdmin.ManagePaymentDetails(ObjPD);

            return View();
        }
         
        public IActionResult PaymentTransactionDetails(ePaymentTransactionDetails PD,string Command)
        {
            if (!CommonHelper.IsAuthenticate(Request) && CommonHelper.GetCookieUserTypeID(Request) == "10")
            {
                return RedirectToAction("Login", "Home");
            }

            ePaymentTransactionDetails ObjPD = new ePaymentTransactionDetails();

            if(Command == "Search")
            {
                ObjPD.ToDate = PD.ToDate;
                ObjPD.FromDate = PD.FromDate;
            }

            ViewBag.PaymentTransactionDetailsList = cAdmin.ManagePaymentTransactionDetails(ObjPD);

            return View();
        }

        public IActionResult ManageEmployeePresentdaily(string cf, string cfid, int? id, eEmployeePunchDetails EPDs, string Command)
        {
            if (!CommonHelper.IsAuthenticate(Request))
            {
                return RedirectToAction("login", "home");
            }
            else
            {
                eEmployeePunchDetails Obj = new eEmployeePunchDetails();
                if (Command == "Search")
                {
                    Obj.EmployeeName = EPDs.EmployeeName;
                    Obj.punchInTime = EPDs.punchInTime;
                }
                Obj.IsActive = true;

                if (Obj.punchInTime == null)
                {
                    Obj.punchInTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
                }
                ViewBag.EmployeePunchDetail = cAdmin.ManageEmployeePresent(Obj);

                if (EPDs.punchInTime == null)
                {
                    ViewBag.Date = DateTime.Now;
                }
                else
                {
                    ViewBag.Date = Obj.punchInTime;
                }

                return View();
            }
        }
    
        public IActionResult TestCancelDetails(eTestBookingCancel PD, string Command)
        {
            if (!CommonHelper.IsAuthenticate(Request))
            {
                return RedirectToAction("login", "home");
            }

            eTestBookingCancel ObjPD = new eTestBookingCancel();

            if (Command == "Search")
            {
                ObjPD.ToDate = PD.ToDate;
                ObjPD.FromDate = PD.FromDate;
            }

            ViewBag.TestCancelDetailsList = cAdmin.ManageCancelTestBooking(ObjPD);


            return View();
        }
    
        public IActionResult AppointmentCancelDetails(eAppointmentCancel PD, string Command)
        {
            if (!CommonHelper.IsAuthenticate(Request))
            {
                return RedirectToAction("login", "home");
            }

            eAppointmentCancel ObjPD = new eAppointmentCancel();

            if (Command == "Search")
            {
                ObjPD.ToDate = PD.ToDate;
                ObjPD.FromDate = PD.FromDate;
            }

            ViewBag.AppointmentCancelDetailsList = cAdmin.ManageCancelAppointmentBooking(ObjPD);


            return View();
        }
    
    
    }
}
