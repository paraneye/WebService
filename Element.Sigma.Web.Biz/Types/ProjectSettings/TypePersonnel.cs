using System;
using System.Runtime.Serialization;

namespace Element.Sigma.Web.Biz.Types.ProjectSettings
{
    [DataContract]
    [Serializable]
    public class TypePersonnel
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int PersonnelId;
        [DataMember]
        public string Name;
        [DataMember]
        public string FirstName;
        [DataMember]
        public string LastName;
        [DataMember]
        public int CompanyId;
        [DataMember]
        public string PersonnelTypeCode;
        [DataMember]
        public string CompanyName;
        [DataMember]
        public string RoleName;
        [DataMember]
        public string PhotoUrl;
        [DataMember]
        public string EmployeeId;
        [DataMember]
        public string PhoneNumber;
        [DataMember]
        public string EmailAddress;
        [DataMember]
        public string NfcCardId;
        [DataMember]
        public string PinCode;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;
        [DataMember]
        public int ProjectId;
    }
}
