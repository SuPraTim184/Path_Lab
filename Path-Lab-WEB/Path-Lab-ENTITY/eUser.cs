using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Path_Lab_ENTITY
{
    public class eLogin
    {
        public Int32? LoginDetailsID { get; set; }
        public string Mode { get; set; }
        public string UserID { get; set; }

        public string UserName { get; set; }
        public string LoginPassword { get; set; }
        public string ClientIP { get; set; }
        public string ClientIPV6 { get; set; }
        public string ClientMac { get; set; }
        public string LoginDeviceType { get; set; }
        public string LoginDeviceName { get; set; }
        public string LoginXCoordinate { get; set; }
        public string LoginYCoordinate { get; set; }
        public string LoginDeviceOs { get; set; }
        public string LoginDevice { get; set; }
        //
        public string PrimaryPhone { get; set; }
        public string FullName { get; set; }
        public string PrimaryEmail { get; set; }
    }
    public class eUser
    {        
        public string UserID { get; set; }
        public Int32? EntityTypeID { get; set; }
        public string EntityID { get; set; }
        public Int32? UserTypeID { get; set; }
        public Int32? SecurityGroupID { get; set; }
        public string SecurityGroupName { get; set; }
        public string UserTypeName { get; set; }
        public string UserName { get; set; }
        public string LoginPassword { get; set; }
        public string FullName { get; set; }
        public string EntityName { get; set; }
        public string PrimaryPhone { get; set; }
        public string PrimaryEmail { get; set; }
        public DateTime? LastLoggedIn { get; set; }
        public DateTime? PasswordExpire { get; set; }
        public DateTime? PasswordStart { get; set; }
        public bool IsLocked { get; set; }

        public string OrgID { get; set; }
        public string OrgCode { get; set; }
        public string OrgName { get; set; }
        public string OrgAddress { get; set; }

        public string CorporateId { get; set; }
        public string CorporateName { get; set; }
        public string DefaultLanding { get; set; }
        public Int32? StatusId { get; set; }
        public string StatusName { get; set; }
        public DateTime? LastViewDate { get; set; }
        public string ProfilePicture { get; set; }

        public Int32? RoleID { get; set; }
        public bool Rememberme { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsPublic { get; set; }
        public string ActorID { get; set; }

        //public string UserName { get; set; }
        
    }

    public class eResetPassword
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string LoginPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string ActorID { get; set; }
        public bool? IsActive { get; set; }
    }

    public class ePerson
    {
        public string PersonId { get; set; }
        public Int32? EntityTypeID { get; set; }
        public string EntityID { get; set; }
        public string FullName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsPublic { get; set; }
        public string ActorID { get; set; }
        public string SrTxt { get; set; }
        public string OrgID { get; set; }
    }

    public class eRegistration
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string UserPassword { get; set; }
        public string VerifyPassword { get; set; }

    }

    public class ViewLogin
    {
        public IEnumerable<eUser> eUsers { get; set; }
        public IEnumerable<eUser> eLogin { get; set; }
    }

    public class eSaveContact
    {
        public string? ContactUsID { get; set; }
        public string? SendBy { get; set; }
        public string? ReplyContactUsID { get; set; }
        public string? ContactName { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactSubject { get; set; }
        public string? ContactMessage { get; set; }
        public string? ContactMessageByAdmin { get; set; }
        public DateTime? DateEntered { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsRead { get; set; }
    }

    public class eChatUs
    {
        public int? ChatUsID { get; set; }
        public string? UserID { get; set; }
        public string? FullName { get; set; }
        public string? ChatComment { get; set; }
        public string? ReplyByName { get; set; }
        public DateTime? ReplyDate { get; set; }
        public DateTime? DateEntered { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsReadAdmin { get; set; }
        public bool? IsReadUser { get; set; }
    }

}
