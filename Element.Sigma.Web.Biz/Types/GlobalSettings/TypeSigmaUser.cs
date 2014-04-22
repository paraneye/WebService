using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace Element.Sigma.Web.Biz.Types.GlobalSettings
{
    [DataContract]
    [Serializable]
    public class TypeSigmaUser
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public string SigmaUserId;
        [DataMember]
        public int CompanyId;
        [DataMember]
        public string CompanyName;
        [DataMember]
        public string EmployeeId;
        [DataMember]
        public string FirstName;
        [DataMember]
        public string LastName;
        [DataMember]
        public string PhoneNo;
        [DataMember]
        public string Email;
        [DataMember]
        public string PhotoUrl;
        [DataMember]
        public string StartDate;
        [DataMember]
        public string EndDate;
        [DataMember]
        public string Password;
        [DataMember]
        public string OldPassword;
        [DataMember]
        public string NewPassword;
        [DataMember]
        public string ConfirmNewPassword;
        [DataMember]
        public string IsActive;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;
        [DataMember]
        public string SigmaUserGuid;
        [DataMember]
        public int DefaultProjectId;
        [DataMember]
        public List<TypeSigmaUserSigmaRole> SigmaUserSigmaRoles;
    }

}
