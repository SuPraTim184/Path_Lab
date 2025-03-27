using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_Lab_ENTITY
{
    public class eLoginForAdmin
    {
        public string UserId { get; set; }
        public int? EntityTypeID { get; set; }
        public string EntityID { get; set; }
        public int? UserTypeId { get; set; }
        public int? SecurityGroupID { get; set; }
        public string UserName { get; set; }
        public string LoginPassword { get; set; }
        public string FullName { get; set; }
        public string PrimaryEmail { get; set; }
        public string PrimaryPhone { get; set; }
        public string Address { get; set; }
        public string Nationality { get; set; }
        public string StateName { get; set; }
        public DateTime? LastLoggedIn { get; set; }
        public DateTime? PasswordStart { get; set; }
        public DateTime? PasswordExpire { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? IsLocked { get; set; }
        public int? StatusId { get; set; }
        public string ProfilePicture { get; set; }
        public string OrgId { get; set; }
        public string CorporateId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsPublic { get; set; }
        public DateTime? LastViewDate { get; set; }
    }
}
