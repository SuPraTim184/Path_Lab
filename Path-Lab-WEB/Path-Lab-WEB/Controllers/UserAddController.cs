using Microsoft.AspNetCore.Mvc;
using Path_Lab_ENTITY;
using Path_Lab_HELPER;
using System.Net.Mail;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

namespace Path_Lab_WEB.Controllers
{
    public class UserAddController : Controller
    {
        public IActionResult AddEditAdmin(string id, string cf, string cfid, eUser FC, string Command, IFormFile postedPPFile)
        {

            {
                List<ePerson> lstPer = new List<ePerson>();
                try
                {
                    bool flg = true;

                    if (Command == "Save")
                    {
                        if (string.IsNullOrEmpty(FC.UserName))
                        {
                            TempData["Msg"] = "Please enter User Name!";
                            flg = false;
                        }

                        if (Command == "Save" && flg == true)
                        {
                            string ProfileImageName = "";

                            try
                            {
                                if (postedPPFile != null)
                                {
                                    ProfileImageName = Guid.NewGuid().ToString() + Path.GetExtension(postedPPFile.FileName);
                                    string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserProfile", ProfileImageName);
                                    using (var stream = new FileStream(SavePath, FileMode.Create))
                                    {
                                        postedPPFile.CopyTo(stream);
                                    }
                                }
                            }
                            catch (Exception)
                            {
                            }

                            eUser obj = new eUser();
                            obj.FullName = FC.FullName;
                            obj.PrimaryEmail = FC.PrimaryEmail;
                            obj.PrimaryPhone = FC.PrimaryPhone;
                            obj.EntityTypeID = FC.EntityTypeID;
                            obj.EntityID = FC.EntityID;
                            obj.UserTypeID = 10;
                            obj.SecurityGroupID = FC.SecurityGroupID;
                            obj.UserName = FC.UserName;
                            obj.LoginPassword = FC.LoginPassword;
                            obj.PasswordStart = FC.PasswordStart;
                            obj.PasswordExpire = FC.PasswordExpire;
                            obj.IsLocked = FC.IsLocked;

                            if (obj.StatusId == 0)
                            {
                                obj.IsActive = false;
                            }
                            else
                            {
                                obj.IsActive = true;
                            }

                            //obj.ActorID = CommonHelper.GetCookieUserID(Request);
                            obj.OrgID = CommonHelper.GetCookieOrgID(Request);
                            if (ProfileImageName != "")
                            {
                                obj.ProfilePicture = ProfileImageName;
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(FC.ProfilePicture))
                                {
                                    obj.ProfilePicture = FC.ProfilePicture;
                                }
                                else
                                {
                                    obj.ProfilePicture = "noimage.jpg";
                                }
                            }
                            if (FC.UserID != null)
                            {
                                if (!string.IsNullOrEmpty(FC.UserID.ToString()))
                                {
                                    obj.UserID = FC.UserID;
                                }
                            }
                            cUsers obju = new cUsers();
                            string vUserID = cUsers.AddEditUser(obj);
                            if (vUserID == "UserName already exists")
                            {
                                ViewBag.Alert = "UserName already exists, Please Change User Name";
                                return View(obj);
                            }

                            return RedirectToAction("ManageUser", "security");
                        }
                    }

                    else
                    {
                        if (!string.IsNullOrEmpty(id))
                        {
                            List<eUser> lst = new List<eUser>();
                            eUser obj = new eUser();
                            obj.UserID = id;
                            obj.IsActive = true;
                            lst = cUsers.ManageUser(obj);

                            if (lst.Count > 0)
                            {
                                FC = lst[0];
                                ePerson objpe = new ePerson();
                                objpe.IsActive = true;
                                objpe.EntityTypeID = lst[0].EntityTypeID;
                                //lstPer = cUsers.ManagePerson(objpe);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }


                //ViewBag.managePer = lstPer;

                //eLupUserType LUT = new eLupUserType();
                //LUT.IsActive = true;
                //LUT.IsPublic = true;
                //ViewBag.eLupUserType = cLookup.ManageLupUserType(LUT);

                //eSecurityGroup SG = new eSecurityGroup();
                //SG.IsActive = true;
                //ViewBag.eSecurityGroup = cLookup.ManageLupSecuritygroup(SG);

                return View(FC);
            }
        }
        public IActionResult AddEditEmployeeRegistration(string id, string cf, string cfid, eUser FC, string Command, IFormFile postedPPFile)
        {
            if (!CommonHelper.IsAuthenticate(Request) && CommonHelper.GetCookieUserTypeID(Request) == "10")
            {
                return RedirectToAction("Login", "Home");
            }
            {
                List<ePerson> lstPer = new List<ePerson>();
                try
                {
                    bool flg = true;

                    if (Command == "Save")
                    {
                        if (string.IsNullOrEmpty(FC.UserName))
                        {
                            TempData["Msg"] = "Please enter User Name!";
                            flg = false;
                        }

                        if (Command == "Save" && flg == true)
                        {
                            string ProfileImageName = "";

                            try
                            {
                                if (postedPPFile != null)
                                {
                                    ProfileImageName = Guid.NewGuid().ToString() + Path.GetExtension(postedPPFile.FileName);
                                    string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserProfile", ProfileImageName);
                                    using (var stream = new FileStream(SavePath, FileMode.Create))
                                    {
                                        postedPPFile.CopyTo(stream);
                                    }
                                }
                            }
                            catch (Exception)
                            {
                            }

                            eUser obj = new eUser();
                            obj.FullName = FC.FullName;
                            obj.PrimaryEmail = FC.PrimaryEmail;
                            obj.PrimaryPhone = FC.PrimaryPhone;
                            obj.EntityTypeID = FC.EntityTypeID;
                            obj.EntityID = FC.EntityID;
                            obj.UserTypeID = 30;
                            obj.SecurityGroupID = FC.SecurityGroupID;
                            obj.UserName = FC.UserName;
                            obj.LoginPassword = FC.LoginPassword;
                            obj.PasswordStart = FC.PasswordStart;
                            obj.PasswordExpire = FC.PasswordExpire;
                            obj.IsLocked = FC.IsLocked;

                            if (obj.StatusId == 0)
                            {
                                obj.IsActive = false;
                            }
                            else
                            {
                                obj.IsActive = true;
                            }

                            //obj.ActorID = CommonHelper.GetCookieUserID(Request);
                            obj.OrgID = CommonHelper.GetCookieOrgID(Request);
                            if (ProfileImageName != "")
                            {
                                obj.ProfilePicture = ProfileImageName;
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(FC.ProfilePicture))
                                {
                                    obj.ProfilePicture = FC.ProfilePicture;
                                }
                                else
                                {
                                    obj.ProfilePicture = "noimage.jpg";
                                }
                            }
                            if (FC.UserID != null)
                            {
                                if (!string.IsNullOrEmpty(FC.UserID.ToString()))
                                {
                                    obj.UserID = FC.UserID;
                                }
                            }
                            cUsers obju = new cUsers();
                            string vUserID = cUsers.AddEditUser(obj);
                            if (vUserID == "UserName already exists")
                            {
                                ViewBag.Alert = "UserName already exists, Please Change User Name";
                                return View(obj);
                            }

                            return RedirectToAction("AddEditEmployeeRegistration", "UserAdd");
                        }
                    }

                    else
                    {
                        if (!string.IsNullOrEmpty(id))
                        {
                            List<eUser> lst = new List<eUser>();
                            eUser obj = new eUser();
                            obj.UserID = id;
                            obj.IsActive = true;
                            lst = cUsers.ManageUser(obj);

                            if (lst.Count > 0)
                            {
                                FC = lst[0];
                                ePerson objpe = new ePerson();
                                objpe.IsActive = true;
                                objpe.EntityTypeID = lst[0].EntityTypeID;
                                //lstPer = cUsers.ManagePerson(objpe);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }

                eLupUserTypeTable LUT = new eLupUserTypeTable();
                LUT.IsActive = true;
                ViewBag.eLupUserType = cAdmin.ManageLupUserType(LUT);

                eEmployee Obj = new eEmployee();
                Obj.IsActive = true;
                ViewBag.EmployeeDetail = cEmployee.ManageEmployee(Obj);


                return View(FC);
            }
        }
        public IActionResult AddEditDoctorRegistration(string id, string cf, string cfid, eUser FC, string Command, IFormFile postedPPFile)
        {
            if (!CommonHelper.IsAuthenticate(Request) && CommonHelper.GetCookieUserTypeID(Request) == "10")
            {
                return RedirectToAction("Login", "Home");
            }
            {
                List<ePerson> lstPer = new List<ePerson>();
                try
                {
                    bool flg = true;

                    if (Command == "Save")
                    {
                        if (string.IsNullOrEmpty(FC.UserName))
                        {
                            TempData["Msg"] = "Please enter User Name!";
                            flg = false;
                        }

                        if (Command == "Save" && flg == true)
                        {
                            string ProfileImageName = "";

                            try
                            {
                                if (postedPPFile != null)
                                {
                                    ProfileImageName = Guid.NewGuid().ToString() + Path.GetExtension(postedPPFile.FileName);
                                    string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserProfile", ProfileImageName);
                                    using (var stream = new FileStream(SavePath, FileMode.Create))
                                    {
                                        postedPPFile.CopyTo(stream);
                                    }
                                }
                            }
                            catch (Exception)
                            {
                            }

                            eUser obj = new eUser();
                            obj.FullName = FC.FullName;
                            obj.PrimaryEmail = FC.PrimaryEmail;
                            obj.PrimaryPhone = FC.PrimaryPhone;
                            obj.EntityTypeID = FC.EntityTypeID;
                            obj.EntityID = FC.EntityID;
                            obj.UserTypeID = 20;
                            obj.SecurityGroupID = FC.SecurityGroupID;
                            obj.UserName = FC.UserName;
                            obj.LoginPassword = FC.LoginPassword;
                            obj.PasswordStart = FC.PasswordStart;
                            obj.PasswordExpire = FC.PasswordExpire;
                            obj.IsLocked = FC.IsLocked;

                            if (obj.StatusId == 0)
                            {
                                obj.IsActive = false;
                            }
                            else
                            {
                                obj.IsActive = true;
                            }

                            //obj.ActorID = CommonHelper.GetCookieUserID(Request);
                            obj.OrgID = CommonHelper.GetCookieOrgID(Request);
                            if (ProfileImageName != "")
                            {
                                obj.ProfilePicture = ProfileImageName;
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(FC.ProfilePicture))
                                {
                                    obj.ProfilePicture = FC.ProfilePicture;
                                }
                                else
                                {
                                    obj.ProfilePicture = "noimage.jpg";
                                }
                            }
                            if (FC.UserID != null)
                            {
                                if (!string.IsNullOrEmpty(FC.UserID.ToString()))
                                {
                                    obj.UserID = FC.UserID;
                                }
                            }
                            cUsers obju = new cUsers();
                            string vUserID = cUsers.AddEditUser(obj);
                            if (vUserID == "UserName already exists")
                            {
                                ViewBag.Alert = "UserName already exists, Please Change User Name";
                                return View(obj);
                            }

                            return RedirectToAction("AddEditDoctorRegistration", "UserAdd");
                        }
                    }

                    else
                    {
                        if (!string.IsNullOrEmpty(id))
                        {
                            List<eUser> lst = new List<eUser>();
                            eUser obj = new eUser();
                            obj.UserID = id;
                            obj.IsActive = true;
                            lst = cUsers.ManageUser(obj);

                            if (lst.Count > 0)
                            {
                                FC = lst[0];
                                ePerson objpe = new ePerson();
                                objpe.IsActive = true;
                                objpe.EntityTypeID = lst[0].EntityTypeID;
                                //lstPer = cUsers.ManagePerson(objpe);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }

                eLupUserTypeTable LUT = new eLupUserTypeTable();
                LUT.IsActive = true;
                ViewBag.eLupUserType = cAdmin.ManageLupUserType(LUT);

                eDoctor Obj = new eDoctor();
                Obj.IsActive = true;
                ViewBag.DoctorDetail = cDoctor.ManageDoctor(Obj);


                return View(FC);
            }
        }
        public IActionResult AddEditUser(string id, string cf, string cfid, eUser FC, string Command, IFormFile postedPPFile)
        {

            {
                List<ePerson> lstPer = new List<ePerson>();
                try
                {
                    bool flg = true;

                    if (Command == "Save")
                    {
                        if (string.IsNullOrEmpty(FC.PrimaryEmail))
                        {
                            TempData["Msg"] = "Please enter User Name!";
                            flg = false;
                        }

                        if (Command == "Save" && flg == true)
                        {
                            string ProfileImageName = "";

                            try
                            {
                                if (postedPPFile != null)
                                {
                                    ProfileImageName = Guid.NewGuid().ToString() + Path.GetExtension(postedPPFile.FileName);
                                    string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserProfile", ProfileImageName);
                                    using (var stream = new FileStream(SavePath, FileMode.Create))
                                    {
                                        postedPPFile.CopyTo(stream);
                                    }
                                }
                            }
                            catch (Exception)
                            {
                            }

                            eUser obj = new eUser();
                            obj.FullName = FC.FullName;
                            obj.PrimaryEmail = FC.PrimaryEmail;
                            obj.PrimaryPhone = FC.PrimaryPhone;
                            obj.EntityTypeID = FC.EntityTypeID;
                            obj.EntityID = FC.EntityID;
                            obj.UserTypeID = 40;
                            obj.SecurityGroupID = FC.SecurityGroupID;
                            obj.UserName = FC.PrimaryEmail;
                            obj.LoginPassword = FC.LoginPassword;
                            obj.PasswordStart = Convert.ToDateTime("01.1.2024");
                            obj.PasswordExpire = Convert.ToDateTime("01.1.3024");
                            obj.IsLocked = FC.IsLocked;
                            obj.IsActive = true;


                            //obj.ActorID = CommonHelper.GetCookieUserID(Request);
                            obj.OrgID = CommonHelper.GetCookieOrgID(Request);
                            if (ProfileImageName != "")
                            {
                                obj.ProfilePicture = ProfileImageName;
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(FC.ProfilePicture))
                                {
                                    obj.ProfilePicture = FC.ProfilePicture;
                                }
                                else
                                {
                                    obj.ProfilePicture = "noimage.jpg";
                                }
                            }
                            if (FC.UserID != null)
                            {
                                if (!string.IsNullOrEmpty(FC.UserID.ToString()))
                                {
                                    obj.UserID = FC.UserID;
                                }
                            }
                            cUsers obju = new cUsers();
                            string vUserID = cUsers.AddEditUser(obj);

                            if (vUserID == "UserName already exists")
                            {
                                ViewBag.Alert = "UserName already exists, Please Change User Name";
                                return View(obj);
                            }

                            if (vUserID != "UserName already exists" && vUserID != null && vUserID != "")
                            {
                                ViewBag.Alert = "Account Created SuccessFully";
                                return View(obj);
                                //return RedirectToAction("Index","PathLab");
                            }

                            //return RedirectToAction("ManageUser", "security");
                        }
                    }

                    else
                    {
                        if (!string.IsNullOrEmpty(id))
                        {
                            List<eUser> lst = new List<eUser>();
                            eUser obj = new eUser();
                            obj.UserID = id;
                            obj.IsActive = true;
                            lst = cUsers.ManageUser(obj);

                            if (lst.Count > 0)
                            {
                                FC = lst[0];
                                ePerson objpe = new ePerson();
                                objpe.IsActive = true;
                                objpe.EntityTypeID = lst[0].EntityTypeID;
                                //lstPer = cUsers.ManagePerson(objpe);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }


                //ViewBag.managePer = lstPer;

                //eLupUserType LUT = new eLupUserType();
                //LUT.IsActive = true;
                //LUT.IsPublic = true;
                //ViewBag.eLupUserType = cLookup.ManageLupUserType(LUT);

                //eSecurityGroup SG = new eSecurityGroup();
                //SG.IsActive = true;
                //ViewBag.eSecurityGroup = cLookup.ManageLupSecuritygroup(SG);

                return View(FC);
            }
        }
        public IActionResult UserRegistration(string id, string cf, string cfid, eUser FC, eLogin LG, string Command)
        {

            {
                List<ePerson> lstPer = new List<ePerson>();
                try
                {
                    bool flg = true;

                    if (Command == "Save")
                    {
                        if (string.IsNullOrEmpty(FC.PrimaryEmail))
                        {
                            TempData["Msg"] = "Please enter User Name!";
                            flg = false;
                        }

                        if (Command == "Save" && flg == true)
                        {
                            string ProfileImageName = "";

                            eUser obj = new eUser();
                            obj.FullName = FC.FullName;
                            obj.PrimaryEmail = FC.PrimaryEmail;
                            obj.PrimaryPhone = FC.PrimaryPhone;
                            obj.EntityTypeID = FC.EntityTypeID;
                            obj.EntityID = FC.EntityID;
                            obj.UserTypeID = 40;
                            obj.SecurityGroupID = FC.SecurityGroupID;
                            obj.UserName = FC.PrimaryEmail;
                            obj.LoginPassword = FC.LoginPassword;
                            obj.PasswordStart = Convert.ToDateTime("01.1.2024");
                            obj.PasswordExpire = Convert.ToDateTime("01.1.3024");
                            obj.IsLocked = false;
                            obj.IsActive = true;


                            //obj.ActorID = CommonHelper.GetCookieUserID(Request);
                            obj.OrgID = CommonHelper.GetCookieOrgID(Request);
                            if (ProfileImageName != "")
                            {
                                obj.ProfilePicture = ProfileImageName;
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(FC.ProfilePicture))
                                {
                                    obj.ProfilePicture = FC.ProfilePicture;
                                }
                                else
                                {
                                    obj.ProfilePicture = "noimage.jpg";
                                }
                            }
                            if (FC.UserID != null)
                            {
                                if (!string.IsNullOrEmpty(FC.UserID.ToString()))
                                {
                                    obj.UserID = FC.UserID;
                                }
                            }
                            cUsers obju = new cUsers();
                            string vUserID = cUsers.AddEditUser(obj);

                            if (vUserID == "UserName already exists")
                            {
                                ViewBag.Alert = "UserName already exists, Please Change User Name";
                                return View(LG);
                            }

                            if (vUserID != "UserName already exists" && vUserID != null && vUserID != "")
                            {
                                ViewBag.Alert = "Account Created SuccessFully";
                                return View();
                                //return View(obj);
                                //return RedirectToAction("Index","PathLab");
                            }

                            //return RedirectToAction("ManageUser", "security");
                        }
                    }

                    else
                    {
                        if (!string.IsNullOrEmpty(id))
                        {
                            List<eUser> lst = new List<eUser>();
                            eUser obj = new eUser();
                            obj.UserID = id;
                            obj.IsActive = true;
                            lst = cUsers.ManageUser(obj);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }

                return View(LG);
            }
        }


        [HttpGet]
        public JsonResult EmployeePhone(int Id)
        {
            try
            {
                string PhoneNumber = "";
                eEmployee obj = new eEmployee();
                obj.EmployeeId = Id;
                obj.IsActive = true;
                var _GetEmail = (List<eEmployee>)null;
                _GetEmail = cEmployee.ManageEmployee(obj).ToList();

                if (_GetEmail.Count > 0)
                {
                    PhoneNumber = _GetEmail[0].PhoneNumber;
                }
                return Json(PhoneNumber);
            }
            catch (Exception)
            {

            }
            return Json(null);
        }
        
        [HttpGet]
        public JsonResult EmployeeName(int Id)
        {
            try
            {
                string EmployeeName = "";
                eEmployee obj = new eEmployee();
                obj.EmployeeId = Id;
                obj.IsActive = true;
                var _GetEmail = (List<eEmployee>)null;
                _GetEmail = cEmployee.ManageEmployee(obj).ToList();

                if (_GetEmail.Count > 0)
                {
                    EmployeeName = _GetEmail[0].EmployeeName;
                }
                return Json(EmployeeName);
            }
            catch (Exception)
            {

            }
            return Json(null);
        }
        
        [HttpGet]
        public JsonResult EmployeeEmail(int Id)
        {
            try
            {
                string Email = "";
                string PhoneNumber = "";
                eEmployee obj = new eEmployee();
                obj.EmployeeId = Id;
                obj.IsActive = true;
                var _GetEmail = (List<eEmployee>)null;
                _GetEmail = cEmployee.ManageEmployee(obj).ToList();

                if (_GetEmail.Count > 0)
                {
                    Email = _GetEmail[0].Email;
                }
                return Json(Email);
            }
            catch (Exception)
            {

            }
            return Json(null);
        }
        
        [HttpGet]
        public JsonResult DoctorPhone(int Id)
        {
            try
            {
                string PhoneNumber = "";
                eDoctor obj = new eDoctor();
                obj.DoctorId = Id;
                obj.IsActive = true;
                var _GetEmail = (List<eDoctor>)null;
                _GetEmail = cDoctor.ManageDoctor(obj).ToList();

                if (_GetEmail.Count > 0)
                {
                    PhoneNumber = _GetEmail[0].PhoneNumber;
                }
                return Json(PhoneNumber);
            }
            catch (Exception)
            {

            }
            return Json(null);
        }
        
        [HttpGet]
        public JsonResult DoctorName(int Id)
        {
            try
            {
                string DoctorName = "";
                eDoctor obj = new eDoctor();
                obj.DoctorId = Id;
                obj.IsActive = true;
                var _GetEmail = (List<eDoctor>)null;
                _GetEmail = cDoctor.ManageDoctor(obj).ToList();

                if (_GetEmail.Count > 0)
                {
                    DoctorName = _GetEmail[0].DoctorName;
                }
                return Json(DoctorName);
            }
            catch (Exception)
            {

            }
            return Json(null);
        }
        
        [HttpGet]
        public JsonResult DoctorEmail(int Id)
        {
            try
            {
                string Email = "";
                eDoctor obj = new eDoctor();
                obj.DoctorId = Id;
                obj.IsActive = true;
                var _GetEmail = (List<eDoctor>)null;
                _GetEmail = cDoctor.ManageDoctor(obj).ToList();

                if (_GetEmail.Count > 0)
                {
                    Email = _GetEmail[0].Email;
                }
                return Json(Email);
            }
            catch (Exception)
            {

            }
            return Json(null);
        }
        
    }
}
