using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Path_Lab_ENTITY;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Path_Lab_HELPER
{
    public class CommonHelper
    {
        public static eSiteSettings GetSiteSettings()
        {
            eSiteSettings obj = new eSiteSettings();
            try
            {
                using (StreamReader r = new StreamReader("wwwroot/data/siteSettings.json"))
                {
                    string json = r.ReadToEnd();
                    List<eSiteSettings> items = JsonConvert.DeserializeObject<List<eSiteSettings>>(json);
                    if (items.Count > 0)
                    {
                        obj.SiteUrl = items[0].SiteUrl.ToString();
                        obj.SmtpHost = items[0].SmtpHost.ToString();
                        obj.FromEmail = items[0].FromEmail.ToString();
                        obj.CCEmail = items[0].CCEmail.ToString();
                        obj.FromName = items[0].FromName.ToString();
                        obj.EmailPass = items[0].EmailPass.ToString();
                        obj.SMTPPort = items[0].SMTPPort.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                obj.SiteUrl = "";
                obj.SmtpHost = "";
                obj.FromEmail = "";
                obj.FromName = "";
                obj.EmailPass = "";
                obj.SMTPPort = "0";
            }

            return obj;
        }
        public static void SaveCookie(HttpResponse Response, string CookieName, string CookieValue, int expDays)
        {
            CookieOptions options = new CookieOptions();
            try
            {
                if (expDays > 0)
                {
                    options.Expires = DateTime.Now.AddDays(expDays);
                }
                else
                {
                    options.Expires = DateTime.Now.AddMilliseconds(1);
                }

                Response.Cookies.Append(CookieName, CookieValue, options);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                options = null;
            }
        }

        public static Boolean IsAuthenticate(HttpRequest req)
        {
            Boolean vIsAuthenticate = false;

            try
            {
                vIsAuthenticate = Convert.ToBoolean(req.Cookies["IsAuthenticate"]);
            }
            catch
            {
                vIsAuthenticate = false; //Default
            }
            finally
            {
            }

            return vIsAuthenticate;
        }

        public static string GetCookieUserID(HttpRequest req)
        {
            string UserID = "";
            try
            {
                UserID = req.Cookies["UserId"].ToString();
            }
            catch
            {
                UserID = ""; //Default
            }
            finally
            {
            }
            return UserID;
        }

        public static string GetCookieUserName(HttpRequest req)
        {
            string UserID = "";
            try
            {
                UserID = req.Cookies["UFullName"].ToString();
            }
            catch
            {
                UserID = ""; //Default
            }
            finally
            {
            }
            return UserID;
        }


        public static string GetCookieUserNameEmail(HttpRequest req)
        {
            string UserID = "";
            try
            {
                UserID = req.Cookies["UserName"].ToString();
            }
            catch
            {
                UserID = ""; //Default
            }
            finally
            {
            }
            return UserID;
        }

        public static string GetCookieUserTypeID(HttpRequest req)
        {
            string UserTypeID = "";
            try
            {
                UserTypeID = req.Cookies["UserTypeID"].ToString();
            }
            catch
            {
                UserTypeID = "0"; //Default
            }
            finally
            {
            }
            return UserTypeID;
        }

        public static string GetCookieEntityTypeID(HttpRequest req)
        {
            string EntityTypeID = "";
            try
            {
                //OrgID = req.Cookies["OrgID"].ToString();
                EntityTypeID = req.Cookies["EntityTypeID"];
            }
            catch
            {
                EntityTypeID = ""; //Default
            }
            finally
            {
            }
            return EntityTypeID;
        }
        public static string GetCookieOrgID(HttpRequest req)
        {
            string OrgID = "";
            try
            {
                //OrgID = req.Cookies["OrgID"].ToString();
                OrgID = req.Cookies["OrgID"];
            }
            catch
            {
                OrgID = ""; //Default
            }
            finally
            {
            }
            return OrgID;
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

        public static Boolean SendEmail(string FromEmail, string FromName, string ToEmail, string Subject, string Emailbody)
        {
            Boolean IsSent = true;

            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            try
            {
                if (FromEmail == "")
                {
                    FromEmail = "report@repromed.in";
                }

                MailAddress fromAddress = new MailAddress(FromEmail, FromName);
                smtpClient.Host = "webmail.repromed.in";
                smtpClient.Port = 25;//Convert.ToInt32(ConfigurationManager.AppSettings["MailServerPort"].ToString());
                message.From = fromAddress;
                message.To.Add(ToEmail);
                message.Subject = Subject;
                message.IsBodyHtml = false;
                // Message body content
                message.Body = Emailbody;
                // Send SMTP mail
                smtpClient.Send(message);
                IsSent = true;
            }
            catch (Exception ex)
            {
                //throw new ArgumentException("Mail not send." + ex.Message);
                //msg = "Send Email Failed." + ex.Message;
                IsSent = false;
            }
            return IsSent;
        }
        public static Boolean SendEmailwithAuthentication(string pEmailSendTo, string pEmailSendCC, string pEmailSubject, string pEmailMessage)
        {
            //Send The email First 
            Boolean vIsEmailSent = false;
            string FromEmail = "";
            string password = "";
            string FromName = "";

            try
            {

                var vSiteSettings = GetSiteSettings();

                FromEmail = vSiteSettings.FromEmail;// "";"Repromed"
                password = vSiteSettings.EmailPass;// "P@ssword123@";
                FromName = vSiteSettings.FromName;

                SmtpClient smtpClient = new SmtpClient();
                MailMessage message = new MailMessage();
                MailAddress fromAddress = new MailAddress(FromEmail, FromName);

                smtpClient.Host = vSiteSettings.SmtpHost;// "mail.repromed.in";
                smtpClient.Credentials = new NetworkCredential(FromEmail, password);
                smtpClient.Port = Convert.ToInt32(vSiteSettings.SMTPPort);// 25;
                message.From = fromAddress;

                if (!string.IsNullOrEmpty(pEmailSendTo))
                {
                    foreach (var address in pEmailSendTo.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        message.To.Add(address);
                    }
                }

                if (!string.IsNullOrEmpty(pEmailSendCC))
                {
                    foreach (var address in pEmailSendCC.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        message.CC.Add(address);
                    }
                }

                message.Subject = pEmailSubject;
                message.IsBodyHtml = true;
                // Message body content
                message.Body = pEmailMessage;
                // Send SMTP mail
                smtpClient.Send(message);
                vIsEmailSent = true;
            }
            catch (Exception ex)
            {
                vIsEmailSent = false;
            }

            return vIsEmailSent;
        }
        public static Boolean SendEmailwithMultipleID(string pEmailSendTo, string pEmailSendCC, string pEmailSubject, string pEmailMessage)
        {
            //Send The email First 
            Boolean vIsEmailSent = false;
            string FromEmail = "";
            try
            {
                FromEmail = "report@repromed.in";
                SmtpClient smtpClient = new SmtpClient();
                MailMessage message = new MailMessage();
                MailAddress fromAddress = new MailAddress(FromEmail, "Report Email");

                smtpClient.Host = "webmail.repromed.in";// ConfigurationManager.AppSettings["MailServer"].ToString();
                smtpClient.Port = 25;// Convert.ToInt32(ConfigurationManager.AppSettings["MailServerPort"].ToString());
                message.From = fromAddress;

                if (!string.IsNullOrEmpty(pEmailSendTo))
                {
                    foreach (var address in pEmailSendTo.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        message.To.Add(address);
                    }
                }

                if (!string.IsNullOrEmpty(pEmailSendCC))
                {
                    foreach (var address in pEmailSendCC.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        message.CC.Add(address);
                    }
                }

                message.Subject = pEmailSubject;
                message.IsBodyHtml = true;
                // Message body content
                message.Body = pEmailMessage;
                // Send SMTP mail
                smtpClient.Send(message);
                vIsEmailSent = true;
            }
            catch (Exception ex)
            {
                //throw;
            }

            return vIsEmailSent;
        }

        public static string base64Encode(string data)
        {
            byte[] encData_byte = new byte[data.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(data);
            string encodedData = Convert.ToBase64String(encData_byte);
            return encodedData;
        }
        public static string base64Decode(string data)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();

            byte[] todecode_byte = Convert.FromBase64String(data);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
        public static string ToTitleCase(string str)
        {
            string retval = str;

            if (!string.IsNullOrEmpty(str))
            {
                retval = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
            }

            return retval;
        }
                       
        
        public static string GetMACAddress()
        {
            try
            {
                NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface networkInterface in networkInterfaces)
                {
                    if (networkInterface.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                        networkInterface.OperationalStatus == OperationalStatus.Up)
                    {
                        PhysicalAddress mac = networkInterface.GetPhysicalAddress();
                        if (!string.IsNullOrEmpty(mac.ToString()))
                        {
                            return mac.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting MAC address: " + ex.Message);
            }

            return "N/A";
        }


        public static string GetDeviceType()
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                return "Desktop";
            }
            else if (Environment.OSVersion.Platform == PlatformID.Unix)
            {
                return "Linux/Unix-based";
            }
            else if (Environment.OSVersion.Platform == PlatformID.MacOSX)
            {
                return "Mac";
            }
            else
            {
                return "Unknown";
            }
        }
    }

}
