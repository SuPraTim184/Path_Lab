using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_Lab_ENTITY
{
    public class eLookUp
    {
    }


    public class eSiteSettings
    {
        public string SiteUrl { get; set; }
        public string SmtpHost { get; set; }
        public string FromEmail { get; set; }
        public string CCEmail { get; set; }
        public string FromName { get; set; }
        public string EmailPass { get; set; }
        public string SMTPPort { get; set; }
    }
    public class eOrgType
    {
        public int? OrgTypeId { get; set; }
        public string OrgTypeName { get; set; }
        public int? DisplayOrder { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Modifiedby { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsPublic { get; set; }
        public string ActorID { get; set; }
    }

    public class ePrefix
    {
        public int? PrefixID { get; set; }
        public string PrefixName { get; set; }
        public int? DisplayOrder { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Modifiedby { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsPublic { get; set; }
        public string ActorID { get; set; }
    }

    public class eDesignation
    {
        public string DesignationID { get; set; }
        public string DesignationName { get; set; }
        public int? DisplayOrder { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Modifiedby { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsPublic { get; set; }
        public string ActorID { get; set; }
    }

    //End of Confirm section

    public class eFileAttachment
    {
        public Int32? AttachmentID { get; set; }
        public Int32? AttachmentTypeID { get; set; }
        public string AttachmentType { get; set; }
        public Int32? EntityTypeID { get; set; }
        public string EntityTypeName { get; set; }
        public Int32? EntityID { get; set; }
        public string FileName { get; set; }
        public string AttachmentDescription { get; set; }
        public DateTime? DateEntered { get; set; }
        public Int32? EnteredByID { get; set; }
        public string EnteredBy { get; set; }
        public DateTime? DateUpdated { get; set; }
        public Int32? UpdatedByID { get; set; }
        public string UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public string CF { get; set; }
        public string id { get; set; }
        public string cfid { get; set; }
        public Int32? PatientID { get; set; }
        public string PatientName { get; set; }
        public string MRNID { get; set; }
        public Int32? OrgID { get; set; }

    }

    public class eLupAttachmentType
    {
        public Int32? AttachmentTypeID { get; set; }
        public string AttachmentType { get; set; }
        public DateTime? DateEntered { get; set; }
        public Int32? EnteredByID { get; set; }
        public DateTime? DateUpdated { get; set; }
        public Int32? UpdatedByID { get; set; }
        public bool? IsActive { get; set; }
        public Int32? ActorID { get; set; }
        public Int32? OrgID { get; set; }

    }


    public class eLupStatus
    {
        public Int32? StatusId { get; set; }
        public Int32? StatusTypeId { get; set; }
        public string StatusTypeName { get; set; }
        public string StatusName { get; set; }
        public string StatusDescription { get; set; }
        public Int32? DisplayOrder { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Modifiedby { get; set; }
        public bool? IsActive { get; set; }
        public string ActorID { get; set; }

    }


    public class eDepartment
    {
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public string ParentId { get; set; }
        public int? DisplayOrder { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Modifiedby { get; set; }
        public bool IsActive { get; set; }
        public string ActorID { get; set; }
    }


    public class eLupUserType
    {
        public Int32? UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        public string UserTypeDescription { get; set; }
        public Boolean? DisplayOnEmployee { get; set; }
        public Boolean? DisplayOnDoctor { get; set; }
        public Boolean? IsPublic { get; set; }
        public string ActorID { get; set; }
        public bool? IsActive { get; set; }
    }

    
    public class eLupUserTypeTable
    {
        public Int32? LupUserTypeId { get; set; }
        public Int32? UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        public DateTime? DateEntered { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool? IsActive { get; set; }
    }




    public class eSecurityGroup
    {
        public Int32? SecurityGroupID { get; set; }
        public string SecurityGroupName { get; set; }
        public string SecurityGroupDescription { get; set; }

        public Int32? DefaultMenuID { get; set; }
        public string DefaultMenuName { get; set; }
        public string ActorID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }

    public class eLupMenu
    {
        public Int32? MenuID { get; set; }
        public string MenuName { get; set; }
        public string MenuDescription { get; set; }
        public bool IsClickable { get; set; }
        public bool IsVisible { get; set; }
        public string Url { get; set; }
        public string MenuClass { get; set; }
        public string MenuIcon { get; set; }
        public Int32? ParentMenuID { get; set; }
        public string ParentMenu { get; set; }
        public bool IsAdminPage { get; set; }
        public Int32? DIsplayOrder { get; set; }
        public string NavigationTarget { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsChecked { get; set; }
        public Int32? SecurityGroupID { get; set; }
        public Int32? SecurityGroupMenuID { get; set; }
        public string ActorId { get; set; }
        public string OrgId { get; set; }
        public int DisplayOrder { get; set; }
        public bool? IsTopMenu { get; set; }
        public bool? IsLeftMenu { get; set; }
        public bool IsForSAdmin { get; set; }
        public Int32? ModuleID { get; set; }
        public string ModuleName { get; set; }

    }

    public class eSecurityGroupMenuDetails
    {
        public Int32? SecurityGroupID { get; set; }
        public string SecurityGroupName { get; set; }
        public List<eLupMenu> LstMenu { get; set; }
    }

    public class eSecurityGroupMenu
    {
        public Int32? SecurityGroupID { get; set; }
        public string SecurityGroupName { get; set; }
        public Int32? MenuID { get; set; }
        public string ActorId { get; set; }
        public string OrgId { get; set; }
    }
    public class eMessageTemplate
    {
        public Int32? MessageTemplateID { get; set; }
        public Int32? TypeId { get; set; }
        public string TemplateName { get; set; }
        public string SMSTemplate { get; set; }
        public string WhatsAppTemplate { get; set; }
        public string EmailTemplate { get; set; }
        public bool IsActiveForSMS { get; set; }
        public bool IsActiveURLForSMS { get; set; }
        public bool IsActiveForWhatsApp { get; set; }
        public bool IsActiveURLForWhatsApp { get; set; }
        public bool IsActiveForEmail { get; set; }
        public bool IsActiveURLForEmail { get; set; }
        public string ActorId { get; set; }
        public string OrgId { get; set; }
    }

    public class eLupAccountHeadType
    {
        public string AccountHeadTypeId { get; set; }
        public string AccountHeadTypeCode { get; set; }
        public string AccountHeadTypeName { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? IsCPIP { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsPublic { get; set; }
        public string ActorID { get; set; }
    }

}
