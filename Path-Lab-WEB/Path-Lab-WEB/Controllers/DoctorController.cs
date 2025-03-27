using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Path_Lab_ENTITY;
using Path_Lab_HELPER;
using System.Net.Mail;

namespace Path_Lab_WEB.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult AddEditDoctor(int id, string cf, string cfid, eDoctor BD, string Command, List<IFormFile> Attachments)
        {
            if (!CommonHelper.IsAuthenticate(Request) && CommonHelper.GetCookieUserTypeID(Request) == "10")
            {
                return RedirectToAction("Login", "Home");
            }

            {
                eDoctor CB = new eDoctor();

                if (Command == "Save")
                {
                    if (!string.IsNullOrEmpty(BD.DoctorName))
                    {
                        CB.DoctorId = BD.DoctorId;
                        CB.DoctorName = BD.DoctorName;
                        CB.Gender = BD.Gender;
                        CB.PhoneNumber = BD.PhoneNumber;
                        CB.Email = BD.Email;
                        CB.Address = BD.Address;
                        CB.PinCode = BD.PinCode;
                        CB.Specialization = BD.Specialization;
                        CB.Qualification = BD.Qualification;
                        CB.JoiningDate = BD.JoiningDate;
                        CB.Availablechambers = BD.Availablechambers;                        
                        CB.IsAvailable = BD.IsAvailable;                        
                        CB.Fees = BD.Fees;
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
                                vSFileName = $"{CB.DoctorName.Replace(" ", "-")}_{DateTime.Now.ToString("MMddyyyyhhmmssfff")}{vFileExt}";
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


                        string vEmployeeID = cDoctor.AddEditDoctor(CB);

                        if (vEmployeeID != "")
                        {
                            return RedirectToAction("ManageDoctor", "Doctor");
                        }
                    }
                }
                if (id != 0)
                {
                    eDoctor Obj = new eDoctor();

                    Obj.DoctorId = id;

                    var DoctorIdDetails = cDoctor.ManageDoctor(Obj);

                    if (DoctorIdDetails.Count > 0)
                    {
                        CB = DoctorIdDetails[0];
                    }
                }
                return View(CB);
            }


        }

        public IActionResult ManageDoctor(int id, string cf, string cfid, eDoctor LD, string Command)
        {
            if (!CommonHelper.IsAuthenticate(Request) && CommonHelper.GetCookieUserTypeID(Request) == "10")
            {
                return RedirectToAction("Login", "Home");
            }
            {
                eDoctor Obj = new eDoctor();

                if (Command == "Search")
                {
                    if (!string.IsNullOrEmpty(LD.Specialization))
                    {
                        Obj.Specialization = LD.Specialization;
                    }
                    if (!string.IsNullOrEmpty(LD.DoctorName))
                    {
                        Obj.DoctorName = LD.DoctorName;
                    }
                    if (LD.Qualification != null)
                    {
                        Obj.Qualification = LD.Qualification;
                    }
                    if (!string.IsNullOrEmpty(LD.PhoneNumber))
                    {
                        Obj.PhoneNumber = LD.PhoneNumber;
                    }
                }

                Obj.IsActive = true;                
                ViewBag.DoctorDetail = cDoctor.ManageDoctor(Obj);

                if (Command == "DoctorDelete")
                {
                    if (id != null)
                    {
                        Obj.DoctorId = id;
                    }
                    List<eDoctor> abc = cDoctor.ManageDoctor(Obj);
                    Obj = abc[0];
                    Obj.IsActive = false;

                    string vDoctorId = cDoctor.AddEditDoctor(Obj);

                    return RedirectToAction("ManageDoctor", "Doctor");
                }


                return View();
            }
        }

        public IActionResult ViewDoctor(int id, string cf, string cfid, eDoctor LD)
        {
            if (!CommonHelper.IsAuthenticate(Request) && CommonHelper.GetCookieUserTypeID(Request) == "10")
            {
                return RedirectToAction("Login", "Home");
            }
            eDoctor CB = new eDoctor();
            if (id != 0)
            {
                eDoctor Obj = new eDoctor();

                Obj.DoctorId = id;

                var DoctorDetails = cDoctor.ManageDoctor(Obj);

                if (DoctorDetails.Count > 0)
                {
                    CB = DoctorDetails[0];

                }
            }
            return View(CB);
        }

        public IActionResult GetDoctorFees(int id)
        {
            try
            {

                eDoctor SGM = new eDoctor();
                List<eDoctor> SGMLM = new List<eDoctor>();
                if (id > 0)
                {
                    SGM.DoctorId = id;
                    SGMLM = cDoctor.ManageDoctor(SGM);

                    SGM = SGMLM[0];
                }
                string JsonString = JsonConvert.SerializeObject(SGM);

                return Content(JsonString, "application/json");
            }
            catch (Exception ex)
            {
                return Json(null); // You can customize the response for error handling
            }


        }

    }
}
