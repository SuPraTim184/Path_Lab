using Microsoft.AspNetCore.Mvc;
using Path_Lab_ENTITY;
using Path_Lab_HELPER;
using System.Net.Mail;

namespace Path_Lab_WEB.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult AddEditEmployee(int id, string cf, string cfid, eEmployee BD, string Command, List<IFormFile> Attachments)
        {
            if (!CommonHelper.IsAuthenticate(Request) && CommonHelper.GetCookieUserTypeID(Request) == "10")
            {
                return RedirectToAction("Login", "Home");
            }

            {
                eEmployee CB = new eEmployee();

                if (Command == "Save")
                {
                    if (!string.IsNullOrEmpty(BD.EmployeeName))
                    {
                        CB.EmployeeId = BD.EmployeeId;
                        CB.EmployeeName = BD.EmployeeName;
                        CB.Degination = BD.Degination;
                        CB.Gender = BD.Gender;
                        CB.PhoneNumber = BD.PhoneNumber;
                        CB.DateOfJoining = BD.DateOfJoining;
                        CB.Email = BD.Email;
                        CB.Address = BD.Address;
                        CB.PinCode = BD.PinCode;
                        CB.Qualification = BD.Qualification;
                        CB.Type = BD.Type;
                        CB.IsAvailable = BD.IsAvailable;

                        if (BD.IsActive == null)
                        {
                            CB.IsActive = true;
                        }
                        else
                        {
                            CB.IsActive = BD.IsActive;
                        }



                        string vFileExt = "";
                        string vSFileName = "";


                        string FilePath = "wwwroot/Profile";
                        string ProfileDirectory = Path.Combine(Directory.GetCurrentDirectory(), FilePath);


                        if (!Directory.Exists(ProfileDirectory))
                        {
                            Directory.CreateDirectory(ProfileDirectory);
                        }

                        foreach (IFormFile file in Attachments)
                        {
                            if (string.IsNullOrWhiteSpace(file.FileName))
                            {
                                continue;
                            }
                            vFileExt = System.IO.Path.GetExtension(file.FileName);

                            try
                            {
                                vSFileName = $"{CB.EmployeeName.Replace(" ", "-")}_{DateTime.Now.ToString("MMddyyyyhhmmssfff")}{vFileExt}";
                                string SavePath = $"{ProfileDirectory}/{vSFileName}";
                                using (var stream = new FileStream(SavePath, FileMode.Create))
                                {
                                    file.CopyTo(stream);
                                }

                                CB.ImagePath = vSFileName;

                            }
                            catch (Exception ex)
                            {
                            }
                        }


                        string vEmployeeID = cEmployee.AddEditEmployee(CB);

                        if (vEmployeeID != "")
                        {
                            return RedirectToAction("ManageEmployee", "Employee");
                        }
                    }
                }
                if (id != 0)
                {
                    eEmployee Obj = new eEmployee();

                    Obj.EmployeeId = id;

                    var EmployeeDetails = cEmployee.ManageEmployee(Obj);

                    if (EmployeeDetails.Count > 0)
                    {
                        CB = EmployeeDetails[0];
                    }
                }
                return View(CB);
            }


        }

        public IActionResult ManageEmployee(int id, string cf, string cfid, eEmployee LD, string Command)
        {
            if (!CommonHelper.IsAuthenticate(Request) && CommonHelper.GetCookieUserTypeID(Request) == "10")
            {
                return RedirectToAction("Login", "Home");
            }
            {
                eEmployee Obj = new eEmployee();

                if (Command == "Search")
                {
                    if (!string.IsNullOrEmpty(LD.Degination))
                    {
                        Obj.Degination = LD.Degination;
                    }
                    if (!string.IsNullOrEmpty(LD.EmployeeName))
                    {
                        Obj.EmployeeName = LD.EmployeeName;
                    }
                    if (LD.Type != null)
                    {
                        Obj.Type = LD.Type;
                    }
                    if (!string.IsNullOrEmpty(LD.PhoneNumber))
                    {
                        Obj.PhoneNumber = LD.PhoneNumber;
                    }
                }


                Obj.IsActive = true;
                
                ViewBag.EmployeeDetail = cEmployee.ManageEmployee(Obj);

                if (Command == "EmployeeDelete")
                {

                    //Obj.EmployeeId = LD.EmployeeId;
                    if(id !=null )
                    {
                        Obj.EmployeeId= id;                        
                    }
                    List<eEmployee> abc = cEmployee.ManageEmployee(Obj);
                    Obj = abc[0];
                    Obj.IsActive = false;

                    

                    string vEmployeeId = cEmployee.AddEditEmployee(Obj);

                    //return RedirectToAction("ManageEmployee", "Employee");
                    //return View();
                    return RedirectToRoute(new { controller = "Employee", action = "ManageEmployee" });
                }


                return View();
            }
        }

        public IActionResult ViewEmployee(int id, string cf, string cfid, eEmployee LD)
        {
            if (!CommonHelper.IsAuthenticate(Request) && CommonHelper.GetCookieUserTypeID(Request) == "10")
            {
                return RedirectToAction("Login", "Home");
            }
            eEmployee CB = new eEmployee(); 
            if (id != 0)
            {
                eEmployee Obj = new eEmployee();

                Obj.EmployeeId = id;

                var EmployeeDetails = cEmployee.ManageEmployee(Obj);

                if (EmployeeDetails.Count > 0)
                {
                    CB = EmployeeDetails[0];
                }
            }
            return View(CB);
        }

        //public IActionResult EmployeeDashBoard(int id, string cf,string cfid)
        //{
        //    return View();
        //}
    }
}
