using System;
using System.Runtime.Serialization;

namespace Element.Sigma.Web.Biz.Types.GlobalSettings
{
    [DataContract]
    [Serializable]
    public class TypeCompany
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public string CompanyId;
        [DataMember]
        public string Name;
        [DataMember]
        public string IsClient;
        [DataMember]
        public string Address;
        [DataMember]
        public string ContactName;
        [DataMember]
        public string ContactPhone;
        [DataMember]
        public string ContactFax;
        [DataMember]
        public string ContactEmail;
        [DataMember]
        public string ContractTypeCode;
        [DataMember]
        public string CompanyTypeCode;
        [DataMember]
        public string LogoFilePath;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;
    }

}
