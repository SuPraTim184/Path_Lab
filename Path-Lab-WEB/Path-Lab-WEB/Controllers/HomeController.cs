using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using Path_Lab_WEB.Models;
using System.Diagnostics;
using System.Net.Sockets;
using System.Net;
using Path_Lab_ENTITY;
using Path_Lab_HELPER;
using System.Net.Mail;
using System.Data.SqlClient;

namespace Path_Lab_WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }



        public IActionResult Index()
        {
            eDashBoard obj = new eDashBoard();
            ViewBag.ListCount = cAdmin.DashBoardDetails(obj);

            if (ViewBag.ListCount.Count > 0)
            {
                obj = ViewBag.ListCount[0];
            }
            return View(obj);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login(eLogin U)
        {
            ViewBag.Message = "Please enter your Username and  Password.";
            string currentPath = HttpContext.Request.Path;
            try
            {
                if (!String.IsNullOrEmpty(U.UserName))
                {
                    string host = Dns.GetHostName();
                    IPHostEntry ip = Dns.GetHostEntry(host);
                    foreach (IPAddress ipAddress in ip.AddressList)
                    {
                        if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
                        {
                            U.ClientIP = Convert.ToString(ipAddress);
                        }
                        else if (ipAddress.AddressFamily == AddressFamily.InterNetworkV6)
                        {
                        }
                    }

                    U.ClientIP = ip.AddressList[3].ToString();
                    U.LoginDevice = CommonHelper.GetDeviceType();
                    //U.ClientIPV6 = ip.AddressList[2].ToString();
                    U.ClientMac = CommonHelper.GetMACAddress();
                    U.LoginDeviceName = Environment.MachineName;
                    U.LoginDeviceOs = Environment.OSVersion.VersionString;

                    List<eUser> lstUserDetail = new List<eUser>();
                    cUsers.ValidateUser(U, out lstUserDetail);
                    if (lstUserDetail != null && lstUserDetail.Count() > 0)
                    {
                        CommonHelper.SaveCookie(Response, "IsAuthenticate", "True", 1);
                        CommonHelper.SaveCookie(Response, "UserId", lstUserDetail[0].UserID.ToString(), 1);
                        CommonHelper.SaveCookie(Response, "PP", lstUserDetail[0].ProfilePicture, 1);
                        CommonHelper.SaveCookie(Response, "UFullName", lstUserDetail[0].FullName.ToString(), 1);
                        CommonHelper.SaveCookie(Response, "UserTypeID", lstUserDetail[0].UserTypeID.ToString(), 1);
                        CommonHelper.SaveCookie(Response, "EntityTypeID", lstUserDetail[0].EntityTypeID.ToString(), 1);
                        CommonHelper.SaveCookie(Response, "UserName", lstUserDetail[0].UserName.ToString(), 1);
                        //CommonHelper.SaveCookie(Response, "LoginDetailsID", lstUserDetail[0].LoginDetailsID.ToString(), 1);

                        if (!string.IsNullOrEmpty(lstUserDetail[0].DefaultLanding))
                        {
                            return Redirect(lstUserDetail[0].DefaultLanding.ToString());
                        }
                        else
                        {
                            ViewBag.UserName = CommonHelper.GetCookieUserName(Request);
                            if (lstUserDetail[0].UserTypeID == 20)
                            {
                                return RedirectToAction("DoctorDashBoard", "DoctorWork");
                            }
                            if (lstUserDetail[0].UserTypeID == 30)
                            {
                                return RedirectToAction("EmployeeDashBoard", "EmployeeWork");
                            }
                            if (lstUserDetail[0].UserTypeID == 10)
                            {
                                return RedirectToAction("Index", "Home");
                            }
                            if (lstUserDetail[0].UserTypeID == 40)
                            {
                                return Redirect("~/PathLab/Index");
                            }
                            if (lstUserDetail[0].UserTypeID == 30)
                            {
                                return Redirect("~/Employee/EmployeeDashBoard");
                            }
                            else
                            {
                                return Redirect("~/PathLab/Index");
                            }
                        }

                    }
                }
                else
                {
                    ViewBag.Message = "Sign in to start your session";
                }
            }

            catch (Exception)
            {
                ViewBag.Message = "Please Enter a valid User Name  and Password";
            }



            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }

            return View();
        }

        public IActionResult logout()
        {
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            //return RedirectToAction("Index", "PathLab");
            return Redirect("~/PathLab/Index");
        }

        public IActionResult ForgotPassword(eLogin U)
        {
            string currentPath = HttpContext.Request.Path;
            string SiteUl = _configuration["BaseSiteURL:DefaultBaseSiteURL"];

            eLogin obj = new eLogin();
            List<eUser> UListObj = new List<eUser>();
            if (U.UserName != null)
            {
                obj.UserName = U.UserName;

                cUsers.GetUser(U, out UListObj);
                if (UListObj.Count > 0)
                {
                    try
                    {
                        //SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                        //{
                        //    Port = 587,
                        //    UseDefaultCredentials = true,
                        //    Credentials = new NetworkCredential("sasusabhan084@gmail.com", "tkgmvuesrcucmodx"),
                        //    EnableSsl = true
                        //};

                        //MailMessage message = new MailMessage
                        //{
                        //    From = new MailAddress("sahasusabhan084@gmail.com", "Your Lab,"),
                        //    Subject = "Update Your Password",
                        //    Body = "<h1>Please Click To The Link</h1>\r\n<p>Link : " + SiteUl + "http://https://localhost:7032/Home/ResetUserPassword?id=" + UListObj[0].UserID + "</p>\r\n<p>From,<br>&nbsp;&nbsp;Your Lab</p>",
                        //    IsBodyHtml = true
                        //};

                        //if (!string.IsNullOrEmpty(UListObj[0].UserName))
                        //{
                        //    message.To.Add(UListObj[0].UserName);
                        //}
                        //smtpClient.Send(message);
                        string fromMail = "sahasusabhan084@gmail.com";
                        string fromPassword = "fmwgzxzidufcgnsv";

                        MailMessage message = new MailMessage();
                        message.From = new MailAddress(fromMail);
                        message.Subject = "Update Your Password";
                        message.To.Add(new MailAddress(UListObj[0].UserName));
                        message.Body = "<h1>Please Click To The Link</h1>\r\n<p>Link : " + SiteUl + "Home/UpdatePassword?id=" + UListObj[0].UserID + "</p>\r\n<p>From,<br>&nbsp;&nbsp;Your Lab</p>";
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
                        throw ex;
                    }


                    ViewBag.Message = "Go to Mail (" + UListObj[0].UserName + ") and Update Password ";
                }
                else
                {
                    ViewBag.Message = "Your Entered Invalid Email";
                }

            }
            return View();
        }
        public IActionResult UpdatePassword(string id, eUser U, string Command)
        {
            string currentPath = HttpContext.Request.Path;

            eLogin obj = new eLogin();
            List<eUser> UListObj = new List<eUser>();
            eUser user = new eUser();

            try
            {
                if (id != null)
                {
                    obj.UserID = id;

                    cUsers.GetUser(obj, out UListObj);

                    if (UListObj.Count > 0)
                    {
                        user.UserID = UListObj[0].UserID;
                        user.UserName = UListObj[0].UserName;
                        user.FullName = UListObj[0].FullName;
                        user.UserTypeID = UListObj[0].UserTypeID;

                    }
                }
                if (Command == "UpdatePassword")
                {
                    user.UserID = U.UserID;
                    user.LoginPassword = U.LoginPassword;

                    var USERID = cUsers.UpdatePassword(user);
                    if (USERID != null)
                    {
                        ViewBag.Message = "Password Updated Successfully";
                    }
                    return View();
                }
            }
            catch (Exception Ex)
            {

            }
            return View(user);
        }

        public async Task<JsonResult> GetDailyTransactions(DateTime? startDate, DateTime? endDate)
        {
            eDashBoard DB = new eDashBoard();
            //startDate = startDate ?? new DateTime(DateTime.Now.Year, 1, 1);
            //if (endDate == null) endDate = DateTime.Now;

            startDate = startDate ?? new DateTime(2024, 1, 1);
            endDate = endDate ?? new DateTime(2024, 12, 31);

            DB.StartDate = startDate;
            DB.EndDate = endDate;

            var transactions = new List<eDashBoard>();
            transactions = cAdmin.GetDataForCalender(DB);

            return Json(transactions);
        }

        [HttpGet]
        public JsonResult GetBookingData(string period)
        {
            //    // Replace these sample data arrays with actual data retrieval from your database
            //    var bookingData = new Dictionary<string, int[]>
            //{
            //    { "week", new int[] { 2, 4, 6, 8, 3, 7, 5 } },
            //    { "month", new int[] { 30, 40, 50, 60, 45, 55, 35, 70, 60, 80, 90, 100 } },
            //    { "year", new int[] { 400, 450, 500, 550, 520, 480, 490, 530, 560, 610, 580, 600 } },
            //    { "5year", new int[] { 2000, 2500, 2700, 3000, 3200 } }
            //};

            //    var labels = new Dictionary<string, string[]>
            //{
            //    { "week", new string[] { "Day 1", "Day 2", "Day 3", "Day 4", "Day 5", "Day 6", "Day 7" } },
            //    { "month", new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" } },
            //    { "year", new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" } },
            //    { "5year", new string[] { "Year 1", "Year 2", "Year 3", "Year 4", "Year 5" } }
            //};

            //var result = new
            //{
            //    data = bookingData[period],
            //    labels = labels[period]
            //};
            
            eTestBooking obj = new eTestBooking();
            obj.period = period;
            ViewBag.CountList = cAdmin.ManageForTestChart(obj);

            var countList = ViewBag.CountList as IEnumerable<dynamic>;

            var result = new
            {
                data = countList?.Select(item => (int)item.TotalTest).ToArray(),
                labels = countList?.Select(item => (string)item.Name).ToArray()
            };

            return Json(result);
        }
        
        [HttpGet]
        public JsonResult GetAppointmentBookingData(string period)
        {
                      
            eTestBooking obj = new eTestBooking();
            obj.period = period;
            ViewBag.CountList = cAdmin.ManageForAppointmentChart(obj);

            var countList = ViewBag.CountList as IEnumerable<dynamic>;

            var result = new
            {
                data = countList?.Select(item => (int)item.TotalTest).ToArray(),
                labels = countList?.Select(item => (string)item.Name).ToArray()
            };

            return Json(result);
        }

    }
}